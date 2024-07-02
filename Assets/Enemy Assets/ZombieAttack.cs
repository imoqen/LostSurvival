/*The script used for the ability of the zombie to attack and kill the player*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZombieAttack : MonoBehaviour
{

public GameObject deathMenuUI;  // the death menu UI object
public GameObject UICanvas;     // the UI canvas object
public bool isDead = false;     // the boolean to define whether the player is dead
public bool attacking = false;  // the boolean to define whether the zombie is attacking
public GameObject TakeDamageScreen; // the UI element for the red screen when taking dmaage

void colourChange() { // the method to turn the screen red

  var colour = TakeDamageScreen.GetComponent<Image>().color; // gets the colour of TakeDamageScreen
  colour.a = 0.6f; // changes its alpha value to 0.6 so it is visible
  TakeDamageScreen.GetComponent<Image>().color = colour; // returns this new alpha coloru value

}

void Update () { // the update method - called once per frame

  if (isDead && deathMenuUI != null) // this is for making the cursor visible and usable when the player dies
    {
      Cursor.lockState = CursorLockMode.None; // no lock mode
      Cursor.visible = true;                  // cursor is visible
    }

  if (TakeDamageScreen != null) { // if TakeDamageScreen is active (it always is)

    // gradually changes the alpha value back to 0, so that it does not remain visible
    // when the colourChange method is called.
    if (TakeDamageScreen.GetComponent<Image>().color.a > 0) {
      var colour = TakeDamageScreen.GetComponent<Image>().color;
      colour.a -= 0.005f;
      TakeDamageScreen.GetComponent<Image>().color = colour;
    }
  }
}
IEnumerator ResetAttackStatus() {     // the coroutine ResetAttackStatus
  yield return new WaitForSeconds(5); // waits for 5 seconds
  attacking = false;                  // the attacking status is now false
  print("Attacking now false");       // validation
}
  //Detect collisions between the GameObjects with Colliders attached
      void OnCollisionEnter(Collision collision)
      {
          //checks that the object has collided with a zombie by using a zombie tag
          if (collision.gameObject.tag == "Zombie")
          {
              //if it has the same tag as specified, the player takes damage
              Debug.Log("Damage Taken"); // for validation
              gameObject.GetComponent<playerHealth>().Damage(); // runs the damage method
              attacking = true;
              gameObject.GetComponent<ZombieSounds>().RandomSound(); // plays a zombie attack sound
              colourChange(); // changes sceen to red temporarily
              StartCoroutine("ResetAttackStatus"); // resets the attack status
          }

          if (gameObject.GetComponent<playerHealth>().currentHealth == 0) {
          // if the health of the player is 0 then the player is dead.

            gameObject.GetComponent<ZombieSounds>().PlayZombieScream(); // plays the zombie scream sound
            Debug.Log("Dead"); // for validation
            deathMenuUI.SetActive(true); // sets the UI death menu to true
            Time.timeScale = 0f; // the time scale is 0
            UICanvas.SetActive(false); // sets the UI canvas to false
            isDead = true; // isDead is now true as the player has died
            TakeDamageScreen.SetActive(false); // the TakeDamageScreen is set to be inactive.
          }
      }
}
