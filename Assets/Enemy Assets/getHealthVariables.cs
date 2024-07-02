using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHealthVariables : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      float currentHealth = gameObject.GetComponent<playerHealth>().currentHealth;
      float damagePoints = gameObject.GetComponent<playerHealth>().damagePoints;

    }

    public void DamageMethod() {

      gameObject.GetComponent<playerHealth>().Damage();

    }
}
