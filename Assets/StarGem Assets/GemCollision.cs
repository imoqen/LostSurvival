/*The code for the collision of the gem with the player*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollision : MonoBehaviour
{
  public GameObject gem;        // game object which the gem prefab can be assigned to
  public GameObject playerObject; // game object which the player controller object can be assigned to

  //detects collisions between the GameObjects with colliders attached
        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Player Tag") // if the gem collides with an object which
                                                          // contains the player tag
            {
                Debug.Log("Gem Collided With");  // VALIDATION - validates that this statement has been run
                playerObject.GetComponent<CollisionWithStarOrGem>().GemPoints(); // runs the gempoints method
                playerObject.GetComponent<GemStarSounds>().PlayRandomGemSound(); // plays a random gem sound
                Destroy(gem); // destroys the gem component
            }
        }
}
