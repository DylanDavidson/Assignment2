using UnityEngine;
using System.Collections;

public class WallSensor : MonoBehaviour {
	
	public float range;
	private float distanceForward;
	private float distanceRight;
	private float distanceLeft;
	private Vector2 rightVector;
	private RaycastHit2D forwardSensor;
	private RaycastHit2D rightSensor;

	//private Quaternion leftAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
	
	// Update is called once per frame
	void FixedUpdate () {

		rightVector = new Vector2(transform.up.y * Mathf.Tan(45), transform.up.y).normalized;

		forwardSensor = Physics2D.Raycast (transform.position,
		                                   transform.up, 
		                                   range, 
		                                   1 << LayerMask.NameToLayer("Walls"));

		rightSensor = Physics2D.Raycast (transform.position,
		                                 rightVector,
		                                 range, 
		                                 1 << LayerMask.NameToLayer("Walls"));
		/*
		RaycastHit2D leftSensor = Physics2D.Raycast (transform.position,
		                                             leftAngle,
		                                             range, 
		                                             1 << LayerMask.NameToLayer("Walls"));*/
		if (forwardSensor.collider != null) {
			distanceForward = Vector2.Distance(forwardSensor.point, transform.position);
			Debug.Log ("Forward Distance: " + distanceForward);
			Debug.DrawRay (transform.position, transform.up * distanceForward, Color.red);
		} else {
			Debug.DrawRay (transform.position, transform.up * 1f, Color.red);
		}

		if(rightSensor.collider != null)
		{
			distanceRight = Vector2.Distance(rightSensor.point, transform.position);
			Debug.Log("Right Distance: " + distanceRight);
			Debug.DrawRay (transform.position, rightVector * distanceRight, Color.green);
		} else {
			Debug.DrawRay (transform.position, rightVector * distanceRight, Color.green);
		}

		/*if(leftSensor.collider != null)
		{
			distanceLeft = Mathf.Abs(leftSensor.point.y - transform.position.y);
			Debug.Log("Left Distance: " + distanceLeft);
			Debug.DrawRay (transform.position, leftAngle, Color.yellow);
		}*/

	}
}
