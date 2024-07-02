/*The code for the settings menu*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

  public void SetFullscreen(bool isFullscreen) // method for making full screen
  {

    Screen.fullScreen = isFullscreen; // is full screen is true when Screen.fullScreen
                                      // is active, else, it is not full screen.

  }

  public void SetQuality(int qualityValue) // uses the int quality value to change the quality
                                           // that the terrain is rendered in
  {

    QualitySettings.SetQualityLevel(qualityValue); // sets the quality level using the quality value

  }

}
