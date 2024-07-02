/*This is the code to create the display of the Perlin map*/

using System.Collections; /*importing modules*/
using UnityEngine;

public class mapDisplay : MonoBehaviour { /*creates the public class mapDisplay which
                                            uses the MonoBehaviour script*/

  public Renderer textureRender; /*uses a renderer - makes an object appear on screen*/
  public MeshFilter meshFilter;
  public MeshRenderer meshRenderer;

  public void DrawTexture(Texture2D texture) {


    textureRender.sharedMaterial.mainTexture = texture; /*allows the texture to be viewed in*/
    textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height); /*unity so it is easy*/
                                                                      /*to view when programming*/

  }

public void DrawMesh(MeshData meshDataVariable, Texture2D texture) {
  meshFilter.sharedMesh = meshDataVariable.CreateMesh();
  meshRenderer.sharedMaterial.mainTexture = texture;

}

}
