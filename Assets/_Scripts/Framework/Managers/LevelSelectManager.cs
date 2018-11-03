//============================================================//
//                         Enemy                              //
//============================================================//
//                  Created: 2017-08-22 12:21 am              //
//                  Updated: 2018-09-04                       //
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour {
    public GameManager gm;
    public Sprite lvlBeat;

    [Header("Area 01")]
    public Button buttonA01;
    public Button buttonA02;
    public Button buttonA03;
    [Header("Area 02")]
   

    public Image crabLvl01;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
        CheckLevelStatus();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevel(string levelToLoad){
       // 
        SceneManager.LoadScene(levelToLoad);
    }

    public void SetCampaignLevel(int lvlToLoad){
        gm.campaignLvlToLoad = lvlToLoad;
    }

    void CheckLevelStatus(){
        if(gm.crabLvl01Beat){
            buttonA01.image.sprite = lvlBeat;
        } 
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("TitleMenu");
    }
}
