/*The script for the player collision of the heart*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
  public GameObject heart;        // game object which the heart prefab can be assigned to
  public GameObject playerObject; // game object which the player controller object can be assigned to

  //detects collisions between the GameObjects with colliders attached
        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Player Tag") // if the heart collides with an object which
                                                          // contains the player tag
            {
                Debug.Log("Health Given");  // VALIDATION - validates that this statement has been run
                playerObject.GetComponent<playerHealth>().Heal(); // runs the heal method from playerHealth
                Destroy(heart); // destroys the heart component
                heart.GetComponent<HeartSounds>().PlayHealthSound(); // plays the health sound from the heart
                                                                     // sounds script
            }
        }
}
