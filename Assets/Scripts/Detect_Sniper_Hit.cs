using UnityEngine;
using System.Collections;

public class Detect_Sniper_Hit : MonoBehaviour {

    // Keep track of the helicopter lives and display it on screen
    // Helicopter has 10 lives and will be decremented with each enemy shell collision

    //public GameObject sniperBullet;
    public int lifeCount = 10;

	// Use this for initialization
	void Start () {

        lifeCount = 10;
        //sniperBullet = gameObject;
	}
	
    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "Enemy Shell")
        {
            --lifeCount;
        }
    }

    void Update()
    {
        OnGUI();
        if (lifeCount <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel(0);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 55, 200, 50), "Player Lives: " + lifeCount);
    }
}
