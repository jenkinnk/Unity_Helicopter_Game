using UnityEngine;
using System.Collections;

public class BH_Rotor_Movement : MonoBehaviour {

    public GameObject mainRotor;
    public GameObject tailRotor;
    public AudioSource rotorSound;

    static private float maxMainRotorForce = 22241.1081f;
    static private float maxMainRotorVelocity = 7200;
    private float mainRotorVelocity = 0.0f;
    private float mainRotorRotation = 0.0f;
    
    static private float maxTailRotorForce = 15000.0f;
    static private float maxTailRotorVelocity = 2200.0f;
    private float tailRotorVelocity = 0.0f;
    private float tailRotorRotation = 0.0f;

    private float fwdRotorTorqueMult = 0.5f;
    private float lateralRotorTorqueMult = 0.5f;

    static bool mainRotorRunning = true;
    static bool tailRotorRunning = true;

    private Rigidbody heliRigidbody;



    void Start() {
        heliRigidbody = GetComponent<Rigidbody>();
    }

    // Determine the inputs from the user in order to apply the proper physics forces to the helicopter
    void FixedUpdate () {
	    Vector3 torque = new Vector3();
	    Vector3 torqueControl = new Vector3( Input.GetAxis( "Vertical" ) * fwdRotorTorqueMult, 1.0f, -Input.GetAxis( "Horizontal2" ) * lateralRotorTorqueMult );

	    // Pitch the helicopter forward and backwards 
        if ( mainRotorRunning == true ) {
		    torque += (torqueControl * maxMainRotorForce * mainRotorVelocity);
		    heliRigidbody.AddRelativeForce( Vector3.up * maxMainRotorForce * mainRotorVelocity );
		    if (Vector3.Angle( Vector3.up, transform.up) < 80 ) {
			    transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, transform.rotation.eulerAngles.y, 0 ), Time.deltaTime * mainRotorVelocity * 2 );
		    }
	    }

        // Pitch the helicopter left and right
	    if ( tailRotorRunning == true ) {
		    torque -= (Vector3.up * maxTailRotorForce * tailRotorVelocity);
	    }

        // Add the forces to the rigidbody of the helciopter
	    heliRigidbody.AddRelativeTorque( torque );
    }

    void Update () {

        rotorSound.pitch = mainRotorVelocity; // Make the helicopter sound like a real helicopter

	    // Simulate the rotation of the rotors while in flight
        if ( mainRotorRunning == true ) {
		    mainRotor.transform.rotation = transform.rotation * Quaternion.Euler( 0, mainRotorRotation, 0 );
	    }
	    if ( tailRotorRunning == true ) {
		    tailRotor.transform.rotation = transform.rotation * Quaternion.Euler( tailRotorRotation, 0, 0 );
	    }

	    mainRotorRotation += maxMainRotorVelocity * mainRotorVelocity * Time.deltaTime;
	    tailRotorRotation += maxTailRotorVelocity * mainRotorVelocity * Time.deltaTime;

	    float hoverRotorVelocity = (heliRigidbody.mass * Mathf.Abs( Physics.gravity.y ) / maxMainRotorForce);
	    float hoverTailRotorVelocity = (maxMainRotorForce * mainRotorVelocity) / maxTailRotorForce;
	    
        // Add velocity components to the main rotor -- this causes the helicopter to go up and down
	    if ( Input.GetAxis( "Vertical2" ) != 0.0 ) {
		    mainRotorVelocity += Input.GetAxis( "Vertical2" ) * 0.001f;
	    }
        else{
		    mainRotorVelocity = Mathf.Lerp( mainRotorVelocity, hoverRotorVelocity, Time.deltaTime * Time.deltaTime * 5 );
	    }

	    // This will cause the helicopter to turn left and right
        // Simulates the force of the tail rotor changing
        tailRotorVelocity = hoverTailRotorVelocity - Input.GetAxis( "Horizontal" );

	    if ( mainRotorVelocity > 1.0 ) {
		    mainRotorVelocity = 1.0f;
	    }
        else if ( mainRotorVelocity < 0.0 ) {
		    mainRotorVelocity = 0.0f;
	    }
    }
}