using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideMeshOnPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

      gameObject.SetActive(false); // used to disable the single mesh
      //chunk when the game is played, so that the whole map is visible
      // without the single mesh chunk getting in the way.

    }

}
