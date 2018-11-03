//============================================================//
//                  Acrade Mode Manager                      //
//============================================================//
//                  Created: 2017-12-13 5:25 am               //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to manage the survival game mode.                     //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeModeManager : MonoBehaviour
{

	[Header("WayPoints")]
	public GameObject spawnPoint;
	public List<Transform> topWayPoints;
	public List<Transform> secondWayPoints;
	public List<Transform> thirdWayPoints;
	public List<Transform> fourthWayPoints;

    [Header("Enemy Paths")]
    public List<Transform> currentRoute;
	public List<Transform> enemyRoute01;
	public List<Transform> enemyRoute02;
	public List<Transform> enemyRoute03;
	public List<Transform> enemyRoute04;
	public List<Transform> enemyRoute05;
	public List<Transform> enemyRoute06;
	public List<Transform> enemyRoute07;
	public List<Transform> enemyRoute08;
	public List<Transform> enemyRoute09;
	public List<Transform> enemyRoute10;
    public List<Transform> bossRoute;


    [Header("Round Trackers")]
    public int currentRound;
    public int startingRound;
    public bool roundComplete;
    public int currentWave;
    public int numEnemiesPerWave;
    public int currentNumEnemies;

    [Header("Miscellaneous")]
    public bool gameOver;
	public int numOfWaypoints = 4;
	public float spawnTimer;
	public float spawnInterval;
	public bool spawnEnemy;

	[Header("Player Stuff")]
	public GameObject player;


	// Use this for initialization
    void Start(){
        gameOver = false;
        currentRound = startingRound;
        currentWave = 1;
        SetNewRoute();
		TextPopupController.Init();
		player.GetComponent<PlayerHUD>().UpdateRoundDisplay(currentRound);

        //SetEnemyRoute();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval && spawnEnemy && currentNumEnemies <= numEnemiesPerWave && !gameOver)
		{
            
			spawnTimer = 0;
			Spawn(currentWave, currentRound);
		}


	}
    void Spawn(int wave, int round)
    {
		player.GetComponent<PlayerHUD>().UpdateRoundDisplay(currentRound);
		switch(round){
			case 1:
			
				if (currentNumEnemies == numEnemiesPerWave)
					{
						currentWave++;
						
						currentNumEnemies = 0;
						SetNewRoute();
					}
					currentNumEnemies++;
				switch(wave){					
					case 1:						
						GetComponent<EnemyManager>().SpawnEnemyShip("type01", spawnPoint.transform.position);
						break;
					case 2:
						GetComponent<EnemyManager>().SpawnEnemyShip("type02", spawnPoint.transform.position);

						break;					
				}

				if(currentWave > 2){ // # is the number of waves to complete a round, 
					currentRound++;
					currentWave = 1;
				}
			break;

			case 2:
				if (currentNumEnemies == numEnemiesPerWave)
					{
						currentWave++;
						
						currentNumEnemies = 0;
						SetNewRoute();
					}
					currentNumEnemies++;
				switch(wave){					
					case 1:						
						GetComponent<EnemyManager>().SpawnEnemyShip("type01", spawnPoint.transform.position);
						break;
					case 2:
						GetComponent<EnemyManager>().SpawnEnemyShip("type02", spawnPoint.transform.position);

						break;					
				}

				if(currentWave > 2){
					currentRound++;
				}
			break;
		}
	}

    public void SetNewRoute(){
        switch(currentWave){
            case 1:
                currentRoute = new List<Transform>(enemyRoute01);
                break;
            case 2:
				currentRoute = new List<Transform>(enemyRoute02);
				break;
            case 3:
				currentRoute = new List<Transform>(enemyRoute01);
				break;
            case 4:
				currentRoute = new List<Transform>(enemyRoute01);
				break;
            case 5:
				currentRoute = new List<Transform>(enemyRoute01);
				break;
            case 6:
				currentRoute = new List<Transform>(enemyRoute01);
				break;
        }
    }

    public void GameOver(){
        Time.timeScale = 0;
    }


	//Sets a random waypoint system. Wont need in arcade mode
	//public void SetEnemyRoute()
	//{
	//	enemyRoute.Clear();

	//	int topWaypoint = Random.Range(0, topWayPoints.Count);
	//	int secondWaypoint;
	//	int thirdWaypoint;
	//	int fourthWaypoint;

	//	do
	//	{
	//		secondWaypoint = Random.Range(0, secondWayPoints.Count);
	//	} while (topWaypoint - secondWaypoint >= 2);
	//	//Debug.Log("2nd within range");
	//	do
	//	{
	//		thirdWaypoint = Random.Range(0, thirdWayPoints.Count);
	//	} while (secondWaypoint - thirdWaypoint >= 2);
	//	//Debug.Log("3rd within range");
	//	do
	//	{
	//		fourthWaypoint = Random.Range(0, fourthWayPoints.Count);
	//	} while (thirdWaypoint - fourthWaypoint >= 2);
	//	//Debug.Log("4th within range");

	//	enemyRoute.Add(topWayPoints[topWaypoint]);
	//	enemyRoute.Add(secondWayPoints[secondWaypoint]);
	//	enemyRoute.Add(thirdWayPoints[thirdWaypoint]);
	//	enemyRoute.Add(fourthWayPoints[fourthWaypoint]);
	//}
}
