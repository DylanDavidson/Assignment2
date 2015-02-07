using UnityEngine;
using System.Collections;

public class WallSensor : MonoBehaviour {
	
	public float range;
	private float distanceForward;
	private float distanceRight;
	private float distanceLeft;
	private Vector2 rightAngle;
	//private Quaternion leftAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//rightAngle = new Vector2 ();
		//leftAngle = new Vector2 ();
		
		
		RaycastHit2D forwardSensor = Physics2D.Raycast (transform.position,
		                                                transform.up, 
		                                                range, 
		                                                1 << LayerMask.NameToLayer("Walls"));/*
		RaycastHit2D rightSensor = Physics2D.Raycast (rightTransform.position,
		                                              rightTransform.up,
		                                              range, 
		                                              1 << LayerMask.NameToLayer("Walls"));/*
		RaycastHit2D leftSensor = Physics2D.Raycast (transform.position,
		                                             leftAngle,
		                                             range, 
		                                             1 << LayerMask.NameToLayer("Walls"));*/
		if(forwardSensor.collider != null)
		{
			distanceForward = Mathf.Abs(forwardSensor.point.y - transform.position.y);
			Debug.Log("Forward Distance: " + distanceForward);
			Debug.DrawRay (transform.position, transform.up, Color.red);
		}
		/*
		if(rightSensor.collider != null)
		{
			distanceRight = Mathf.Abs(rightSensor.point.y - transform.position.y);
			Debug.Log("Right Distance: " + distanceRight);
			Debug.DrawRay (rightTransform.up, rightTransform.up, Color.green);
		}
/*
		if(leftSensor.collider != null)
		{
			distanceLeft = Mathf.Abs(leftSensor.point.y - transform.position.y);
			Debug.Log("Left Distance: " + distanceLeft);
			Debug.DrawRay (transform.position, leftAngle, Color.yellow);
		}*/
	}
}
