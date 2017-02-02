using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {

	public Transform current; // Just gets a world position + rotation for current
	public Transform next; // Just gets a world position + rotation for next

	public float rollRatio = 40f; // How many degrees of roll to add in when we have to do a turn. I guessed.

	void Start ()
	{
	
	}
	
	void Update ()
	{
		// Dot product our current rotation's left vector with our next rotation's forward vector
		float turnFactor = Vector3.Dot((current.rotation * Vector3.left),(next.rotation * Vector3.forward));

		// Maybe print this for testing?
		// Debug.Log(turnFactor);


		// Generate a rotation that would be a roll around the forward vector based on how out of line we are turning;
		Quaternion modRotation = Quaternion.Euler(Vector3.forward * (turnFactor * this.rollRatio));

		// Modify our plane's rotation to by this amount;
		transform.rotation = current.rotation * modRotation;

		// Just for my test scene:
		// always put the next node in a line from the current facing
		next.transform.position = current.transform.position + current.transform.rotation * Vector3.forward * 3;

	}
}
