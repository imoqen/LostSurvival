/*The script for keeping track of the amount of zombies the player has killed*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // uses the ui namespace

public class KillCounterScript : MonoBehaviour
{
  public static int numberOfEnemiesKilled; // declares an integer for keeping count of the number of enemies
                                           // that the player has killed
  public Text killCounterOutput;           // the text which displays when the player is alive
  public Text killCounterGameOverOutput;   // the text which displays when the player is dead

  public static void killCounter() {

    numberOfEnemiesKilled += 1;   // adds one to the number of enemies killed variable
    print(numberOfEnemiesKilled); // for validating that the number of enemies killed is correct, and
                                  // the method is being called correctly

}

  void Update() { // update method - called once per frame
    killCounterOutput.text = " " + numberOfEnemiesKilled; // updates the text which is displayed while
    // the player is alive to show the number of enemies killed
    killCounterGameOverOutput.text = "YOU KILLED " + numberOfEnemiesKilled + " ZOMBIES";
    // updates the text which is displayed when the player has died to show how many enemies they killed
  }

}
