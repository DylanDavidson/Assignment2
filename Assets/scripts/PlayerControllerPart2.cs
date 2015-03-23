using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerPart2 : MonoBehaviour {
	public Light spotlight;
	public float movementSpeed = 2f;
	public float autoMoveSpeed = 5f;
	public List<GameObject> adjacentAgents = new List<GameObject>();
	public Vector3 target;
	private NavMeshAgent agent;
	public LineRenderer line;
	public bool setStart = false;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
		line = GetComponent<LineRenderer> ();
	}

	void Update () 
	{
		if (!target.Equals(Vector3.zero)) {
			if(target.Equals(transform.position)) {
				target = Vector3.zero;
				return;
			}
			Ray ray = Camera.main.ScreenPointToRay(target);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				if(hit.collider.gameObject.CompareTag("Ground")) {
					if(setStart) {
						agent.SetDestination(hit.point);
						NavMeshPath path = new NavMeshPath();
						agent.CalculatePath(hit.point, path);
						agent.Stop ();
						DrawPath(path);
						setStart = false;
						target = Vector3.zero;
					}
					else {	
						agent.enabled = false;
						transform.position = hit.point;
						agent.enabled = true;
						line.SetVertexCount(1);
						line.SetPosition(0, transform.position);
						setStart = true;
						target = Vector3.zero;
					}
				}
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
