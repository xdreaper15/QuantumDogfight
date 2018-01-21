using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

	private Rigidbody rb;
	[SerializeField]float speed = 10;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();

	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, 0);
		Vector3 rotation = new Vector3 (0, 0, moveVertical);
		rb.AddForce (movement * speed);
		rb.AddRelativeTorque (rotation * speed);

	}
}
