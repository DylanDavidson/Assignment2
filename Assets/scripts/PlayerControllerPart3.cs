using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControllerPart3 : MonoBehaviour
{
		public float movementSpeed = 2f;
		public Vector3 target;
		private NavMeshAgent agent;
		public LineRenderer line;
		public bool started = false;

		void Start ()
		{
				agent = GetComponent<NavMeshAgent> ();
				line = GetComponent<LineRenderer> ();
		}

		void Update ()
		{
				// Use Vector3.zero as default target, do nothing if target is not set
				if (!target.Equals (Vector3.zero)) {
						// If player has completed the path, reset variables, and stop movement
						if (started && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0) {
								target = Vector3.zero;
								started = false;
								agent.Stop ();
						} else {
								// Moves player to clicked point
								Ray ray = Camera.main.ScreenPointToRay (target);
								RaycastHit hit;
								if (Physics.Raycast (ray, out hit)) {
										// Ensures clicked point was an open ground spot
										if (hit.collider.gameObject.CompareTag ("Ground")) {
												agent.SetDestination (hit.point);
												started = true;
										}
								}     
						}
				} else {
						// Player movement controls, only allows if not currently pathfinding
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
}
