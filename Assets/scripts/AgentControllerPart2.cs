using UnityEngine;
using System.Collections;

public class AgentControllerPart2 : MonoBehaviour {
	public Transform agent;
	// Update is called once per frame
	public PlayerControllerPart2 playerController;
	
	void Start() {
		playerController = GameObject.Find("Player").GetComponent<PlayerControllerPart2> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Input.mousePosition;
			playerController.target = mousePos;
		}
	}
}
