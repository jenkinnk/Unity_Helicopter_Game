using UnityEngine;
using System.Collections;

public class Detect_Shell_Collision : MonoBehaviour {

    //public GameObject barrel;
    //public Collider shellSource;
    void Start()
    {
        Destroy(gameObject, 1.0f); // Destroy yourself after one second
    }

}
