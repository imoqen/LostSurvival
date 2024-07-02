using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class meshGenerator
{
  public static MeshData generateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve _heightCurve, int editorPreviewLOD) {
    AnimationCurve heightCurve = new AnimationCurve(_heightCurve.keys);
    int width = heightMap.GetLength (0);
    int height = heightMap.GetLength (1);
    float topLeftX = (width-1)/-2f;
    float topLeftZ = (height-1)/2f;

    int meshSimplificationIncrement = (editorPreviewLOD == 0)?1:editorPreviewLOD * 2;
    int verticesPerLine = (width-1)/meshSimplificationIncrement + 1;

    MeshData meshDataVariable = new MeshData(verticesPerLine, verticesPerLine);
    int vertexIndex = 0;

    for (int y = 0; y < height; y+= meshSimplificationIncrement) {
      for (int x = 0; x < width; x+= meshSimplificationIncrement) {

        meshDataVariable.vertices[vertexIndex] = new Vector3(topLeftX + x,heightCurve.Evaluate(heightMap [x,y]) * heightMultiplier, topLeftZ - y);
        meshDataVariable.uvs[vertexIndex] = new Vector2 (x/(float)width,y/(float)height);

        if (x < width-1 && y < height - 1) {

          meshDataVariable.addTriangle(vertexIndex, vertexIndex + verticesPerLine + 1, vertexIndex + verticesPerLine);
          meshDataVariable.addTriangle(vertexIndex + verticesPerLine + 1, vertexIndex, vertexIndex + 1);

        }

        vertexIndex++;

      }

    }

  return meshDataVariable;

  }


}


public class MeshData {
  public Vector3[] vertices;
  public int[] triangles;
  public Vector2[] uvs;

  int triangleIndex;

  public MeshData( int meshWidth, int meshHeight) {
    vertices = new Vector3[meshWidth * meshHeight];
    uvs = new Vector2[meshWidth * meshHeight];
    triangles = new int[(meshWidth - 1) * (meshHeight - 1) * 6];

  }

  public void addTriangle (int a, int b, int c) {
    triangles[triangleIndex] = a;
    triangles[triangleIndex+1] = b;
    triangles[triangleIndex+2] = c;
    triangleIndex+= 3;
  }

  public Mesh CreateMesh() {
    Mesh mesh = new Mesh ();
    mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.uv = uvs;
    mesh.RecalculateNormals(); //lighting

    return mesh;
  }

}
