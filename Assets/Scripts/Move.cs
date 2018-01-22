using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour {

	//private Rigidbody rb;
	public float thrust = 1;
	public float pitch;
	public float yaw;
	public float roll;
	public float boost;
	Vector3 gas;
	[SerializeField]float speed = 1;
	[SerializeField]float YawSensitivity = 1;
	[SerializeField]float TiltSensitivity = 1;
	[SerializeField]float PitchSensitivity = 1;
	[SerializeField]float StrafeSensitivity = 1;
	[SerializeField]float ThrustMod = .6f;
	public Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		
		pitch = Input.GetAxis("Vertical");
		roll = Input.GetAxis("Horizontal");
		yaw = Input.GetAxis ("Strafe");
		rb.AddRelativeTorque(pitch * PitchSensitivity, 0, -roll * StrafeSensitivity);
		rb.AddRelativeForce (yaw * YawSensitivity, 0, 0);

		thrust = Input.GetAxis ("Thrust");
		rb.velocity = transform.forward * thrust * ThrustMod;


	}
}
