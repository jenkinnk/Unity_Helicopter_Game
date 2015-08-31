using UnityEngine;
using System.Collections;

public class Game_Quit : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit(); // Turn off the game
        }

    }
}
