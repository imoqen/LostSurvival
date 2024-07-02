/*The code for the sounds of the gems and stars*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemStarSounds : MonoBehaviour
{
  public AudioSource randomGemSound;  // the audio source randomGemSound
  public AudioClip[] gemAudioSources; // the array of audio clips gemAudioSources

  public void PlayRandomGemSound() // method for generating a random sound from the array
        {
           randomGemSound.clip = gemAudioSources[Random.Range(0, gemAudioSources.Length)]; // gets a random clip
           randomGemSound.Play(); // plays this random clip
           print("Gem sound playing"); // for validation - to ensure it is playing from the correct method
        }

  public AudioSource StarSound; // the audio source for a star sound, which is played when the player collides with a star.

  public void PlayStarSound() { // method for playing the star sound

          StarSound.Play(); // plays the star sound sound
        }

  public AudioSource BeepSound; // the audio source for the beep sound, which is played when the game is over

  public void PlayBeepSound() { // method for playing the beep sound

          BeepSound.Play(); // plays the beep sound

  }
}
