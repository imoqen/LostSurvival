/*The script for destroying a heart object when it is a certain distance away from the player*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeartWhenDistant : MonoBehaviour
{

  public GameObject heartObj; // the Heart object which can be assigned
  public GameObject playerObj; // the player object which can be assigned

  public float maxHeartPositionX; // maximum X position that the Heart can remain active
  public float minHeartPositionX; // minimum X position that the Heart can remain active
  public float maxHeartPositionZ; // maximum Z position that the Heart can remain active
  public float minHeartPositionZ; // minimum Z position that the Heart can remain active

    void Update() // the update method - called once per frame
    {

        //declares the values of the maximum and minimum Heart positions
        maxHeartPositionX = heartObj.transform.position.x + 300;
        minHeartPositionX = heartObj.transform.position.x - 300;
        maxHeartPositionZ = heartObj.transform.position.z + 300;
        minHeartPositionZ = heartObj.transform.position.z - 300;

        // if the player object is outside of the maximum and minimum Heart positions, the Heart object will be destroyed.
        if (playerObj.transform.position.x < minHeartPositionX || playerObj.transform.position.x > maxHeartPositionX || playerObj.transform.position.z < minHeartPositionZ || playerObj.transform.position.z > maxHeartPositionZ) {

          print("Heart out of range. despawned.");   // for validating that the selection statement is run correctly
          Destroy(heartObj);                         // destroys the Heart object

        }
    }
}
