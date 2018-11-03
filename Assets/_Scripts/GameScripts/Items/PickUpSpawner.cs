//============================================================//
//                         PickUp Spawner                     //
//============================================================//
//                  Created: 2017-08-21 8:30                  //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to move a texture around a quad.                      //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {
    public enum GameType
    {
        ARCADEMODE,
        SURVIVALMODE,
        CAMPAINGMODE
    };

    public GameType currentGameMode = GameType.ARCADEMODE;
	public GameObject missilePickUp;
	public GameObject doubleShotPickUp;
	public GameObject tripleShotPickUp;
	public GameObject quadShotPickUp;
	public GameObject extraLifePickUp;
	public Vector3 topLeftSpawnPoint = new Vector3(0, 0, 0);
	public Vector3 topRightSpawnPoint = new Vector3(0, 0, 0);
    public int tmpNum;
	public float timer;
    public float spawnInterval;

    void Start(){
		missilePickUp.SetActive(false);
        doubleShotPickUp.SetActive(false);
		tripleShotPickUp.SetActive(false);
		quadShotPickUp.SetActive(false);
		extraLifePickUp.SetActive(false);


    }

    void Update(){
        timer += Time.deltaTime;


        if(timer >= spawnInterval){
            SelectPickUp();
            timer = 0;
        }
    }

    public void SelectPickUp(){
        tmpNum = Random.Range(0, 100);
        switch(currentGameMode){
            case GameType.CAMPAINGMODE:
            case GameType.SURVIVALMODE:
				if (tmpNum >= 0 && tmpNum < 33){
					SpawnPickUp("DoubleShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
				}
				else if (tmpNum >= 33 && tmpNum < 60){
					SpawnPickUp("TripleShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
				}
				else if (tmpNum >= 60 && tmpNum < 85){
					SpawnPickUp("MissilePickUp", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
				}
				else if (tmpNum >= 85){
					SpawnPickUp("QuadShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
				}
                break;

            case GameType.ARCADEMODE:
                if(tmpNum >= 0 && tmpNum < 30){
                    SpawnPickUp("DoubleShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
                } else if(tmpNum >= 30 && tmpNum < 55){
					SpawnPickUp("TripleShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
                } else if(tmpNum >= 55 && tmpNum < 75){
					SpawnPickUp("MissilePickUp", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
                } else if(tmpNum >= 75 && tmpNum < 90){
					SpawnPickUp("QuadShot", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
                } else if(tmpNum >= 90){
					SpawnPickUp("ExtraLife", new Vector3(Random.Range(topLeftSpawnPoint.x, topRightSpawnPoint.x), topLeftSpawnPoint.y, topLeftSpawnPoint.z));
                }
                break;


        }
    }

    public void SpawnPickUp(string type, Vector3 point)
    {
        switch (type)
        {
            case "MissilePickUp":
                missilePickUp.transform.position = point;
                missilePickUp.SetActive(true);
                break;

            case "ExtraLife":
                extraLifePickUp.transform.position = point;
                extraLifePickUp.SetActive(true);
                break;

            case "DoubleShot":
                doubleShotPickUp.transform.position = point;
                doubleShotPickUp.SetActive(true);
                break;

            case "TripleShot":
                tripleShotPickUp.transform.position = point;
                tripleShotPickUp.SetActive(true);
                break;

            case "QuadShot":
                quadShotPickUp.transform.position = point;
                quadShotPickUp.SetActive(true);
                break;
        }
	}
}
