//============================================================//
//                        Player                              //
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
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public enum gameType{
        ARCADEMODE,
        SURVIVALMODE,
        CAMPAINMODE
    };
	public int numLives;        // tracks the amount of lives the player has
	public int maxNumLives;     // tracks the max amount of lives the player can have
    public int score;           // tracks the users score.
    private float dx;
    public float movementSpeed;

    public int numMissiles;
    public int missileLimit;

    public int killCount;
    public int numOfShotsTaken;

	public Image moveLeftBtn;
	public Image moveRightBtn;


    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(dx * movementSpeed, 0);
    }

    public void ChangeNumLives(int amount){
        numLives += amount;
    }

    public void ChangeScore(int amount){
        score += amount;
        GetComponent<PlayerHUD>().UpdateScore(score);
    }

    public void MoveLeftButton(){
        dx = -1;
        moveLeftBtn.color = new Color(174, 174, 174, 255);
    }

    public void MoveRightButton(){
        dx = 1;
    }

    public void ButtonUp(){
        dx = 0;
        moveLeftBtn.color = new Color(255, 255, 255, 255);
	}

    public void AdjustMissileCount(int amount){
        numMissiles += amount;

        if(numMissiles < 0){
            numMissiles = 0;
        } else if(numMissiles > missileLimit){
            numMissiles = missileLimit;
        }

        GetComponent<PlayerHUD>().UpdateMissleDisplay(numMissiles);

    }

	public void AdjustLivesCount(int amount){
        numLives += amount;

		if (numLives < 0){
			numLives = 0;
		}
		else if (numLives > maxNumLives){
			numLives = maxNumLives;
		}

        GetComponent<PlayerHUD>().UpdateLifeDisplay(numLives);

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "PickUp"){
            switch(other.GetComponent<PickUp>().pickUpType){
				case PickUp.pickUpTypes.missilePickUp:
					AdjustMissileCount(1);
					break;

				case PickUp.pickUpTypes.extraLifePickUp:
					AdjustLivesCount(1);
					break;

                case PickUp.pickUpTypes.doubleShotPickUp:
                    GetComponent<WeaponFire>().currentShotType = WeaponFire.shotType.doubleShot;
					break;

				case PickUp.pickUpTypes.tripleShotPickUp:
					GetComponent<WeaponFire>().currentShotType = WeaponFire.shotType.tripleSpread;
					break;

				case PickUp.pickUpTypes.quadShotPickUp:
					GetComponent<WeaponFire>().currentShotType = WeaponFire.shotType.quadShot;
					break;
			}
			
        } else if(other.gameObject.tag == "Enemy"){
            Debug.Log("Game Over");
			FindObjectOfType<ArcadeModeManager>().gameOver = true;
            FindObjectOfType<ArcadeModeManager>().GameOver();
        }
	}
}
