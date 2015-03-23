using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerPart3 : MonoBehaviour {
	public Light spotlight;
	public float movementSpeed = 2f;
	public float autoMoveSpeed = 5f;
	public List<GameObject> adjacentAgents = new List<GameObject>();
	public Vector3 target;
	private NavMeshAgent agent;
	public LineRenderer line;
	public bool started = false;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
		line = GetComponent<LineRenderer> ();
	}

	void Update () 
	{
		if (!target.Equals (Vector3.zero)) {
						if (started && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) {
								target = Vector3.zero;
								started = false;
								agent.Stop();
						}
						else {
							Ray ray = Camera.main.ScreenPointToRay (target);
							RaycastHit hit;
							if (Physics.Raycast (ray, out hit)) {
									if (hit.collider.gameObject.CompareTag ("Ground")) {
										agent.SetDestination (hit.point);
										started = true;
									}
							}     
			}
		} else {
			if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (0f, 3f, 0f);
				
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (0f, -3f, 0f);
				
			}
			if (Input.GetKey (KeyCode.UpArrow)) {
				transform.localPosition += transform.forward * Time.deltaTime * movementSpeed;
			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				transform.localPosition -= transform.forward * Time.deltaTime * movementSpeed;
			}
		}
	}

	void DrawPath(NavMeshPath path) {
		line.SetVertexCount (path.corners.Length);
		for(int i = 0; i < path.corners.Length; i++) {
			line.SetPosition(i, path.corners[i]);
		}
	}
}
