/*The script for destroying a zombie object when it is a certain distance away from the player*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZombieWhenDistant : MonoBehaviour
{

  public GameObject zombieObj; // the zombie object which can be assigned
  public GameObject playerObj; // the player object which can be assigned

  public float maxZombiePositionX; // maximum X position that the zombie can remain active
  public float minZombiePositionX; // minimum X position that the zombie can remain active
  public float maxZombiePositionZ; // maximum Z position that the zombie can remain active
  public float minZombiePositionZ; // minimum Z position that the zombie can remain active

    void Update() // the update method - called once per frame
    {

        //declares the values of the maximum and minimum zombie positions
        maxZombiePositionX = zombieObj.transform.position.x + 300;
        minZombiePositionX = zombieObj.transform.position.x - 300;
        maxZombiePositionZ = zombieObj.transform.position.z + 300;
        minZombiePositionZ = zombieObj.transform.position.z - 300;

        // if the player object is outside of the maximum and minimum zombie positions, the zombie object will be destroyed.
        if (playerObj.transform.position.x < minZombiePositionX || playerObj.transform.position.x > maxZombiePositionX || playerObj.transform.position.z < minZombiePositionZ || playerObj.transform.position.z > maxZombiePositionZ) {

          print("zombie out of range. despawned.");   // for validating that the selection statement is run correctly
          Destroy(zombieObj);                         // destroys the zombie object

        }
    }
}
