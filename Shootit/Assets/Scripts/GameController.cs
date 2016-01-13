using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour {

	public GameObject _ballPrefab;
	public Transform spawnPoint;
	public Transform[] allSpawnPoints;
	public int maxNumberOfBalls;
	public Material[] ballColors;			//possible colors of the ball array



	// Use this for initialization
	void Start () {
		

		GameObject[] tempSpawn = GameObject.FindGameObjectsWithTag("BallSpawn");		//get all spawn points

		allSpawnPoints = new Transform[tempSpawn.Length];
		maxNumberOfBalls = (int)tempSpawn.Length;										//set maximum number of target balls to the number of swawn points availilable

		for(int i = 0; i <= (tempSpawn.Length -1); ++i)
		{
		Transform tempTran = tempSpawn[i].transform;	
		allSpawnPoints[i] = tempTran;
		}
		PlaceBalls();


	
	}

	// Update is called once per frame
	void FixedUpdate () 
	{ 
		
		
		
	}

//	void PickSpawnPoint()
//	{
//
//		spawnPoint = allSpawnPoints[((int)Random.Range(0, allSpawnPoints.Length))];
//
//	}

	void PlaceBalls()
	{
		List<Transform> freeSpawnPoints = new List<Transform>(allSpawnPoints);

		for(int i = 0; i <= maxNumberOfBalls - 1; ++i)
		{
			if (freeSpawnPoints.Count <=0)
            return; // Not enough spawn points

			int index = Random.Range(0, freeSpawnPoints.Count);
			Transform pos = freeSpawnPoints[index];
			freeSpawnPoints.RemoveAt(index); // remove the spawnpoint from our temporary list

			GameObject tBallInstance =  Instantiate(_ballPrefab, pos.position, pos.rotation)as GameObject;
			tBallInstance.GetComponent<Renderer>().material = ballColors[ Random.Range(0, ballColors.Length)];

		}
	
	}


}




        


