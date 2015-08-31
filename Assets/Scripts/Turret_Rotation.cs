using UnityEngine;
using System.Collections;

public class Turret_Rotation : MonoBehaviour {

    public Transform turretTransform;
    public Transform target;
    public float rotationSpeed = 3;

	// Update is called once per frame
	void Update () {

        var lookDir = target.position - turretTransform.position; // Find the angle of the helicopter
        lookDir.y = 0; 
        turretTransform.rotation = Quaternion.Slerp(turretTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime);  // Turn towards the helicopter
	
	}
}
