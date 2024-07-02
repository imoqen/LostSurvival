/*The code for the points system of the stars and gems*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionWithStarOrGem : MonoBehaviour
{

public int points; // points integer
public Text pointsText; // points text for the ui
public Text gameOverPointsText; // points text for the game over ui

void Start() { // start method

  points = 0; // at the start, the points are set to 0

}

  public void StarPoints() // star method
  {
          points += 50; // increments 50 points
          pointsText.text = "" + points; // updates the outputted health value
          print("50 Points Gained"); // for validating that the method runs correctly
          gameOverPointsText.text = "" + points; // the game over points display
  }

  public void GemPoints() // star method
  {
          points += 10; // increments 10 points
          pointsText.text = "" + points; // updates the outputted health value
          print("10 Points Gained"); // for validating that the method runs correctly
          gameOverPointsText.text = "" + points; // the game over points display
  }
}
