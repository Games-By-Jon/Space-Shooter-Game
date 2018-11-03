//============================================================//
//                    Enemy Boss part                         //
//============================================================//
//                  Created: 2018-01-20 05:31 am              //
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

public class EnemyBossPart : MonoBehaviour
{
	public int numHitsNeededToDestroy;
    public int currentNumOfHits;
    public Renderer render;
    public float timer;
    public bool startTimer;


	public int scoreWorth;
	public bool onScreen = false;
    public bool spriteOff = false;
    public bool isDestroyed = false;
    public static bool isHit = false;

    private void Start(){
        render = GetComponent<Renderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Weapon" && !isDestroyed)
		{
			switch (GameObject.Find("Player").GetComponent<WeaponFire>().currentShotType)
			{
				case WeaponFire.shotType.singleShot:
                    currentNumOfHits++;
					break;

				case WeaponFire.shotType.doubleShot:
                    currentNumOfHits += 2;

					break;

				case WeaponFire.shotType.tripleSpread:
                    currentNumOfHits++;
					break;

				case WeaponFire.shotType.quadShot:
                    currentNumOfHits += 4;
					break;
			}
            if (!isHit)
            {
                InvokeRepeating("FlashHit", 0, 0.15f);
                startTimer = true;
                timer = 0;
                isHit = true;
            }

            if(currentNumOfHits >= numHitsNeededToDestroy){
                GetComponentInParent<EnemyBoss>().numPartsDestroyed++;
                if(GetComponentInParent<EnemyBoss>().numDestroyableParts == GetComponentInParent<EnemyBoss>().numPartsDestroyed){
                    GetComponentInParent<EnemyBoss>().mainPartDamage = true;
                }
				TriggerExplosion();
				DisplayScore();
                Disable();
			}
			
		}

		
	}

    private void Update()
    {
        if(startTimer){
            timer += Time.deltaTime;

            if(timer >= 1){
                CancelInvoke();
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                isHit = false;
            }
        }   
    }

    public void FlashHit(){
        //render.enabled = !render.enabled;

        if (spriteOff){
            GetComponent<SpriteRenderer>().color = new Color(255,255,255,255);
            spriteOff = !spriteOff;
        } else if(!spriteOff){
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            spriteOff = !spriteOff;
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
