/*The code used to give the player the ability to attack and kill zombies*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

  public GameObject playerObj; // the player controller object which will be assigned
  public GameObject enemy; // the zombie object which will be assigned
  public GameObject armsHit; // the object for the arms when they are hitting

  // the death and pause screen objects
  public GameObject DeathScreen;
  public GameObject PauseScreen;

  // below are the float variables of the coordinates of the player
  public float playerPositionX;
  public float playerPositionY;
  public float playerPositionZ;

  // below are the float variables of the vulnerable position of the zombie. this is a
  // region surrounding the zombie where the player is able to attack them.
  public float enemyVulnerabilityPositionMaxX;
  public float enemyVulnerabilityPositionMinX;
  public float enemyVulnerabilityPositionY;
  public float enemyVulnerabilityPositionMaxZ;
  public float enemyVulnerabilityPositionMinZ;

  public float enemyHealth; // the variable which is the health of the enemy

  public Animator zombieAnimator; // the animator used for the zombie

  public bool attackedByPlayer; // the bool which defines whether the zombie has been attacked
  public bool attacked; // the bool which is used for the animation

  public GameObject killCounter; // the kill counter game object
  public int enemyNumber; // the number of enemies

  public KillCounterScript killCounterScript; // the script used for the kill counter

    void Start() // the start method - called before the first frame update
    {
      enemyHealth = 100; // enemy health always set to 100 at the start of the game
      attacked = false; // attacked is always false at the start of the game
      enemyNumber = 0; // enemy number is always 0 at the start of the game

      GameObject killCounter = GameObject.Find("Kill Counter"); // finds the kill counter object

      killCounterScript = killCounter.GetComponent<KillCounterScript>();
      // gets the killcounterscript component from the kill counter object
    }

    IEnumerator ResetArmHit() { // the coroutine to wait 0.3 seconds before the arms return
                                // to their normal state, hit is not active anymore.
      yield return new WaitForSeconds(0.3f); // waits for 0.3 seconds
      armsHit.SetActive(false);              // sets the armsHit to not be active anymore.
    }

    void Update() // update method - called once per frame
    {
      zombieAnimator = gameObject.GetComponent<Animator>(); // gets the animator component
      PlayerAttack pa = enemy.GetComponent<PlayerAttack>(); // gets the PlayerAttack script
      bool attackedByPlayer = pa.attacked; // defines whether the animation is used
      ZombieAttack za = playerObj.GetComponent<ZombieAttack>(); // gets the ZombieAttack script
      bool attackingStatus = za.attacking; // uses attacking from ZombieAttack to update the status

      // gets the coordinates of the player
      playerPositionX = (playerObj.transform.position.x);
      playerPositionY = (playerObj.transform.position.y);
      playerPositionZ = (playerObj.transform.position.z);

      // calculates the vulnerable position of the enemy, using the player's coordinates
      enemyVulnerabilityPositionMaxX = (enemy.transform.position.x + 1);
      enemyVulnerabilityPositionMinX = (enemy.transform.position.x - 1);
      enemyVulnerabilityPositionY = (enemy.transform.position.y + 1);
      enemyVulnerabilityPositionMaxZ = (enemy.transform.position.z + 1);
      enemyVulnerabilityPositionMinZ = (enemy.transform.position.z - 1);

      // if the user presses the left mouse button
      if (Input.GetMouseButtonDown(0)) {
        armsHit.SetActive(true); // the armsHit becomes true, so that the player arms appear to hit
        StartCoroutine("ResetArmHit"); // starts the coroutine to make the armsHit no longer active
      }

      if (playerPositionX <= enemyVulnerabilityPositionMaxX && playerPositionX >= enemyVulnerabilityPositionMinX && playerPositionZ <= enemyVulnerabilityPositionMaxZ && playerPositionZ >= enemyVulnerabilityPositionMinZ && playerPositionY <= enemyVulnerabilityPositionY) {
        // if the player is in the range of the vulnerable enemy position
        { print("in enemy attack range");
        // for validating that the player is within the range of the enemy

      if (DeathScreen.activeInHierarchy == false && PauseScreen.activeInHierarchy == false && Input.GetMouseButtonDown(0)) {
        // if the user presses the left mouse button, and the death screen and pause screen are unactive,
                print("Player attacked the zombie!");           // prints that the player has attacked the zombie
                enemyHealth = enemyHealth - 100;                // takes away 100 from the enemyHealth, meaning it is 0.
                attacked = true;                                // attacked is set to true, for the animation
                zombieAnimator.SetBool("attacked", true);       // sets attacked in the zombieAnimator to true so that the animation updates
                print("zombie attacked animation updated");     // validates that the animation updated
                zombieAnimator.SetBool("isAttacking", false);   // sets isAttacking to false so that the zombie no longer plays the attack animation when it is hit

                playerObj.GetComponent<ZombieSounds>().RandomHurtSound(); // plays the random hurt sound of the player, which is in the ZombieSounds script

                KillCounterScript.killCounter();
      }
    }
            if (enemyHealth <= 0) { // if the enemy health is less than or equal to 0
              Destroy(enemy);       // destroy the enemy - it has been killed.
            }
          }
        }
      }
