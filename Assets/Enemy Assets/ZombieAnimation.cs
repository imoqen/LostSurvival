/*The script used for the animation of the zombies*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{

  public Animator zombieAnimator; // the animator which is assigned in the editor for zombie animation
  public bool attackingStatus;    // the boolean which defines whether the zombie is attacking or not

    void Update() // update method - called once per frame
    {

      zombieAnimator = gameObject.GetComponent<Animator>();     // gets the animation component of the zombieAnimator
      GameObject go = GameObject.Find("RigidBodyFPSController");  // gets the player controller object
      ZombieAttack za = go.GetComponent<ZombieAttack>();          // gets the ZombieAttack script
      bool attackingStatus = za.attacking;  // the attacking status is set equal to the value of attacking in ZombieAttack


      if (attackingStatus == true) { // if the zombie is attacking the player

        zombieAnimator.SetBool("isAttacking", true); // isAttacking is set to true
        //when isAttacking is true, the animation is run.
        print("animation updated");                  // the animation is updated

      }
    }
}
