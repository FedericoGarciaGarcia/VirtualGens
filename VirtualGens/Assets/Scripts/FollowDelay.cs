using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDelay : MonoBehaviour
{
	public Transform target;
	public float speed = 1;
	
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position    = (target.position+transform.position)/2;
        //transform.eulerAngles = target.eulerAngles;
		
		// The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.forward, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
		
		// Move our position a step closer to the target.
        /*float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);*/
    }
}
