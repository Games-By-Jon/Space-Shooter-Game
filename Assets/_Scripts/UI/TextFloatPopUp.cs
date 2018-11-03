//============================================================//
//                         Floating text                      //
//============================================================//
//                  Created: 2017-12-18 10:51 am              //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to display a float text on screen, then destroy it    //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFloatPopUp : MonoBehaviour {

    public Text popupText;

    private void Awake(){
        popupText = GetComponentInChildren<Text>();
        //popupText = GetComponent<Text>();
        Invoke("Disable", .75f);
    }

    public void SetText(string displayText){
        popupText.text = displayText;
    }

	public void Disable(){
		gameObject.SetActive((false));
	}

	void OnDisable(){
		CancelInvoke();
	}
}
