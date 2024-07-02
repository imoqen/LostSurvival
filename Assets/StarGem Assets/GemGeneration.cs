/*The code for the instantiation of the gem*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGeneration : MonoBehaviour
{
  public GameObject[] gemObjects; // list which the gem prefab can be added to, which is used to
                                    // spawn the objects randomly
  public GameObject gemObject;
  public float minGemSpawnPositionX; // declaring the coordinate values
  public float maxGemSpawnPositionX;
  public float minGemSpawnPositionZ;
  public float maxGemSpawnPositionZ;
  public float gemSpawnPositionY;
  public GameObject playerObj; // declaring the object which the coordinates will be gotten from
  public float period = 0.0f; //the variable used to loop every n seconds

  void Update() // update method
  {
    // finds the maximum and minimum x, y and z values for the enemies to spawn
    maxGemSpawnPositionX = (playerObj.transform.position.x + 25);
    minGemSpawnPositionX = (playerObj.transform.position.x - 25);
    maxGemSpawnPositionZ = (playerObj.transform.position.z + 25);
    minGemSpawnPositionZ = (playerObj.transform.position.z - 25);
    gemSpawnPositionY = (playerObj.transform.position.y + 1);

      // this if statement is used to automate the spawning of the gems. it spawns a gem every time the period is greater than 1, and once it reaches that
      // value it resets to 0. so essentially it only spawns a gem when period = 1
        if (period > 1) // if the period is greater than 5
        {
            period = 0; // reset the period to 0
            print("Gem Generated"); // VALIDATION - ensuring this code is ran and therefore a gem has been spawned
            int randomIndex = Random.Range(0, gemObjects.Length); // the random index uses the length of the gem objects. i am using only 1 so far.
            Vector3 randomSpawnPosition = new Vector3(Random.Range(minGemSpawnPositionX, maxGemSpawnPositionX), gemSpawnPositionY, Random.Range(minGemSpawnPositionZ, maxGemSpawnPositionZ));
              // finds the random spawn position between the coordinates suitable, around the player.
            gemObject = Instantiate(gemObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            gemObject.tag = "Gem";
            gemObject.SetActive(true);
              // instantiates the spawning of the gem objects so they spawn in the world.
        }
        period += UnityEngine.Time.deltaTime; // increments using the value of the ingame time
  }
}
