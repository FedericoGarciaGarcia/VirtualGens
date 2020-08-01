using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float force = 1.0f;
	public float jumpForce = 1.0f;
	public Transform camera;
	public float smoothCrouch = 1;
	
	private Rigidbody rigidbody;
	private bool crouching;
	private Vector3 crouchPosition = new Vector3(0, 0, 0);
	private Vector3 cameraposition;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		
		cameraposition = camera.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vf = new Vector3(camera.forward.x, 0, camera.forward.z);
		Vector3 vr = new Vector3(camera.right.x,   0, camera.right.z);
		//rigidbody.AddForce(camera.right * Input.GetAxis("Horizontal") * force);
		//rigidbody.velocity = camera.right * Input.GetAxis("Horizontal") * force;
		rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		rigidbody.velocity += vf * Input.GetAxis("Vertical")   * force;
		rigidbody.velocity += vr * Input.GetAxis("Horizontal") * force;
		
		/*rigidbody.AddForce(vf * Input.GetAxis("Vertical") * force);
		
        if (Input.GetKeyDown("space"))
			rigidbody.AddForce(Vector3.up * jumpForce);*/
		
		if (Input.GetButtonDown("Crouch"))
		{
			crouching = !crouching;
		}

		if(crouching) {
			rigidbody.velocity /= 2;
			camera.localPosition = Vector3.Lerp(camera.localPosition, crouchPosition, Time.deltaTime * smoothCrouch);
		}
		else {
			camera.localPosition = Vector3.Lerp(camera.localPosition, cameraposition, Time.deltaTime * smoothCrouch);
		}
	}
}
