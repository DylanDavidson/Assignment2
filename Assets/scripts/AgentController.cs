using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {
	public Transform agent;
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			mousePos.z = 0;
			Instantiate(agent, mousePos, Quaternion.identity);
		}
		if (Input.GetMouseButtonDown (1)) {
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			Vector2 v2 = new Vector2(mousePos.x, mousePos.y);
			Collider2D collidedObj = Physics2D.OverlapPoint(v2);
			if(collidedObj != null && collidedObj.gameObject.CompareTag("agent")) {
				Destroy(collidedObj.gameObject);
			}
		}
	}
}
