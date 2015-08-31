using UnityEngine;
using System.Collections;

public class Helicopter_Shoot : MonoBehaviour {

    private Transform target;
    //public int rotationSpeed = 3;
    public Transform myTransform;
    public GameObject helicopterShell;
    public Transform spawnPoint;
    private GameObject newBullet;

    // Use this for initialization
    void Start()
    {
        spawnPoint = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HeliShoot(); // Fire!
        }

    }

    void HeliShoot() // Produce a new helicopter shell
    {
        newBullet = Instantiate(helicopterShell, transform.position, transform.rotation) as GameObject;
        newBullet.GetComponent<Rigidbody>().velocity = spawnPoint.TransformDirection(new Vector3(0, 0, 100));
        newBullet.AddComponent<Detect_Shell_Collision>();
    }
}
