using UnityEngine;
using System.Collections;




public class QuantumSpawner : MonoBehaviour 
{

	public Transform Warning;
	public Transform Asteroid;
	public GameObject WarningField;
	public GameObject AsteroidClone;
	public Rigidbody AstRigid;
	public int maxAst = 10; //max # of Asteroids
	public int currentAst = 0; //current # of Asteroids
	public int currentWarning = 0; //current # of Asteroids
	public int minAstSize = 100; //min Ast size
	public int maxAstSize = 150; //max Ast size
	public int maxAstTorq = 100; //max Ast Torq
	public const int maxSpawnRadius = 50; //max radius at which Asteroids spawn
	private Quaternion astRotation;
	private Vector3 astSpawn;
	private float warningSize; 
	private float astSize;
	private float astWarnBuffer = 1.08F;
	private int astTorqX;
	private int astTorqY;
	private int astTorqZ;
	private int spawnLocX;
	private int spawnLocY;
	private int spawnLocZ;

	// Use this for initialization
	void Start ()
	{
	}

	void Update ()
	{

	}

	void FixedUpdate ()
	{
		if (currentAst <= maxAst) 
		{
			if (currentWarning < currentAst + 1) 
			{
				SpawnWarning ();
				currentWarning = currentWarning + 1;
			}
		}
	}

	void SpawnWarning ()
	{
		astSize = Random.Range(minAstSize, maxAstSize); //establish ASTEROID radius

		astRotation.Set(7, 15, 22, 3); //Sets an initial Asteroid Rotation (Should be randomized in the future)

		warningSize = astSize * astWarnBuffer;

		spawnLocX = Random.Range (-maxSpawnRadius, maxSpawnRadius); //spawn at random X position
		spawnLocY = Random.Range (-maxSpawnRadius, maxSpawnRadius); //spawn at random Y position
		spawnLocZ = Random.Range (-maxSpawnRadius, maxSpawnRadius); //spawn at random Z position

		astSpawn.Set (spawnLocX, spawnLocY, spawnLocZ); //randomly assigns ASTEROID spawn position

		Warning.localScale = new Vector3 (warningSize, warningSize, warningSize); // sets the size of the WARNING
		Asteroid.localScale = new Vector3 (astSize, astSize, astSize); //sets the size of the ASTEROID

		GameObject clone = (GameObject)Instantiate (WarningField, astSpawn, transform.rotation); //Spawns Warning Clone
		Destroy(clone, 2.2f); //Destroys Warning Clone
		Invoke ("SpawnAsteroid", 2);

	}

	void SpawnAsteroid()
	{
		GameObject astClone = (GameObject)Instantiate (AsteroidClone, astSpawn, astRotation); // Spawn Asteroid Clone

<<<<<<< HEAD

		astTorqX = Random.Range (-maxAstTorq, maxAstTorq); //establish random X-axis Torque
		astTorqY = Random.Range (-maxAstTorq, maxAstTorq); //establish random Y-axis Torque
		astTorqZ = Random.Range (-maxAstTorq, maxAstTorq); //establish random Z-axis Torque
		AstRigid.AddRelativeTorque (transform.forward * astTorqX); //Apply established Torques
		AstRigid.AddRelativeTorque (transform.up * astTorqY); //Apply established Torques
		AstRigid.AddRelativeTorque (transform.right * astTorqZ); //Apply established Torques

		Destroy(astClone, 20f); //Destroy Asteroid Clone
		currentAst++; // Adds 1 to Asteroid Number
	}
=======
		astTorqX = Random.Range (-maxAstTorq, maxAstTorq); //establish random X-axis Torque
		astTorqY = Random.Range (-maxAstTorq, maxAstTorq); //establish random Y-axis Torque
		astTorqZ = Random.Range (-maxAstTorq, maxAstTorq); //establish random Z-axis Torque
		AstRigid.AddRelativeTorque (transform.forward * astTorqX); //Apply established Torques
		AstRigid.AddRelativeTorque (transform.up * astTorqY); //Apply established Torques
		AstRigid.AddRelativeTorque (transform.right * astTorqZ); //Apply established Torques

		Destroy(astClone, 20f); //Destroy Asteroid Clone
		currentAst++; // Adds 1 to Asteroid Number
	}

>>>>>>> tony
}