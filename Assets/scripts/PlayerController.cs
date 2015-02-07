using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
	public float movementSpeed = 2f;
	public int numWalls = 0;
	public int numAgents = 0;

	void Update () 
	{

		if (Input.GetKey (KeyCode.RightArrow)) {
				transform.Rotate (0f, 0f, -2.5f);
				
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
				transform.Rotate (0f, 0f, 2.5f);

		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += transform.up * Time.deltaTime * movementSpeed;

		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position -= transform.up * Time.deltaTime * movementSpeed;

		}


		//Physics2D.CircleCastAll(transform.position, 2, 
	}

	void OnTriggerEnter2D( Collider2D col )
	{
		if (col.gameObject.tag == "agent") 
		{
			numAgents++;

		}

		if (col.gameObject.tag == "wall") 
		{
			numWalls++;
		}

		print ("numAgents: " + numAgents + "\n");
		print ("numWalls: " + numWalls + "\n");

	}

	void OnTriggerExit2D( Collider2D col )
	{
		if (col.gameObject.tag == "agent") 
		{
			numAgents--;

		}

		if (col.gameObject.tag == "wall") 
		{
			numWalls--;
		}

		print ("numAgents: " + numAgents + "\n");
		print ("numWalls: " + numWalls + "\n");
	}
}
