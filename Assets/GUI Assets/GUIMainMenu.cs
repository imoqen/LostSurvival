/*The code used for the main menu scene*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIMainMenu : MonoBehaviour
{

  public GameObject MainMenuUI;
  public GameObject InstructionsUI;

  public string gameModeChooser; // the scene which holds the game, assigned in the editor

  public void PlayGame() // activates when the play game button is pressed
    {
      SceneManager.LoadScene(gameModeChooser); // switches scene to the game scene

    }

  public void ExitGame() // activates when the exit button is pressed
    {

      Application.Quit(); // quits the game
      Debug.Log("Exiting Game"); // to validate the method runs correctly

    }

  public void OpenInstructions() // activates when the instructions button is pressed
    {

      InstructionsUI.SetActive(true); // sets the main menu ui to be invisible, so that the
                                   // instructions menu is visible (as it is underneath the
                                   // main menu ui screen).
    Debug.Log("Opening Instructions"); // to validate the method runs correctly

    }

  public void CloseInstructions() // activates when the back button from instructions
                                  // is pressed
    {

      InstructionsUI.SetActive(false);  // sets the main menu ui to be visible, so that the
                                   // instructions menu is no longer visible (as it is underneath the
                                   // main menu ui screen).
      Debug.Log("Closing Instructions"); // to validate the method runs correctly

    }
}
