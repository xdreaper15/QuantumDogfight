using UnityEngine;
using System.Collections;




public class QuantumSpawner : MonoBehaviour 
{

	public Transform Warning;
	public Transform Asteroid;
	public GameObject WarningField;
	public GameObject AsteroidClone;
	public int maxAst = 10; //max # of Asteroids
	public int currentAst = 0; //current # of Asteroids
	public int currentWarning = 0; //current # of Asteroids
	public int minAstSize = 100; //min Ast size
	public int maxAstSize = 150; //max Ast size
	public int maxSpawnRadius = 50; //max radius at which Asteroids spawn
	private Quaternion astRotation;
	private Vector3 astSpawn;
	private float warningSize;
	private float astSize;
	private float astWarnBuffer = 1.08F;
	private int spawnLocX;
	private int spawnLocY;
	private int spawnLocZ;
	private int arg1;

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
				SpawnWarning ("test");
				currentWarning = currentWarning + 1;
			}
		}
	}

	void SpawnWarning (string arg1)
	{
		arg1 = "Warning Zone: " + currentAst;
		astSize = Random.Range(minAstSize, maxAstSize); //establish ASTEROID radius
		astRotation.Set(7, 15, 22, 3);
		warningSize = astSize * astWarnBuffer;

		spawnLocX = Random.Range (-50, 50); //spawn at random X position
		spawnLocY = Random.Range (-50, 50); //spawn at random Y position
		spawnLocZ = Random.Range (-50, 50); //spawn at random Z position

		astSpawn.Set (spawnLocX, spawnLocY, spawnLocZ); //randomly assigns ASTEROID spawn position

		Warning.localScale = new Vector3 (warningSize, warningSize, warningSize); // sets the size of the WARNING
		Asteroid.localScale = new Vector3 (astSize, astSize, astSize); //sets the size of the ASTEROID

		GameObject clone = (GameObject)Instantiate (WarningField, astSpawn, transform.rotation);
		//Instantiate (Warning, astSpawn, transform.rotation); // spawns WARNING
		Destroy(clone, 2.2f);
		Invoke ("SpawnAsteroid", 2);

	}

	void SpawnAsteroid()
	{
		GameObject astClone = (GameObject)Instantiate (AsteroidClone, astSpawn, astRotation);
//		GameObject astClone = (GameObject)Instantiate (Asteroid, astSpawn, transform.rotation); //spawn ASTEROID
		Destroy(astClone, 20f);
		currentAst++;
	}
		
}




