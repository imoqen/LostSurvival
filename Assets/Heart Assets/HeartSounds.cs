/*The code for the heart sounds*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSounds : MonoBehaviour
{
  public AudioSource HealthSound; // the audio source HealthSound

  public void PlayHealthSound() { // the method for playing the health sound

    HealthSound.Play(); // plays the health sound
  }
}
