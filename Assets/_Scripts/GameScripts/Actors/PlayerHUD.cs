//============================================================//
//                         Player HUD                         //
//============================================================//
//                  Created: 2017-08-21 7:07                  //
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
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    public Image missileOne;
    public Image missileTwo;
    public Image missileThree;
    public Image missileFour;
	public Image missileFive;
    public Image lifeOne;
    public Image lifeTwo;
	public Image lifeThree;
	public Image lifeFour;

    public Text scoreDisplay;
 	public Text pauseText;
	public Text roundDisplay;

    public Canvas pauseOverlay;
   
    public Button quitLvlBtn;

    public bool gamePaused = false;

    void Start(){
		UpdateMissleDisplay(GetComponent<Player>().numMissiles);
        UpdateLifeDisplay(GetComponent<Player>().numLives);
        UpdateScore(GetComponent<Player>().score);

		pauseOverlay.enabled = false;
    }

    public void UpdateMissleDisplay(int numeMissiles){
        switch(numeMissiles){
            case 0:
				missileOne.enabled = false;
				missileTwo.enabled = false;
				missileThree.enabled = false;
				missileFour.enabled = false;
                missileFive.enabled = false;
                break;

			case 1:
				missileOne.enabled = true;
				missileTwo.enabled = false;
				missileThree.enabled = false;
				missileFour.enabled = false;
				missileFive.enabled = false;
				break;

			case 2:
				missileOne.enabled = true;
				missileTwo.enabled = true;
				missileThree.enabled = false;
				missileFour.enabled = false;
				missileFive.enabled = false;
				break;

			case 3:
				missileOne.enabled = true;
				missileTwo.enabled = true;
				missileThree.enabled = true;
				missileFour.enabled = false;
				missileFive.enabled = false;
				break;

			case 4:
				missileOne.enabled = true;
				missileTwo.enabled = true;
				missileThree.enabled = true;
				missileFour.enabled = true;
				missileFive.enabled = false;
				break;

			case 5:
				missileOne.enabled = true;
				missileTwo.enabled = true;
				missileThree.enabled = true;
				missileFour.enabled = true;
				missileFive.enabled = true;
				break;
        }
        
    }

    public void UpdateLifeDisplay(int numLives){
        switch(numLives){
			//players 1 life is current life so display no extra lives
            case 0:
			case 1:
				lifeOne.enabled = false;
				lifeTwo.enabled = false;
				lifeThree.enabled = false;
                lifeFour.enabled = false;
				break;

			case 2:
                lifeOne.enabled = true;
				lifeTwo.enabled = false;
				lifeThree.enabled = false;
                lifeFour.enabled = false;
				break;

			case 3:
				lifeOne.enabled = true;
				lifeTwo.enabled = true;
				lifeThree.enabled = false;
                lifeFour.enabled = false;
				break;

			case 4:
				lifeOne.enabled = true;
				lifeTwo.enabled = true;
				lifeThree.enabled = true;
                lifeFour.enabled = false;
				break;
			case 5:
				lifeOne.enabled = true;
				lifeTwo.enabled = true;
				lifeThree.enabled = true;
                lifeFour.enabled = true;
				break;
                
        }
    }

    public void UpdateScore(int score){
        scoreDisplay.text = score.ToString("D10");

    }

	public void UpdateRoundDisplay(int round){
		roundDisplay.text = "stage " + round.ToString();
	}

    public void PauseGameBtn(){
        if(gamePaused){
            Time.timeScale = 1;
            gamePaused = !gamePaused;
            pauseOverlay.enabled = false;
        } else if(!gamePaused){
            Time.timeScale = 0;
			gamePaused = !gamePaused; 
            pauseOverlay.enabled = true;
        }

    }

	public void BackToLevelSelectBtn(){
		Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    public void BackToMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleMenu");
    }
}
