using UnityEngine;
using System.Collections;

public class Tank_Follow : MonoBehaviour {

    private Transform tankTransform;
    private Rigidbody tankRigidbody;
    private Vector3 tankUp;
    private float tankMass;
    private Vector3 tankForward;
    private Vector3 rotationAmt;

    private Vector3 acceleration;
    private float throttle;
    private float deadZ;
    private Vector3 myRight;
    private Vector3 velocity;
    private Vector3 fltVel;
    private Vector3 relVel;
    private Vector3 direction;
    private Vector3 fltDir;
    private Vector3 turnVector;
    private Vector3 impulse;
    private float revolutions;
    private float actTurn;
    private Vector3 tankForce;

    private Transform[] trackTransform = new Transform[4];

    private float actGrip;
    private float horiz;
    private float maxSpdTurn = 10;

    public Transform frontLeft;
    public Transform frontRight;
    public Transform rearLeft;
    public Transform rearRight;
    public Transform LFTransform;
    public Transform RFTransform;

    public float Power;
    public float Max_Speed;
    private float grip = 150;
    public float turnSpd = 1;
    private float slideSpd;
    private float currentSpd;

    private Vector3 tankRight;
    private Vector3 tankFwd;
    private Vector3 tempVector;


    // Use this for initialization
    void Start()
    {

        tankTransform = transform;
        tankRigidbody = GetComponent<Rigidbody>();
        tankUp = tankTransform.up;
        tankMass = GetComponent<Rigidbody>().mass;
        tankForward = Vector3.forward;
        tankRight = Vector3.right;
        setupTracks();

    }

    // Update is called once per frame
    void Update()
    {
        tankPhysics();
        inputListener();

    }

    void LateUpdate()
    {
        rotateTracks();

    }

    void setupTracks()
    {
        if (frontLeft == null || frontRight == null || rearLeft == null || rearRight == null)
        {
            Debug.Break();
        }
        else
        {
            trackTransform[0] = frontLeft;
            trackTransform[1] = rearLeft;
            trackTransform[2] = frontRight;
            trackTransform[3] = rearRight;
        }
    }

    void rotateTracks()
    {
        LFTransform.localEulerAngles = new Vector3(0, (horiz * 45), 0);
        RFTransform.localEulerAngles = new Vector3(0, (horiz * 45), 0);

        rotationAmt = tankRight * (relVel.z * (float)1.6 * Time.deltaTime * Mathf.Rad2Deg);

        trackTransform[0].Rotate(rotationAmt);
        trackTransform[1].Rotate(rotationAmt);
        trackTransform[2].Rotate(rotationAmt);
        trackTransform[3].Rotate(rotationAmt);

    }

    void inputListener()
    {
        horiz = 0; // Hard coded turning key press
        throttle = 1; // Hard coded velocity key press

    }

    void tankPhysics()
    {
        myRight = tankTransform.right;
        velocity = tankRigidbody.velocity;
        tempVector = new Vector3(velocity.x, 0, velocity.z);
        fltVel = tempVector;
        direction = transform.TransformDirection(tankForward);
        tempVector = new Vector3(direction.x, 0, direction.z);
        fltDir = Vector3.Normalize(tempVector);
        relVel = tankTransform.InverseTransformDirection(fltVel);
        slideSpd = Vector3.Dot(myRight, fltVel);
        currentSpd = fltVel.magnitude;
        revolutions = Mathf.Sign(Vector3.Dot(fltVel, fltDir));
        tankForce = (fltDir * (Power * throttle) * tankMass);
        actTurn = horiz;

        if (revolutions < 0.1)
        {
            actTurn = -actTurn;
        }

        turnVector = (((tankUp * turnSpd) * actTurn) * tankMass) * 800;
        actGrip = Mathf.Lerp(100, grip, currentSpd * (float)0.02);
        impulse = myRight * (-slideSpd * tankMass * actGrip);

    }


    void slowVelocity()
    {
        tankRigidbody.AddForce(-fltVel * (float)0.8);
    }


    void FixedUpdate()
    {
        if (currentSpd < Max_Speed)
        {
            tankRigidbody.AddForce(tankForce * Time.deltaTime);
        }
        if (currentSpd > maxSpdTurn)
        {
            tankRigidbody.AddTorque(turnVector * Time.deltaTime);
        }
        else if (currentSpd < maxSpdTurn)
        {
            return;
        }

        tankRigidbody.AddForce(impulse * Time.deltaTime);
    }
 }
