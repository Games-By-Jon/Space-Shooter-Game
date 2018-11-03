//-------------------------------------------------------------------------------
// Main Menu Handler declaration
//-------------------------------------------------------------------------------
// Created: 2016-01-26 9:00 PM (EST)
// Updated: 2015-XX-XX X:XX PM (EST)
// Revision: 0
// Version: 1.0.0
//-------------------------------------------------------------------------------
// Author: Jon Thompson
// Contact: @programmer_Jon | Mr.J.Thompson@hotmail.ca 
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Canvas confirmQuitCanvas;
    public ScreenManager sm;
    
	
	void Start () {
		confirmQuitCanvas.enabled = false;
        // sm = FindObjectOfType<ScreenManager>();
	}

	public void StartGame(){
		// sm.SwitchScreen(ScreenManager.Screens.LEVEL01);
        Debug.Log("Button Pressed!");
	}

	public void LoadSavedGame(){
		
	}

	public void Options(){
		
	}

	public void QuitGame(){
		confirmQuitCanvas.enabled  = true;
	}

	public void ConfirmQuitGame(){
		Application.Quit();
	}

	public void CancelQuitGame(){
		confirmQuitCanvas.enabled  = false;
	}
}
