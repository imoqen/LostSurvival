/*This is the code used to generate the Perlin noise map onto the 2D plane using mapDisplay*/

using System.Collections; /*importing modules*/
using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using Random=UnityEngine.Random;

public class mapGenerator : MonoBehaviour { /*creates the public class mapGenerator which uses the
                                              MonoBehaviour script*/
  void Start() {

  seed = Random.Range(1,10000); // chooses a random seed value between 1 and 10000
  print(seed); // outputs the seed

  }

  public enum DrawMode {noiseMap, colourMap, Mesh};
  public DrawMode drawMode;

  public Noise.NormalizeMode normalizeMode;

  public const int mapChunkSize = 241;
  [Range (0,6)]
  public int editorPreviewLOD;
  public float noiseScale;

  public int octaves;
  [Range(0,1)]
  public float persistence;
  public float lacunarity;

  public int seed;
  public Vector2 offset;

  public float meshHeightMultiplier;

  public AnimationCurve meshHeightCurve;

  public bool autoUpdate; /*declares a variable to allow the 2D plane to auto update whenever a change
                            is made to it, such as a new value of noiseScale
  this has been implemented simply because it makes viewing in the editor easier.*/

  public TerrainType[] regions;

  Queue<MapThreadInfo<MapData>> mapDataThreadInfoQueue = new Queue<MapThreadInfo<MapData>>();
  Queue<MapThreadInfo<MeshData>> meshDataThreadInfoQueue = new Queue<MapThreadInfo<MeshData>>();

  public void DrawMapInEditor() {
    MapData mapData = generateMapData (Vector2.zero); //vector2.zero passed in to fix issue

    mapDisplay display = FindObjectOfType<mapDisplay> (); /*processes the noisemap so that it can be displayed on the screen*/
    if (drawMode == DrawMode.noiseMap) {
    display.DrawTexture(textureGenerator.textureFromHeightMap(mapData.heightMap));
    }
    else if (drawMode == DrawMode.colourMap) {
    display.DrawTexture(textureGenerator.textureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
    }
    else if (drawMode == DrawMode.Mesh) {
    display.DrawMesh(meshGenerator.generateTerrainMesh(mapData.heightMap, meshHeightMultiplier, meshHeightCurve, editorPreviewLOD), textureGenerator.textureFromColourMap(mapData.colourMap, mapChunkSize, mapChunkSize));
    }

  }

  public void RequestMapData(Vector2 centre, Action<MapData> callback) { // added vector2 centre to fix issue
		ThreadStart threadStart = delegate { // threadStart uses a delegate, a reference type data type that
                                         // defines the method RequestMapData's signature.
			MapDataThread (centre, callback); // centre is passed into MapDataThread
		};

		new Thread (threadStart).Start ();
	}

  	void MapDataThread(Vector2 centre, Action<MapData> callback) { //added vector2 centre to fix issue
  		MapData mapData = generateMapData (centre); //centre is passed into generateMapData
  		lock (mapDataThreadInfoQueue) { // mapDataThreadInfoQueue is locked
  			mapDataThreadInfoQueue.Enqueue (new MapThreadInfo<MapData> (callback, mapData)); //added to queue
  		}
  	}

  	public void RequestMeshData(MapData mapData, int lod, Action<MeshData> callback) {
  		ThreadStart threadStart = delegate {
  			MeshDataThread (mapData, lod, callback);
  		};

  		new Thread (threadStart).Start ();
  	}

  	void MeshDataThread(MapData mapData, int lod, Action<MeshData> callback) {
  		MeshData meshData = meshGenerator.generateTerrainMesh (mapData.heightMap, meshHeightMultiplier, meshHeightCurve, lod);
  		lock (meshDataThreadInfoQueue) {
  			meshDataThreadInfoQueue.Enqueue (new MapThreadInfo<MeshData> (callback, meshData));
  		}
  	}

  	void Update() {
  		if (mapDataThreadInfoQueue.Count > 0) {
  			for (int i = 0; i < mapDataThreadInfoQueue.Count; i++) {
  				MapThreadInfo<MapData> threadInfo = mapDataThreadInfoQueue.Dequeue ();
  				threadInfo.callback (threadInfo.parameter);
  			}
  		}

  		if (meshDataThreadInfoQueue.Count > 0) {
  			for (int i = 0; i < meshDataThreadInfoQueue.Count; i++) {
  				MapThreadInfo<MeshData> threadInfo = meshDataThreadInfoQueue.Dequeue ();
  				threadInfo.callback (threadInfo.parameter);
  			}
  		}
  	}


    MapData generateMapData(Vector2 centre) {
  		float[,] noiseMap = Noise.generateNoiseMap (mapChunkSize, mapChunkSize, seed, noiseScale, octaves, persistence, lacunarity, centre + offset, normalizeMode);

  		Color[] colourMap = new Color[mapChunkSize * mapChunkSize];
  		for (int y = 0; y < mapChunkSize; y++) {
  			for (int x = 0; x < mapChunkSize; x++) {
  				float currentHeight = noiseMap [x, y];
  				for (int i = 0; i < regions.Length; i++) {
  					if (currentHeight >= regions [i].height) {
  						colourMap [y * mapChunkSize + x] = regions [i].colour;
  					} else {
  						break;
  					}
  				}
  			}
  		}

  return new MapData(noiseMap, colourMap); // MapData is then returned with parameters noiseMap and colourMap

  }

  void OnValidate() { /*makes it called automatically when one of the variables in the script is changed*/
    if (lacunarity < 1) { /*ensures the lacunarity is never less than 1*/
      lacunarity = 1;
    }
  		if (octaves < 0) { /*ensures the octaves are never less than 0 (negative)*/
  			octaves = 0;
  		}
  	}

    struct MapThreadInfo<T> {
      public readonly Action<T> callback;
      public readonly T parameter;

      public MapThreadInfo (Action<T> callback, T parameter) {
        this.callback = callback;
        this.parameter = parameter;
      }
    }

}

[System.Serializable] //so that it displays in the inspector
public struct TerrainType {

  public float height;
  public Color colour;
  public string name;

}

public struct MapData {

  public readonly float[,] heightMap;
  public readonly Color[]  colourMap;

  public MapData (float[,] heightMap, Color[] colourMap)
  {
    this.heightMap = heightMap;
    this.colourMap = colourMap;
  }

}
