using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamepad : MonoBehaviour
{
	public float dpadRotSpeed = 8;
	public float dpadRotMax = 8;
	
	float dpadRotX;
	float dpadRotY;

	void Start() {
		dpadRotX = 0;
		dpadRotY = 0;
	}
	
	void Update()  {

		if(Input.GetKey(KeyCode.LeftArrow)) {
			
			dpadRotX += dpadRotSpeed * Time.deltaTime;
				
			if(dpadRotX > dpadRotMax)
				dpadRotX = dpadRotMax;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			
			dpadRotX -= dpadRotSpeed * Time.deltaTime;
				
			if(dpadRotX < -dpadRotMax)
				dpadRotX = -dpadRotMax;
		}
		else {
			if(dpadRotX < 0) {
				dpadRotX += dpadRotSpeed * Time.deltaTime;
				
				if(dpadRotX > 0)
					dpadRotX = 0;
			}
			else if(dpadRotX > 0)  {
				dpadRotX -= dpadRotSpeed * Time.deltaTime;
				
				if(dpadRotX < 0)
					dpadRotX = 0;
			}
		}
		
		if(Input.GetKey(KeyCode.DownArrow)) {
			
			dpadRotY += dpadRotSpeed * Time.deltaTime;
				
			if(dpadRotY > dpadRotMax)
				dpadRotY = dpadRotMax;
		}
		else if(Input.GetKey(KeyCode.UpArrow)) {
			
			dpadRotY -= dpadRotSpeed * Time.deltaTime;
				
			if(dpadRotY < -dpadRotMax)
				dpadRotY = -dpadRotMax;
		}
		else {
			if(dpadRotY < 0) {
				dpadRotY += dpadRotSpeed * Time.deltaTime;
				
				if(dpadRotY > 0)
					dpadRotY = 0;
			}
			else if(dpadRotY > 0)  {
				dpadRotY -= dpadRotSpeed * Time.deltaTime;
				
				if(dpadRotY < 0)
					dpadRotY = 0;
			}
		}
		
		transform.localEulerAngles = new Vector3(dpadRotY, 0, dpadRotX);
	}
}
