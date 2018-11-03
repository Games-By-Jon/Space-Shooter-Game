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

public class TextPopupController : MonoBehaviour {
    private static TextFloatPopUp popupTextPrefab;
    private static Canvas canvas;

    public static void Init(){
        //canvas = FindObjectOfType <Canvas>();
        canvas = GameObject.Find("PlayerHUDCanvas").GetComponent<Canvas>();
        popupTextPrefab = Resources.Load<TextFloatPopUp>("EnemyScorePopup");

    }

    public static void CreatePopupText(string textToPass, Transform locationToSpawn){
        TextFloatPopUp instance = Instantiate(popupTextPrefab);
        Vector2 screenPos = Camera.main.WorldToScreenPoint(locationToSpawn.position);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPos;
        instance.SetText(textToPass);
    }
}
