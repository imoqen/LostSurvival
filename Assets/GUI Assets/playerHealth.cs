/*The script used for the player health/damage system*/

using UnityEngine;
using UnityEngine.UI;                       //using unity's user interface namespace
public class playerHealth : MonoBehaviour   // creating class playerHealth
{
    public Text healthText; // declaring the healthText text which can be assigned in the editor
    public Image healthBar; // declaring the healthBar image which can be assigned in the editor

    public float currentHealth = 100;  // players always start with 100 health, this can
                                       // decrease as they interact with enemies, etc
    public float maxHealth = 100;      // this is the maximum health value
    public float damagePoints = 10;    // the amouint of damage that enemies do to the player
    public float healingPoints = 10;   // the amouint of health that can be given to the player

    void HealthBarFiller() // the method for filling the health bar, corresponding to
                           // the current health that the player has.
    {
        healthBar.fillAmount = (currentHealth / maxHealth);
        // fills the health bar to the value of current health / maximum health.
        // it divides by maximum health so that it is within a range of 0-1 instead
        // of 0-100 as the fill amount works only with values between 0 and 1.


    }

    public void Damage() // damage method
    {
        if (currentHealth > 0) // if the current health is greater than 0 (ensures the
                               // player is not dead)
            currentHealth -= damagePoints; // minuses the value of damagePoints from the
                                           // current health
            healthText.text = "Health " + currentHealth; // updates the outputted health value
            print(currentHealth);
            print("Damaged"); // for validating that the method runs correctly
            HealthBarFiller(); // calls the health bar filler method, to fill the health
                               // bar to the corresponding value of the current health
    }

    public void Heal() // heal method
    {
        if (currentHealth < maxHealth) // if the current health is less than the maximum health
                                       // (ensures the current health never exceeds the maximum
                                       // health)
            currentHealth += healingPoints; // adds the value of healingPoints to the
                                            // current health
            healthText.text = "Health " + currentHealth; // updates the outputted health value
            print("Healed"); // for validating that the method runs correctly
            HealthBarFiller(); // calls the health bar filler method, to fill the health
                               // bar to the corresponding value of the current health
    }
}
