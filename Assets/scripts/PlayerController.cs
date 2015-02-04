using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float movementSpeed = 2f;

	void Update () {
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
	}
}
