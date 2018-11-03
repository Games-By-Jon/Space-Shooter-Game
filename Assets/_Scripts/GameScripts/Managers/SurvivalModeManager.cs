//============================================================//
//                  Survival Mode Manager                     //
//============================================================//
//                  Created: 2017-09-13 5:25 am               //
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

public class SurvivalModeManager : MonoBehaviour {
    
    [Header("WayPoints")]

    public GameObject spawnPoint;
	public List <Transform> topWayPoints;
	public List<Transform> secondWayPoints;
	public List<Transform> thirdWayPoints;
	public List<Transform> fourthWayPoints;

	public List<Transform> enemyRoute;
	public List<Transform> enemyRouteLoop;

    public int numOfWaypoints = 4;
    public float timer;
    public int interval;
    public bool spawnEnemy;


	// Use this for initialization
	void Start () {
		TextPopupController.Init();
		SetEnemyRoute();
		SetEnemyRouteLoopBack();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timer += Time.deltaTime;

        if(timer > interval && spawnEnemy){
            timer = 0;
            Spawn();
        }
	}
    void Spawn(){
		GetComponent<EnemyManager>().SpawnEnemyShip("type01", spawnPoint.transform.position);
		//Debug.Log("Spawn 1");
    }
    public void SetEnemyRoute(){
        enemyRoute.Clear();

        int topWaypoint = Random.Range(0, topWayPoints.Count);
        int secondWaypoint;
        int thirdWaypoint;
        int fourthWaypoint;

        do{
            secondWaypoint = Random.Range(0, secondWayPoints.Count);
        } while (topWaypoint - secondWaypoint >= 2);
        //Debug.Log("2nd within range");
        do      {
            thirdWaypoint = Random.Range(0, thirdWayPoints.Count);
        } while (secondWaypoint - thirdWaypoint >= 2);
        //Debug.Log("3rd within range");
        do      {
            fourthWaypoint = Random.Range(0, fourthWayPoints.Count);
        } while (thirdWaypoint - fourthWaypoint >= 2);
        //Debug.Log("4th within range");

        enemyRoute.Add(topWayPoints[topWaypoint]);
        enemyRoute.Add(secondWayPoints[secondWaypoint]);
        enemyRoute.Add(thirdWayPoints[thirdWaypoint]);
        enemyRoute.Add(fourthWayPoints[fourthWaypoint]);
    }

    public void SetEnemyRouteLoopBack(){
        enemyRouteLoop.Clear();

        int topWaypoint = Random.Range(0, topWayPoints.Count);
        int secondWaypoint;
        int thirdWaypoint;
		int fourthWaypoint;
		int loopBackPoint;

        do{
            secondWaypoint = Random.Range(0, secondWayPoints.Count);
        } while (topWaypoint - secondWaypoint >= 2);
        do{
            thirdWaypoint = Random.Range(0, thirdWayPoints.Count);
        } while (secondWaypoint - thirdWaypoint >= 2);
        //===== loops back ====\\
		do{
			loopBackPoint = Random.Range(0, secondWayPoints.Count);
        } while (thirdWaypoint - loopBackPoint >= 3 && loopBackPoint != thirdWaypoint);
        do{
            fourthWaypoint = Random.Range(0, fourthWayPoints.Count);
        } while (thirdWaypoint - fourthWaypoint >= 2);

        enemyRouteLoop.Add(topWayPoints[topWaypoint]);
        enemyRouteLoop.Add(secondWayPoints[secondWaypoint]);
		enemyRouteLoop.Add(thirdWayPoints[thirdWaypoint]);
        enemyRouteLoop.Add(secondWayPoints[loopBackPoint]);
        enemyRouteLoop.Add(fourthWayPoints[fourthWaypoint]);
    }
}
