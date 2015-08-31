using UnityEngine;
using System.Collections;

public class Sniper_Shoot : MonoBehaviour {

    public Transform target;
    public float rotationSpeed = 3;
    public Transform myTransform;
    public GameObject sniperShell;
    public Transform spawnPoint;
    private GameObject newBullet;
    public float firingRate;

    //private float timer = 5.0f;
    public static Sniper_Shoot instance;

    // Use this for initialization
    void Start(){

        target = GameObject.FindWithTag("Player").transform;
        myTransform = transform;
        instance = this;
        instance.InvokeRepeating("SniperShoot", 1.0f, firingRate);

    }

    // Update is called once per frame
    void Update(){
        myTransform.LookAt(target); //Look at the helicopter
        spawnPoint.LookAt(target); // Look at the helicopter
    }


    void SniperShoot() // Produce a new sniper shell and give a velocity of 100
    {
        newBullet = Instantiate(sniperShell, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(new Vector3(0, 0, 100));
        newBullet.AddComponent<Detect_Shell_Collision>();
    }

}
