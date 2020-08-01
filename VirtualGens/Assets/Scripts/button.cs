using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
	public string buttonName;
	public KeyCode keyCode;
	public float deep;
	
	public float timeToReturn = 0.5f;
	private float ttReturn;
	private bool dpad;
	
    // Start is called before the first frame update
    void Start()
    {
        ttReturn = timeToReturn;
    }

    // Update is called once per frame
    void Update()
    {
		
        if(buttonName.Equals("Any")) {
			if(!dpad&&(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) ||
			    Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M) ||
			    Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.F)) {
				
				ttReturn = timeToReturn;
				transform.localPosition = new Vector3(0, deep, 0);
			}

			if(ttReturn > 0) {
				ttReturn -= Time.deltaTime;
			}
			else {
				transform.localPosition = new Vector3(0, 0, 0);
			}
		
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
				dpad = true;
			else
				dpad = false;
		}
		else {
			if(Input.GetKey(keyCode)) {
				transform.localPosition = new Vector3(0, deep, 0);
			}
			else {
				transform.localPosition = new Vector3(0, 0, 0);
			}
		}
    }
}
