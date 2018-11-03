//============================================================//
//                        Enemey Manager                      //
//============================================================//
//                  Created: 2017-08-30 5:20pm                //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to create all enmies at the start of load and pool,   //
// them.                                                      //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    //==== Prefabs ====\\
    public GameObject enemyType01;
    public GameObject enemyType02;
    public GameObject enemyType03;
    public GameObject enemyType04;
    public GameObject enemyType05;
    public GameObject enemyType06;
    public GameObject enemyType07;
    public GameObject enemyType08;
    public GameObject enemyType09;
    public GameObject enemyType10;
    public GameObject explosionObj;

	//==== Object pools ====\\
	public List<GameObject> enemyType01Pool;
	public List<GameObject> enemyType02Pool;
	public List<GameObject> enemyType03Pool;
	public List<GameObject> enemyType04Pool;
	public List<GameObject> enemyType05Pool;
	public List<GameObject> enemyType06Pool;
	public List<GameObject> enemyType07Pool;
	public List<GameObject> enemyType08Pool;
	public List<GameObject> enemyType09Pool;
	public List<GameObject> enemyType10Pool;
    public List<GameObject> particalPool;

    public int amountOfEachType;

	bool spawned = false;

	void Start () {
		enemyType01Pool = new List<GameObject>();
		enemyType02Pool = new List<GameObject>();
		particalPool = new List<GameObject>();
        for (int i = 0; i < amountOfEachType; i++){
			GameObject tmpE01 = (GameObject)Instantiate(enemyType01);
			GameObject tmpE02 = (GameObject)Instantiate(enemyType02);
			tmpE01.SetActive(false);
			tmpE02.SetActive(false);
			enemyType01Pool.Add(tmpE01);
			enemyType02Pool.Add(tmpE02);
        }

		for (int i = 0; i < 10; i++)
		{
			GameObject tmpE01 = (GameObject)Instantiate(explosionObj);
			tmpE01.SetActive(false);
			particalPool.Add(tmpE01);
		}
	}
	
    public void SpawnEnemyShip(string type, Vector3 point){
        spawned = false;
		switch (type){
			case "type01":
                for (int i = 0; i < enemyType01Pool.Count; i++){
                    if (!enemyType01Pool[i].activeInHierarchy && !spawned){
                        enemyType01Pool[i].transform.position = point;
                        enemyType01Pool[i].GetComponent<Enemy>().onScreen = false;
                        enemyType01Pool[i].SetActive(true);
                        spawned = true;
                    }

                }
                break;

			case "type02":
                for (int i = 0; i < enemyType02Pool.Count; i++){
					if (!enemyType02Pool[i].activeInHierarchy && !spawned){
						enemyType02Pool[i].transform.position = point;
						enemyType02Pool[i].GetComponent<Enemy>().onScreen = false;
						enemyType02Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type03":
				for (int i = 0; i < enemyType03Pool.Count; i++)
				{
					if (!enemyType03Pool[i].activeInHierarchy && !spawned)
					{
						enemyType03Pool[i].transform.position = point;
						enemyType03Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type04":
				for (int i = 0; i < enemyType04Pool.Count; i++)
				{
					if (!enemyType04Pool[i].activeInHierarchy && !spawned)
					{
						enemyType04Pool[i].transform.position = point;
						enemyType04Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type05":
				for (int i = 0; i < enemyType05Pool.Count; i++)
				{
					if (!enemyType05Pool[i].activeInHierarchy && !spawned)
					{
						enemyType05Pool[i].transform.position = point;
						enemyType05Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type06":
				for (int i = 0; i < enemyType01Pool.Count; i++)
				{
					if (!enemyType01Pool[i].activeInHierarchy && !spawned)
					{
						enemyType01Pool[i].transform.position = point;
						enemyType01Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type07":
				for (int i = 0; i < enemyType01Pool.Count; i++)
				{
					if (!enemyType01Pool[i].activeInHierarchy && !spawned)
					{
						enemyType01Pool[i].transform.position = point;
						enemyType01Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type08":
				for (int i = 0; i < enemyType01Pool.Count; i++)
				{
					if (!enemyType01Pool[i].activeInHierarchy && !spawned)
					{
						enemyType01Pool[i].transform.position = point;
						enemyType01Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type09":
				for (int i = 0; i < enemyType01Pool.Count; i++)
				{
					if (!enemyType01Pool[i].activeInHierarchy && !spawned)
					{
						enemyType01Pool[i].transform.position = point;
						enemyType01Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;

			case "type10":
				for (int i = 0; i < enemyType01Pool.Count; i++)
				{
					if (!enemyType01Pool[i].activeInHierarchy && !spawned)
					{
						enemyType01Pool[i].transform.position = point;
						enemyType01Pool[i].SetActive(true);
						spawned = true;
					}

				}
				break;
		}
	}

    public void SpawnParticalHalo(Vector3 point){
        bool spawned2 = false;
        for (int i = 0; i < particalPool.Count; i++){
            if (!particalPool[i].activeInHierarchy  && !spawned2){
                particalPool[i].transform.position = point;
				particalPool[i].SetActive(true);
                particalPool[i].GetComponent<ParticleSystem>().Play();
                spawned2 = true;
            }
        }
    }

    public void KillAllEnemiesOnScreen(){

        //TODO:
        //      Repeat this for all pools
		for (int i = 0; i < enemyType01Pool.Count; i++)
		{
            if (enemyType01Pool[i].activeInHierarchy && enemyType01Pool[i].GetComponent<Enemy>().onScreen)
			{
                GameObject.Find("Player").GetComponent<Player>().ChangeScore(enemyType01Pool[i].GetComponent<Enemy>().scoreWorth);
				enemyType01Pool[i].GetComponent<Enemy>().DisplayScore();
                enemyType01Pool[i].GetComponent<Enemy>().TriggerExplosion();
                enemyType01Pool[i].GetComponent<Enemy>().Disable();
				//enemyType01Pool[i].SetActive(true);
				//spawned = true;
			}

		}
    }

}
