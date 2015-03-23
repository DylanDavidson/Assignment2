using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerPart2 : MonoBehaviour
{
		public Vector3 target;
		private NavMeshAgent agent;
		public LineRenderer line;
		public bool setStart = false;

		void Start ()
		{
				agent = GetComponent<NavMeshAgent> ();
				line = GetComponent<LineRenderer> ();
		}

		void Update ()
		{
				// Use Vector3.zero as default target, do nothing if target is not set
				if (!target.Equals (Vector3.zero)) {
						Ray ray = Camera.main.ScreenPointToRay (target);
						RaycastHit hit;
						// Looks to see where the player clicked, and what it collides with
						if (Physics.Raycast (ray, out hit)) {
								// Ensures player clicked on an open ground spot, not a wall
								if (hit.collider.gameObject.CompareTag ("Ground")) {
										// If player has already set the source, then draw path
										if (setStart) {
												agent.SetDestination (hit.point);
												NavMeshPath path = new NavMeshPath ();
												agent.CalculatePath (hit.point, path);
												agent.Stop (); // Prevents player from moving
												DrawPath (path);
												setStart = false;
												target = Vector3.zero;
										// Player has not set source, set source to clicked position
										} else {	
												// Disable the NavMeshAgent to allow player to move through walls temporarily
												agent.enabled = false;
												transform.position = hit.point;
												agent.enabled = true;
												// Prevent line from being drawn
												line.SetVertexCount (1);
												line.SetPosition (0, transform.position);
												setStart = true;
												target = Vector3.zero;
										}
								}
						}         
				}	
		}

		// Method to draw a Line on screen with path from player to destination using NavMeshPath
		void DrawPath (NavMeshPath path)
		{
				line.SetVertexCount (path.corners.Length);
				for (int i = 0; i < path.corners.Length; i++) {
						line.SetPosition (i, path.corners [i]);
				}
		}
}
