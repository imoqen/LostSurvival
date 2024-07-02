/*The code used to change the volume within settings*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicSettingsMenu : MonoBehaviour
{

[SerializeField] Slider volumeSlider; // makes volume slider appear in unity editor

public void changeVolume() { // change volume method
  AudioListener.volume = volumeSlider.value; // changes the audio listener volume to the value of the slider
  }

}
