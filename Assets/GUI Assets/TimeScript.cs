/*The script used for timing how long the player has survived for in the world*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // uses the ui namespace

public class TimeScript : MonoBehaviour
{
  public float timeSurvived; // the float used to store the value of the amount of time that
                             // the player has survived
  public Text timeSurvivedOutput; // the output of the amount of time survived, when the player is alive
  public Text timeSurvivedGameOverOutput; // the output of the amount of time survived, when the player is dead
  public float beginningTime; // the time at the start of the game

  void Start() // start method - called before the first frame update
    {
      timeSurvived = 0; // the time survived is equal to 0 at the start of the game
      beginningTime = Time.time; // the beginning time is the time that the program has ran for in this session
      print(beginningTime); // beginning time is printed for validation
    }

    void Update() // update method - called once per frame
    {
      timeSurvived = Mathf.Floor((Time.time) - beginningTime); // the time survived is equal to the time - the beginning time,
      // rounded down to the nearest whole number using Mathf.Floor. it does time - beginning time because the time is not always
      // representative of the in-game time, as the player may spend time within the main menu screen which is not part of the game.
      print(timeSurvived); // prints the time survived for validating that it is correct
      timeSurvivedOutput.text = timeSurvived + " SECONDS"; // updates the output for when the player is alive
      timeSurvivedGameOverOutput.text = "YOU SURVIVED FOR " + timeSurvived + " SECONDS"; // updates the output for when the player is dead
    }
}
