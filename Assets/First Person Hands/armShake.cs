using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armShake : MonoBehaviour
{

  void Update()
  {

    var speed = 1.0f; //how fast it shakes
    var amount = 1.0f; //how much it shakes


    float x = gameObject.transform.position.x * Mathf.Sin(Time.time * speed) * amount;
    float y = gameObject.transform.position.y;
    float z = gameObject.transform.position.z;

// Then assign a new vector3
  gameObject.transform.position = new Vector3 (x, y, z);
  }
}
