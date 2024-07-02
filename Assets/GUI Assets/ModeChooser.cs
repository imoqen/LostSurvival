/*The code used for the mode chooser scene*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChooser : MonoBehaviour
{
  public string classicSurvival;   // the scene which holds the survival game, assigned in the editor
  public string peacefulAdventure; // the scene which holds the adventure game, assigned in the editor
  public string back;              // the scene which holds the main menu scene, assigned in the editor

  public void PlayClassicSurvival() // activates when the play classic survival button is pressed
    {
      SceneManager.LoadScene(classicSurvival); // switches scene to the classic survival scene
      print("classicSurvival scene has been loaded."); // for validation that the correct method is run
    }

  public void PlayPeacefulAdventure() // activates when the play peaceful adventure button is pressed
    {
      SceneManager.LoadScene(peacefulAdventure); // switches scene to the peacefuladventure scene
    }

  public void GoBack() // activates when the back button is pressed
  {
    SceneManager.LoadScene(back); // switches scene to the main menu scene
  }
}
