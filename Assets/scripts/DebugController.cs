using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {

	public Text position;
	public Text heading;

	// Update is called once per frame
	void Update () {
		string degrees = transform.eulerAngles.z.ToString ("F2");
		string x = transform.position.x.ToString ("F2");
		string y = transform.position.y.ToString ("F2");
		position.text = "Position: (" + x + ", " + y + ")";
		heading.text = "Heading: " + degrees + "°";
	}
}
