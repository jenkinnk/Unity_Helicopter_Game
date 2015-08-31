using UnityEngine;
using System.Collections;

public class Camera_Switch : MonoBehaviour {

    public Camera Main_Camera;
    public Camera Follow_Camera;
    public Camera Cockpit_Camera;
    public Camera Rescue_Camera;
    private string angle;

	// Use this for initialization
	void Start () {
        Follow_Camera.enabled = true;
        Cockpit_Camera.enabled = false;
        Main_Camera.enabled = false;
        Rescue_Camera.enabled = false;
        angle = "3rd Person View";
        OnGUI();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(Main_Camera.enabled == true) // Behind the helicopter
            {
                Main_Camera.enabled = false;
                Cockpit_Camera.enabled = false;
                Follow_Camera.enabled = true;
                Rescue_Camera.enabled = false;
                angle = "3rd Person View";
                OnGUI();
            }
            else if(Follow_Camera.enabled == true) // Look from inside the helicopter
            {
                Main_Camera.enabled = false;
                Cockpit_Camera.enabled = true;
                Follow_Camera.enabled = false;
                Rescue_Camera.enabled = false;
                angle = "Cockpit View";
                OnGUI();
            }
            else if(Rescue_Camera.enabled == true) // Main view from above
            {
                Main_Camera.enabled = true;
                Cockpit_Camera.enabled = false;
                Follow_Camera.enabled = false;
                Rescue_Camera.enabled = false;
                angle = "Scene View";
                OnGUI();

            }
            else{  // Look down in order to judge where to pick up the wounded soldier
                Main_Camera.enabled = false;
                Cockpit_Camera.enabled = false;
                Follow_Camera.enabled = false;
                Rescue_Camera.enabled = true;
                angle = "Rescue View";
                OnGUI();
            }
        }	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 5, 200, 50), angle);

    }
}
