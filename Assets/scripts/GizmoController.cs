using UnityEngine;
using System.Collections;

public class GizmoController : MonoBehaviour {

	private PlayerController playerController;
	void Start() {
		playerController = transform.parent.GetComponent<PlayerController> ();
	}

	void OnDrawGizmos() {
		if (playerController == null)
						return;
		int total = playerController.numWalls + playerController.numAgents;
		if (total == 0)
			Gizmos.color = Color.green;
		else if (total < 3)
			Gizmos.color = Color.yellow;
		else
			Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, 0.75f);
	}
}
