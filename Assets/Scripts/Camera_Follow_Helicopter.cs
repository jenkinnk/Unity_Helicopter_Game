using UnityEngine;
using System.Collections;

public class Camera_Follow_Helicopter : MonoBehaviour {

    public GameObject helicopter;
	
	void Update () {

        // Look at the helicopter
        transform.LookAt(helicopter.transform);

	}


}
