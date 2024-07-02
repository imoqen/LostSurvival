/*The script for the countdown timer*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining; // time remaining float
    public bool countdownIsRunning = false; // countdown running is false
    public Text countdownText; // the countdown text ui element
    public GameObject GameOverCanvas;
    public GameObject UICanvas;
    public GameObject PauseMenuCanvas;
    public GameObject playerObj;

  private void Start()
    {
        timeRemaining = 150; // as soon as the game starts, the timer begins with
        countdownIsRunning = true; // 300 seconds left
    }

  void CountdownDisplay(float timeToDisplay)
    {
        timeToDisplay += 1; // adds 1 to the timeToDisplay variable which is the timeRemaining
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); // divides by 60 to find the minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // modulus by 60 to find the seconds
        countdownText.text = string.Format("{0:00} {1:00}", minutes, seconds);
        // formats the text so that it displays in the form MINUTES SECONDS
    }

  void Update()
    {

      if (timeRemaining == 0 && GameOverCanvas != null)
        {
          Cursor.lockState = CursorLockMode.None;
          Cursor.visible = true;
        }

        if (countdownIsRunning) // if the countdown is running
        {
            if (timeRemaining > 0) // and if the time remaining is greater than 0
            {
                timeRemaining -= Time.deltaTime; // minus the change in time from the time remaining
                CountdownDisplay(timeRemaining); // calls the CountdownDisplay method and passes in the time remaining
            }
            else // if the time remaining is less than 0, then the countdown is over.
            {
                print("countdown over");      // validating that the selection statement works correctly
                timeRemaining = 0;            // time remaining is set equal to 0
                countdownIsRunning = false;   // the countdown no longer runs
                Time.timeScale = 0f;
                GameOverCanvas.SetActive(true);                          // sets the game over canvas to be active
                UICanvas.SetActive(false);                               // sets the UI canvas to be inactive
                PauseMenuCanvas.SetActive(false);                        // sets the pause menu to be inactive
                Cursor.lockState = CursorLockMode.None;                  // ensures there is no lock mode on the cursor
                Cursor.visible = true;                                   // sets the cursor to visible
                playerObj.GetComponent<GemStarSounds>().PlayBeepSound(); // plays a random gem sound
            }
        }
    }
}
