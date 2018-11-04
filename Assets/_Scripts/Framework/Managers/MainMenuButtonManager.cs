//============================================================//
//                  Main menu button manager                  //
//============================================================//
//                  Created: 2018-09-13                       //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to manage the buttons in the main menu.               //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour {
	public int cheatBtnPressedNum;
	public GameObject cheatBtn;
	public Canvas moreInfoCanvas;
	public Canvas highScoresCanvas;
	public Canvas privacyCanvas;

	void Start(){
		cheatBtn.SetActive(false);
		moreInfoCanvas.enabled = false;
		highScoresCanvas.enabled = false;
		privacyCanvas.enabled = false;
	}
	public void LoadCampaignLevelSelectButton(){
		SceneManager.LoadScene("LevelSelect");
	}
    public void LoadSurvivalButton(){
		SceneManager.LoadScene("SurvivalMode");
	}

	public void LoadArcadeButton(){
        SceneManager.LoadScene("ArcadeMode");
	}

	public void ShowHighScoresButton()	{
		highScoresCanvas.enabled = true;
	}

	public void CloseHighScoresButton()	{
		highScoresCanvas.enabled = false;
	}

	public void ShowMoreInfo(){
		moreInfoCanvas.enabled = true;
	}

	public void CloseMoreInfo(){
		moreInfoCanvas.enabled = false;
	}

	public void ShowPrivacuPolicy(){
		privacyCanvas.enabled = true;
	}

	public void ClosePrivacuPolicy(){
		privacyCanvas.enabled = false;
	}

    public void PortfolioPage(){
        Application.OpenURL("http://jonthompson.ca/");
    }

	public void OpenSupportPage(){
        Application.OpenURL("http://jonthompson.ca/contact.html");
    }

	public void OpenGamesPage(){
        Application.OpenURL("http://jonthompson.ca/games.html");
    }

	public void OpenUnityPrivayPage(){
        Application.OpenURL("https://unity3d.com/legal/privacy-policy");
    }

	public void CheatEnableButton(){
		cheatBtnPressedNum++;

		if(cheatBtnPressedNum >= 5){
			//Show cheat btn
			Debug.Log("Cheats enabled!");	
			cheatBtn.SetActive(true);
		}
	}
}
