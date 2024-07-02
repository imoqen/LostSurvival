/*The code for the instantiation of the star around the player*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGeneration : MonoBehaviour
{
  public GameObject[] starObjects; // list which the star prefab can be added to, which is used to
                                    // spawn the objects randomly
  public GameObject starObject;
  public float minStarSpawnPositionX; // declaring the coordinate values
  public float maxStarSpawnPositionX;
  public float minStarSpawnPositionZ;
  public float maxStarSpawnPositionZ;
  public float starSpawnPositionY;
  public GameObject playerObj; // declaring the object which the coordinates will be gotten from
  public float period = 0.0f; //the variable used to loop every n seconds

  void Update() // update method
  {
    // finds the maximum and minimum x, y and z values for the enemies to spawn
    maxStarSpawnPositionX = (playerObj.transform.position.x + 25);
    minStarSpawnPositionX = (playerObj.transform.position.x - 25);
    maxStarSpawnPositionZ = (playerObj.transform.position.z + 25);
    minStarSpawnPositionZ = (playerObj.transform.position.z - 25);
    starSpawnPositionY = (playerObj.transform.position.y + 0.5f);

      // this if statement is used to automate the spawning of the stars. it spawns a star every time the period is greater than 5, and once it reaches that
      // value it resets to 0. so essentially it only spawns a star when period = 5
        if (period > 5) // if the period is greater than 5
        {
            period = 0; // reset the period to 0
            print("Star Generated"); // VALIDATION - ensuring this code is ran and therefore a star has been spawned
            int randomIndex = Random.Range(0, starObjects.Length); // the random index uses the length of the star objects. i am using only 1 so far.
            Vector3 randomSpawnPosition = new Vector3(Random.Range(minStarSpawnPositionX, maxStarSpawnPositionX), starSpawnPositionY, Random.Range(minStarSpawnPositionZ, maxStarSpawnPositionZ));
              // finds the random spawn position between the coordinates suitable, around the player.
            starObject = Instantiate(starObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            starObject.tag = "Star";
            starObject.SetActive(true);
              // instantiates the spawning of the star objects so they spawn in the world.
        }
        period += UnityEngine.Time.deltaTime; // increments using the value of the ingame time
  }
}
