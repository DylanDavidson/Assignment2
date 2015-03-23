using UnityEngine;
using System.Collections;

public class AgentControllerPart3 : MonoBehaviour
{
		public Transform agent;
		public PlayerControllerPart3 playerController;
	
		void Start ()
		{
				playerController = GameObject.Find ("Player").GetComponent<PlayerControllerPart3> ();
		}

		void Update ()
		{
				// if user clicks, set the players destination to where they clicked
				if (Input.GetMouseButtonDown (0)) {
						Vector3 mousePos = Input.mousePosition;
						playerController.target = mousePos;
				}
		}
}
