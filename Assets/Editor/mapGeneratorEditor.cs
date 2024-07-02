/*This is the code to execute the Perlin noise generator within
the unity editor.*/

using UnityEngine; /* importing various modules for use in the code */
using System.Collections;
using UnityEditor; /* such as the UnityEditor module which is needed
                      because it requires manipulation of the GUI */

[CustomEditor (typeof (mapGenerator))]
public class mapGeneratorEditor : Editor { /* creates the public class
                                              named mapGeneratorEditor*/
public override void OnInspectorGUI() { /*overrides the OnInpsectorGUI method*/
  mapGenerator mapGen = (mapGenerator)target; /*gets a reference to mapGenerator
                                                by doing mapGen = target, as the
                                                target is the object thta the
                                                custom editor is currently inspecting
                                                and then cast to mapGenerator*/
  if (DrawDefaultInspector ()) { /*drawing the Default Inspector in Unity*/
    if (mapGen.autoUpdate) { /*allows the 2D plane to auto update whenever a change*/
      mapGen.DrawMapInEditor (); /*is made to it, such as a new value of noiseScale*/
    }   /*this has been implemented simply because it makes viewing in the editor easier*/
  }

    if (GUILayout.Button ("Generate")) {/*adds a button in the GUI with the text 'Generate'*/
      mapGen.DrawMapInEditor ();            /*that if pressed, executes the function
                                        mapGen.DrawMapInEditor()*/
    }
  }
}
