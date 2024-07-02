/*The code used for the GUI pause menu*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPauseMenu : MonoBehaviour
{

public static bool isPaused = false; // the boolean which defines whether the game is paused or not
public GameObject pauseMenuUI;  // the game object of the pause menu
public GameObject UICanvas;     // the game object of the UI canvas
public GameObject TakeDamageScreen; // the game object of the take damage screen
public GameObject SettingsScreen;   // the game object of the settings screen
public GameObject QuitGameScreen; // the game object of the quit game screen

    void Update() // update method - called once per frame
    {

      if (isPaused && pauseMenuUI != null) // if is paused in true and the pause menu is active
        {
          Cursor.lockState = CursorLockMode.None; // do not lock the cursor
          Cursor.visible = true;                  // cursor is visible
          TakeDamageScreen.SetActive(false);      // take damage screen is inactive

        } else { // the pause menu isnt active and isPaused isnt true
          Cursor.lockState = CursorLockMode.Locked; // lock the cursor
          Cursor.visible = false;                   // cursor is invisible
          TakeDamageScreen.SetActive(true);         // take damage screen is active

        }

      if(Input.GetKeyDown(KeyCode.Escape) && (UICanvas.activeSelf)) { // if the UI canvas is active and user presses escape

        if(isPaused) { // if it is paused then resume the game
          Resume();
        }

        else { // if it isnt paused then pause the game
          Pause();
        }
      }
    }

    public void Resume() // public so it can be used in the resume button
    {
        pauseMenuUI.SetActive(false); // sets the pause menu to be inactive
        Time.timeScale = 1f; // time scale is 1
        isPaused = false; // is paused is true
        TakeDamageScreen.SetActive(true); // take damage screen is active

    }

    void Pause() // the pause method
    {
        pauseMenuUI.SetActive(true); // sets the pause menu to be active
        Time.timeScale = 0f; // time scale is 0
        isPaused = true; // is paused is true
        TakeDamageScreen.SetActive(false); // take damage screen is inactive
    }

    public void LoadSettings() // the method for the settings button
    {

      Debug.Log("Opening Settings"); // for validating that the method is running correctly
      SettingsScreen.SetActive(true); // makes the settings screen visible
      UICanvas.SetActive(false); // makes the UI canvas invisible so it does not interfere

    }

    public void CloseSettings() { // the method for closing the settings

      Debug.Log("Closing Settings"); // for validating that the method is running correctly
      SettingsScreen.SetActive(false); // makes the settings screen invisible
      UICanvas.SetActive(true); // makes the UI canvas invisible so it does not interfere

    }

    public void QuitGame() // the method for the quit game button
    {

      Debug.Log("Quitting");
      Application.Quit(); // quits the game

    }

    public void QuitButtonPressed() // the method for opening the quit game screen
    {

      Debug.Log("Opening Quit Menu");
      QuitGameScreen.SetActive(true); // makes the quit game screen visible
      UICanvas.SetActive(false); // makes the UI canvas invisible so it does not interfere

    }

    public void BackFromQuitMenu() // the method for going back from the quit game screen
    {

      Debug.Log("Closing Quit Menu");
      QuitGameScreen.SetActive(false); // makes the quit game screen invisible
      UICanvas.SetActive(true); // makes the UI canvas invisible so it does not interfere

    }

}
