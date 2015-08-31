using UnityEngine;
using System.Collections;

public class Game_Reset : MonoBehaviour {


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(0); // Reset the level
        }
	
	}
}
