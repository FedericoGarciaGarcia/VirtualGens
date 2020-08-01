using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonRotateGamepad : MonoBehaviour
{
	public float rotX = 1;
	public float rotY = 0;
	public float rotZ = 0;
	
	private bool dpad;
	private bool button;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dpad   = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow);
		button = Input.GetKey(KeyCode.A);
		
		Vector3 target;
		
		if(dpad && button)
			target = new Vector3(0, 0, 0);
		else if(dpad)
			target = new Vector3(rotX, rotY, rotZ);
		else if(button)
			target = new Vector3(-rotX, -rotY, -rotZ);
		else
			target = new Vector3(0, 0, 0);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.localEulerAngles  = (target+transform.localEulerAngles)/2;
    }
}
