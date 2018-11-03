//============================================================//
//                  Help Screen Display                       //
//============================================================//
//                  Created: 2017-12-17 12:05am               //
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeplDisplay : MonoBehaviour {
    public GameObject helpGroup;
    public List<Sprite> helpImages = new List<Sprite>();
    public List<string> helpTextBox = new List<string>();

    public Text helpText;
    public Image helpScreen;
    public Text PageNumTextBox;

    public int currentPage = 1;
    public int maxPage = 4;

    private void Start(){
		helpTextBox.Add("1. Dark Level dots are unbeaten levels. \n\n2.Dark path lines are blocked by unbeaten levels. \n\n3. Yellow dots indacate a beaten level, this opens up a light path to the next level. \n\n4. Greyed out Level Select areas are locked until previous areas are completed.");
		helpTextBox.Add("1. Pause Button, pause or unpause the game. \n\n2. Move the ship left or right.\n\n3.  Missile fire button, can only fire missiles if you have them.\n\n4. Fire laser button, depending on the type of laser you have preesing this will fire the laser.");
		helpTextBox.Add("1. Level Name Display or Survival Mode, and Current Score.\n\n2. Number of extra lives in resurve.\n\n3. Number of missiles in your inventory.");
		//helpTextBox.Add("1. Dark Level dots are unbeaten levels, \n\n2.Dark path lines are blocked by unbeaten levels. \n\n3. Yellow dots indacate a beaten level, this opens up a light path to the next level. \n\n4. Greyed out Level Select areas are locked until previous areas are completed.");
        currentPage = 1; 
        SetHelpInfo();
        helpGroup.SetActive(false);
    }

    public void NextPage(){
        if(currentPage == maxPage){
            currentPage = 1;
        } else{
            currentPage++;
        }

        SetHelpInfo();
    }

	public void PreviousPage()	{
        if (currentPage == 1){
            currentPage = maxPage;
		}
		else {
			currentPage--;
		}

		SetHelpInfo();
	}

    public void ShowHelp(){
		currentPage = 1;
		SetHelpInfo();
		helpGroup.SetActive(true);
    }

    public void CloseHelp(){
		helpGroup.SetActive(false);
    }

	private void SetHelpInfo(){
        PageNumTextBox.text = currentPage.ToString() + "/" + maxPage.ToString();

        //Sitching Help Image
        switch(currentPage){
            case 1:
                helpScreen.sprite = helpImages[0];
                break;

            case 2:
                helpScreen.sprite = helpImages[1];
                break;

            case 3:
                helpScreen.sprite = helpImages[2];
                break;

            case 4:
                helpScreen.sprite = helpImages[3];
                break;
        }

		//Sitching Help Text
		switch (currentPage)
		{
			case 1:
                helpText.text = helpTextBox[0];
				break;

			case 2:
				helpText.text = helpTextBox[1];
				break;

			case 3:
				helpText.text = helpTextBox[2];
				break;

			case 4:
				helpText.text = helpTextBox[3];
				break;
		}
    }
}
