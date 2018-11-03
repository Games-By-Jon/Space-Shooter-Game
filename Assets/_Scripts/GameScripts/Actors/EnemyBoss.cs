//============================================================//
//                         Enemy                              //
//============================================================//
//                  Created: 2018-01-20 05:01 am              //
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

public class EnemyBoss : MonoBehaviour
{
    public int numDestroyableParts;
    public int numPartsDestroyed;
    public int numHitsNeededToDestroy;

    public bool mainPartDamage = false; // if true the main part of the boss can take damage, only after all other parts are destroye.

	public int scoreWorth;
	public bool onScreen = false;

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "Weapon" && mainPartDamage)
		{
            switch(GameObject.Find("Player").GetComponent<WeaponFire>().currentShotType){
				case WeaponFire.shotType.singleShot:
					break;

                case WeaponFire.shotType.doubleShot:
					break;

				case WeaponFire.shotType.tripleSpread:
					break;

				case WeaponFire.shotType.quadShot:
					break;
            }

			TriggerExplosion();
			DisplayScore();
			Disable();
		}

		if (other.gameObject.tag == "Screen")
		{
			onScreen = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Screen")
		{
			onScreen = false;
		}
	}

	public void TriggerExplosion()
	{
		FindObjectOfType<EnemyManager>().SpawnParticalHalo(transform.position);
	}

	public void Disable()
	{
		onScreen = false;
		gameObject.SetActive((false));
	}

	public void DisplayScore()
	{
		TextPopupController.CreatePopupText(scoreWorth.ToString(), transform);
	}
}
