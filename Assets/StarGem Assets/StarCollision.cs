/*The code for the collision with the stars*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollision : MonoBehaviour
{
  public GameObject star;        // game object which the star prefab can be assigned to
  public GameObject playerObject; // game object which the player controller object can be assigned to

  //detects collisions between the GameObjects with colliders attached
        void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Player Tag") // if the star collides with an object which
                                                          // contains the player tag
            {
                Debug.Log("Star Collided With");  // VALIDATION - validates that this statement has been run
                playerObject.GetComponent<CollisionWithStarOrGem>().StarPoints(); // runs the starpoints method
                playerObject.GetComponent<GemStarSounds>().PlayStarSound(); // plays the star sound
                Destroy(star); // destroys the star component
            }
        }
}
