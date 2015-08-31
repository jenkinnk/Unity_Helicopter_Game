using UnityEngine;
using System.Collections;

public class Detect_Helicopter_Hit : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        // See if you were struck by a helicopter shell
        if (col.gameObject.tag == "Helicopter Shell")
        {
            Destroy(gameObject);
        }


    }
}
