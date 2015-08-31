using UnityEngine;
using System.Collections;

public class Picked_Up_By_Helicopter_Detect : MonoBehaviour {

    public GameObject helicopter;

    // Wounded solider detects if the helicopter has come in contact with him
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == helicopter)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
        }

    }
}
