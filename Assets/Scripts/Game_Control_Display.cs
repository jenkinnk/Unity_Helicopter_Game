using UnityEngine;
using System.Collections;

public class Game_Control_Display : MonoBehaviour {

    private string controls;

	// Use this for initialization
	void Start () {
        controls = "F - Switch Camera\nR - Reset Level\nQ - Quit Game";

	}
	
    // Show controls for the user to navigate through the game
    void OnGUI()
    {
        GUI.Label(new Rect(10, 75, 200, 100), controls);

    }
}
