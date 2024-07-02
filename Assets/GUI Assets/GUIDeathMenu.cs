/*The code used for the death screen*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDeathMenu : MonoBehaviour
{
    public void QuitGame() // the function for the quit game button
    {
      Debug.Log("Quitting"); // for validating that the quit game button works correctly
      Application.Quit(); // quits the game using Application.Quit()
    }
}
