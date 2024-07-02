/*The script which makes the zombies follow the player*/

using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour {

    public Transform playerTarget; // allows the player model to be referenced

    float zombieRotationSpeed = 3.0f; // the speed value for the rotation and
    float zombieMovementSpeed = 3.0f; // movement of the zombie. I may change this later.

 // Update method - called once per frame
 void Update () {

// causes the zombie to rotate their body to look at the player.
  transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (playerTarget.position - transform.position), zombieRotationSpeed * Time.deltaTime);

// causes the zombie to move towards the player.
  transform.position += transform.forward * zombieMovementSpeed * Time.deltaTime;

  }
}
