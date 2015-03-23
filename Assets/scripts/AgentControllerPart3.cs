using UnityEngine;
using System.Collections;

public class AgentControllerPart3 : MonoBehaviour {
	public Transform agent;
	// Update is called once per frame
	public PlayerControllerPart3 playerController;
	
	void Start() {
		playerController = GameObject.Find("Player").GetComponent<PlayerControllerPart3> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Input.mousePosition;
			playerController.target = mousePos;
		}
	}
}
