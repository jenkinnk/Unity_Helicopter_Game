using UnityEngine;
using System.Collections;

public class Rotate_Canon : MonoBehaviour {

    public Transform target;
    public Transform canonTransform;
    public float rotationSpeed;

	// Update is called once per frame
	void Update () {

        var lookDir = target.position - canonTransform.position; // Find the helicopter

        // Turn towards the helicopter
        canonTransform.rotation = Quaternion.Slerp(canonTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime);


	}
}
