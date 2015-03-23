using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour
{
		public Transform agent;
		public PlayerController playerController;
	
		void Start ()
		{
				playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
		}

		void Update ()
		{
				// if user clicks, set the players destination to where they clicked
				if (Input.GetMouseButtonDown (0)) {
						Vector3 mousePos = Input.mousePosition;
						mousePos = Camera.main.ScreenToWorldPoint (mousePos);
						mousePos.z = 0; // Set z-axis to zero, since it is a 2D world
						playerController.target = mousePos;
				}
		}
}
