﻿using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {
	public Transform agent;
	// Update is called once per frame
	public PlayerController playerController;
	
	void Start() {
		playerController = GameObject.Find("Player").GetComponent<PlayerController> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePos = Input.mousePosition;
			mousePos = Camera.main.ScreenToWorldPoint(mousePos);
			mousePos.z = 0;
			playerController.target = mousePos;
		}
	}
}
