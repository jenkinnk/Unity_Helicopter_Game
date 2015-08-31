using UnityEngine;
using System.Collections;

public class Tank_Shoot : MonoBehaviour {

    public Transform target;
    public float rotationSpeed = 3;
    public Transform myTransform;
    public GameObject sniperShell;
    public Transform spawnPoint;
    private GameObject newBullet;
    public float firingRate;

    public float firingRange = 100;
    //private bool inRange;


    public static Tank_Shoot instance;

	// Use this for initialization
	void Start () {
        target = GameObject.FindWithTag("Player").transform;
        myTransform = transform;
        instance = this;
        instance.InvokeRepeating("TankShoot", 1.0f, firingRate);
	}
	
	// Update is called once per frame
	void Update () {
        var lookDir = target.position - myTransform.position;
        lookDir.y = 0; 
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(lookDir), rotationSpeed * Time.deltaTime); 
	}


    void TankShoot() //Produce a new tank shell and fire it at the enemy
    {

        newBullet = Instantiate(sniperShell, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(new Vector3(0, 0, 100));
        newBullet.AddComponent<Detect_Shell_Collision>();
    }
}
