//============================================================//
//                         Weapon Fire                        //
//============================================================//
//                  Created: 2017-08-17 4:45pm                //
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
using System.Collections.Generic;

public class WeaponFire : MonoBehaviour {
    //==== Prefabs ====\\
	public GameObject laserSingleShot;
	public GameObject laserDoubleShot;
	public GameObject laserTripleShot;
	public GameObject laserQuadShot;
	public GameObject missile;
    //==== Object pools ====\\
	public List<GameObject> singleLaserShots;
	public List<GameObject> doubleLaserShots;
	public List<GameObject> tripleLaserShots;
	public List<GameObject> quadLaserShots;
	public List<GameObject> missileShots;

    public enum shotType {
        singleShot,
        doubleShot,
        tripleSpread,
        quadShot
    }
    public shotType currentShotType = shotType.singleShot;
	public int amountOfLaserShots = 25;
	public int amountOfMissiles = 25;



	void Start(){
		singleLaserShots = new List<GameObject>();
		doubleLaserShots = new List<GameObject>();
		tripleLaserShots = new List<GameObject>();
		quadLaserShots = new List<GameObject>();
        missileShots = new List<GameObject>();
        for (int i = 0; i < amountOfLaserShots; i++){
			GameObject singleShot = (GameObject)Instantiate(laserSingleShot);
			GameObject doubleShot = (GameObject)Instantiate(laserDoubleShot);
			GameObject tripleShot = (GameObject)Instantiate(laserTripleShot);
			GameObject quadShot = (GameObject)Instantiate(laserQuadShot);
			singleShot.SetActive(false);
			doubleShot.SetActive(false);
			tripleShot.SetActive(false);
			quadShot.SetActive(false);
			singleLaserShots.Add(singleShot);
			doubleLaserShots.Add(doubleShot);
			tripleLaserShots.Add(tripleShot);
			quadLaserShots.Add(quadShot);
        }

        for (int i = 0; i < amountOfMissiles; i++){
            GameObject tmpMissile = (GameObject)Instantiate(missile);
            tmpMissile.SetActive(false);
            missileShots.Add(tmpMissile);
        }
    }

    public void FireLasers(){
        GetComponent<Player>().numOfShotsTaken++;
        switch(currentShotType){
            case shotType.singleShot:
				for (int i = 0; i < singleLaserShots.Count; i++){
					if (!singleLaserShots[i].activeInHierarchy){
                        singleLaserShots[i].transform.position = new Vector3(transform.position.x, transform.position.y + 0.35f, -8);
						singleLaserShots[i].SetActive(true);
						break;
					}
				}
                break;

            case shotType.doubleShot:
				for (int i = 0; i < doubleLaserShots.Count; i++){
					if (!doubleLaserShots[i].activeInHierarchy){
						doubleLaserShots[i].transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, -8);
						doubleLaserShots[i].SetActive(true);
						break;
					}
				}
                break;

            case shotType.tripleSpread:
				for (int i = 0; i < tripleLaserShots.Count; i++)
				{
					if (!tripleLaserShots[i].activeInHierarchy)
					{
						tripleLaserShots[i].transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, -8);
						tripleLaserShots[i].transform.GetChild(0).gameObject.transform.localPosition = new Vector3(0, -0.77f, 0);
                        tripleLaserShots[i].transform.GetChild(0).gameObject.SetActive(true);
						tripleLaserShots[i].transform.GetChild(1).gameObject.transform.localPosition = new Vector3(0, 0, 0);
						tripleLaserShots[i].transform.GetChild(1).gameObject.SetActive(true);
						tripleLaserShots[i].transform.GetChild(2).gameObject.transform.localPosition = new Vector3(0, 0.77f, 0);
						tripleLaserShots[i].transform.GetChild(2).gameObject.SetActive(true);
						tripleLaserShots[i].SetActive(true);
						break;
					}
				}
				break;

			case shotType.quadShot:
				for (int i = 0; i < quadLaserShots.Count; i++)
				{
					if (!quadLaserShots[i].activeInHierarchy)
					{
						quadLaserShots[i].transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, -8);
						quadLaserShots[i].SetActive(true);
						break;
					}
				}
				break;
        }

    }

    public void FireMissiles(){
        if (GetComponent<Player>().numMissiles > 0){
            for (int i = 0; i < missileShots.Count; i++){
                if (!missileShots[i].activeInHierarchy){
                    missileShots[i].transform.position = new Vector3(transform.position.x, transform.position.y + 0.35f, -8);
                    missileShots[i].SetActive(true);
                    break;
                }
            }

            GetComponent<Player>().AdjustMissileCount(-1);
        }
    }
}
