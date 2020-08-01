 using System;
 using UnityEngine;
 
 public class MouseLook : MonoBehaviour
 {
     public float mouseSensitivity = 100.0f;
     public float clampAngle = 80.0f;
	 
	 public bool x = true;
	 public bool y = true;
 
     private float rotY = 0.0f; // rotation around the up/y axis
     private float rotX = 0.0f; // rotation around the right/x axis
	 
 
     void Start ()
     {
         Vector3 rot = transform.localRotation.eulerAngles;
         rotY = rot.y;
         rotX = rot.x;
     }
 
     void Update ()
     {
         float mouseX = Input.GetAxis("Mouse X");
         float mouseY = -Input.GetAxis("Mouse Y");
 
		 if (x)
         rotY += mouseX * mouseSensitivity;
	 
		 if (y) {
			 rotX += mouseY * mouseSensitivity;
			 rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
		 }
 
		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
	 
        transform.rotation = localRotation;
     }
 }