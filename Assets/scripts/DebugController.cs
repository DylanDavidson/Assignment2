using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DebugController : MonoBehaviour {

	public Text position;
	public Text heading;
	public Text adjacentAgents;
	public PlayerController playerController;

	void Start() {
		playerController = gameObject.GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void updatePlayerPosition() {
		string degrees = transform.eulerAngles.z.ToString ("F2");
		string x = transform.position.x.ToString ("F2");
		string y = transform.position.y.ToString ("F2");
		position.text = "Position: (" + x + ", " + y + ")";
		heading.text = "Heading: " + degrees + "°";	
	}

	void updateAdjacentSensor() {
		adjacentAgents.text = "";
		foreach (GameObject g in playerController.adjacentAgents) {
			adjacentAgents.text += "Distance: ";
			adjacentAgents.text += Vector3.Distance(transform.position, g.transform.position).ToString("F2");
			Vector3 targetDir = g.transform.position - transform.position;
			adjacentAgents.text += ", Heading: " + Vector3.Angle(targetDir, transform.up).ToString("F2") + "°\n";
		}
	}

	void Update () {
		updatePlayerPosition ();
		updateAdjacentSensor ();
	}
}
