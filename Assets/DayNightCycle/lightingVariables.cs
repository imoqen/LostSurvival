/*The script used to declare various lighting variables*/

using UnityEngine;
using UnityEngine.UI;

[System.Serializable] // it appears in the unity editor

public class lightingVariables : MonoBehaviour { // creating the lighting variables class

/* declaring the following variables, which are all gradients and can be changed by the
   user within the unity editor. */
public Gradient AmbientColour;       // the ambient colour
public Gradient DirectionalColour;   // the directional colour
public Gradient FogColour;           // the fog colour

}
