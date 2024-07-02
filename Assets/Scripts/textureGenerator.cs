using System.Collections;
using UnityEngine;

public static class textureGenerator
{

public static Texture2D textureFromColourMap(Color[] colourMap, int width, int height) {
  Texture2D texture = new Texture2D (width, height);
  texture.filterMode = FilterMode.Point;
  texture.wrapMode = TextureWrapMode.Clamp;
  texture.SetPixels (colourMap);
  texture.Apply ();
  return texture;

}

public static Texture2D textureFromHeightMap(float[,] heightMap) {
  int width =  heightMap.GetLength (0); /*defines the int 'width' which has a value of the
                                             length of noiseMap(0) which is the x axis*/
      int height = heightMap.GetLength(1); /*defines the int 'length' which has a value of the
                                             length of noiseMap(0) which is the y axis*/

      Color[] colourMap = new Color[width * height]; /*calls the Color class to represent RGBA*/
      for (int y = 0; y < height; y++) { /*iterates when y = 0 and is less than height, so adds 1
                                           to the end of y*/
        for (int x = 0; x < width; x++) {/*iterates when x = 0 and is less than width, so adds 1
                                             to the end of x*/
          colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x,y]);
          /*the colourMap array is y multiplied by the width + x and uses the Unity
            scripting API 'Lerp' to linearly interpolate through black and white
            using the noiseMap x and y values as the float.*/
        }
      }

      return textureFromColourMap(colourMap, width, height);
}

}
