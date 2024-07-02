/*The script used for getting zombie sounds*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{

public AudioSource randomSound;  // the audio source randomSound
public AudioClip[] audioSources; // the array of audio clips audioSources

public void RandomSound() // method for generating a random sound from the array
      {
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)]; // gets a random clip
         randomSound.Play(); // plays this random clip
         print("sound playing"); // for validation - to ensure it is playing from the correct method
      }
public AudioSource ZombieScream; // the audio source for a zombie scream, which is played when the player dies.

public AudioSource Hit; // the audio source for a hit, which is played when the player dies.
public AudioSource Punch; // the audio source for a punch, which is played when the player dies.

public AudioClip[] zombieHurtAudioSources; // the array of audio clips zombieHurtAudioSources

public void RandomHurtSound() // method for generating a random sound from the array
     {
         randomSound.clip = zombieHurtAudioSources[Random.Range(0, zombieHurtAudioSources.Length)]; // gets a random clip
         randomSound.Play(); // plays this random clip
         print("hurt sound playing"); // for validation - to ensure it is playing from the correct method
       }

public void PlayZombieScream() { // method for playing the zombie scream

  ZombieScream.Play(); // plays the zombie scream sound
  }
}
