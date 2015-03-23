using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public Light spotlight;
	public float movementSpeed = 2f;
	public float autoMoveSpeed = 5f;
	public List<GameObject> adjacentAgents = new List<GameObject>();
	public Vector3 target;

	void Start() {
		GameObject sprite = transform.FindChild("PlayerSprite").gameObject;
	}

	void Update () 
	{
		if (!target.Equals(Vector3.zero)) {
			if(target.Equals(transform.position)) {
				target = Vector3.zero;
				return;
			}

			float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg; 
			Quaternion newRot = Quaternion.Euler(new Vector3(0, 0, angle - 90));
			transform.rotation = Quaternion.Lerp(transform.rotation, newRot, autoMoveSpeed * Time.deltaTime);
			//transform.position += transform.up * 0.05f;
			target.z = 0;
			transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (0f, 0f, -2.5f);
				
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (0f, 0f, 2.5f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += transform.up * Time.deltaTime * movementSpeed;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position -= transform.up * Time.deltaTime * movementSpeed;
		}

		Vector3 pos = transform.position;
		pos.z = -1;
		spotlight.transform.position = pos;
	}
}
