//-------------------------------------------------------------------------------
// Screen Manager declaration
//-------------------------------------------------------------------------------
// Created: 2016-01-26 8:30 PM (EST)
// Updated: 2015-XX-XX X:XX PM (EST)
// Revision: 0
// Version: 1.0.0
//-------------------------------------------------------------------------------
// Author: Jon Thompson
// Contact: @programmer_Jon | Mr.J.Thompson@hotmail.ca 
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenManager : MonoBehaviour {
	public enum Screens{
		TITLEMENU,
        ARCADEMODE,
		CAMPAINMODE,
        SURVIVALMODE,
        LEVELSELECT,
        HIGHSCORES
	};

	public Screens currentScreen = Screens.TITLEMENU;

	public void SwitchScreen(Screens screenToLoad){
		switch(screenToLoad){
			case Screens.TITLEMENU:
				SceneManager.LoadScene("TitleMenu");
				break;
                
			case Screens.ARCADEMODE:
				SceneManager.LoadScene("ArcadeMode");
				break;

			case Screens.CAMPAINMODE:
				SceneManager.LoadScene("CampainMode");
				break;

			case Screens.SURVIVALMODE:
				SceneManager.LoadScene("SurvivalMode");
				break;
			case Screens.LEVELSELECT:
				SceneManager.LoadScene("LevelSelect");
				break;
            case Screens.HIGHSCORES:
				SceneManager.LoadScene("HighScores");
				break;
                
			default:
				Debug.Log("ERROR IN SCREEN SWITCHING");
				break;
		}
	}

    public void TitleScrrenCampainButton(){
        SwitchScreen(Screens.LEVELSELECT);
    }

    public void TitleScrrenSurvivalButton(){
		SwitchScreen(Screens.SURVIVALMODE);
	}

	public void TitleScrrenArcadeButton(){
        SwitchScreen(Screens.ARCADEMODE);
	}

	public void TitleScrrenHighScoresButton()	{
		SwitchScreen(Screens.HIGHSCORES);
	}

    public void PortfolioPage(){
        Application.OpenURL("http://jonthompson.ca/");
    }
}
