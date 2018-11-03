//============================================================//
//                  Campaign Mode Manager                      //
//============================================================//
//                  Created: 2018-09-04 5:25 am               //
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

public class CampaignModeManager : MonoBehaviour
{
	[Header("Campaign Level Details")]
	public int lvlToLoad;
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


    [Header("wave Trackers")]
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
		lvlToLoad = FindObjectOfType<GameManager>().campaignLvlToLoad;
        gameOver = false;
        currentWave = 1;
        SetNewRoute();
		TextPopupController.Init();

        SetEnemyRoute();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval && spawnEnemy && currentNumEnemies <= numEnemiesPerWave && !gameOver)
		{
            
			spawnTimer = 0;
			Spawn(currentWave);
		}


	}
    void Spawn(int wave)
    {
		if (currentNumEnemies == numEnemiesPerWave)
			{
				currentWave++;
				
				currentNumEnemies = 0;
				SetEnemyRoute();
			}
			currentNumEnemies++;
		switch(wave){					
			case 1:						
				GetComponent<EnemyManager>().SpawnEnemyShip("type01", spawnPoint.transform.position);
				break;
			case 2:
				GetComponent<EnemyManager>().SpawnEnemyShip("type02", spawnPoint.transform.position);
				break;

			default:
				GetComponent<EnemyManager>().SpawnEnemyShip("type02", spawnPoint.transform.position);
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
	public void SetEnemyRoute()
	{
		currentRoute.Clear();

		int topWaypoint = Random.Range(0, topWayPoints.Count);
		int secondWaypoint;
		int thirdWaypoint;
		int fourthWaypoint;

		do
		{
			secondWaypoint = Random.Range(0, secondWayPoints.Count);
		} while (topWaypoint - secondWaypoint >= 2);
		//Debug.Log("2nd within range");
		do
		{
			thirdWaypoint = Random.Range(0, thirdWayPoints.Count);
		} while (secondWaypoint - thirdWaypoint >= 2);
		//Debug.Log("3rd within range");
		do
		{
			fourthWaypoint = Random.Range(0, fourthWayPoints.Count);
		} while (thirdWaypoint - fourthWaypoint >= 2);
		//Debug.Log("4th within range");

		currentRoute.Add(topWayPoints[topWaypoint]);
		currentRoute.Add(secondWayPoints[secondWaypoint]);
		currentRoute.Add(thirdWayPoints[thirdWaypoint]);
		currentRoute.Add(fourthWayPoints[fourthWaypoint]);
	}


	public void SetUpCampaign(){
		switch(lvlToLoad){
			case 1:
			break;

			default:
			break;
		}
	}
}
