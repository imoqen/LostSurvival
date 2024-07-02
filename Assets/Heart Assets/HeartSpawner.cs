/*The script for spawning hearts*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
  public GameObject[] heartObjects; // list which the heart prefab can be added to, which is used to
                                    // spawn the objects randomly
  public GameObject heartObject;
  public float minSpawnPositionX; // declaring the coordinate values
  public float maxSpawnPositionX;
  public float minSpawnPositionZ;
  public float maxSpawnPositionZ;
  public float spawnPositionY;
  public GameObject playerObj; // declaring the object which the coordinates will be gotten from
  public float period = 0.0f;  // the variable used to loop every n seconds

  void Update() // update method
  {
    // finds the maximum and minimum x, y and z values for the hearts to spawn
    maxSpawnPositionX = (playerObj.transform.position.x + 25);
    minSpawnPositionX = (playerObj.transform.position.x - 25);
    maxSpawnPositionZ = (playerObj.transform.position.z + 25);
    minSpawnPositionZ = (playerObj.transform.position.z - 25);
    spawnPositionY = (playerObj.transform.position.y + 0.5f);

      // this if statement is used to automate the spawning of the hearts. it spawns a heart every time the period is greater than 1, and once it reaches that
      // value it resets to 0. so essentially it only spawns a heart when period = 1

        if (period > 5) // if the period is greater than 1
        {
            period = 0; // reset the period to 0
            print("Heart Spawned"); // VALIDATION - ensuring this code is ran and therefore a heart has been spawned
            int randomHeartIndex = Random.Range(0, heartObjects.Length); // the random index uses the length of the heart objects. i am using only 1 so far.
            Vector3 randomHeartSpawnPosition = new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), spawnPositionY, Random.Range(minSpawnPositionZ, maxSpawnPositionZ));
              // finds the random spawn position between the coordinates suitable, around the player.
            heartObject = Instantiate(heartObjects[randomHeartIndex], randomHeartSpawnPosition, Quaternion.identity);
            heartObject.tag = "Heart";
            heartObject.SetActive(true);
            // instantiates the spawning of the heart objects so they spawn in the world.
        }
        period += UnityEngine.Time.deltaTime; // increments using the value of the ingame time
  }
}
