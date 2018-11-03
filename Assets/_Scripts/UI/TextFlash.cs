//-------------------------------------------------------------------------------
// Text Flash
//-------------------------------------------------------------------------------
// Created: 2016-09-19 2:03 PM (EST)
// Updated: 2016-XX-XX X:XX PM (EST)
// Revision: 0
// Version: 1.0.0
//-------------------------------------------------------------------------------
// Author: Jon Thompson
// Contact: @programmer_Jon | Mr.J.Thompson@hotmail.ca 
//-------------------------------------------------------------------------------
//								REVISION NOTES
//
//
//
//-------------------------------------------------------------------------------
//							FUTURE IDEAS/IMPLEMENTIONS
//
//	
//
//
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFlash : MonoBehaviour {
    public Text textToFlash;
    public bool textColor1 = false;
    public Color color1 = Color.yellow;
    public Color color2 = Color.red;

    public float timer;
    public float flashInterval = 0.5f;

    void Start() {
        textToFlash.color = color1;
    }

	void Update () {
        timer += Time.deltaTime;

        if(timer > flashInterval) {
            TextColorChange();
            timer = 0;
        }
	}

    void TextColorChange() {
        if (textColor1) {
            textToFlash.color = color1;            
        } else if (!textColor1) {
            textToFlash.color = color2;
        }
        textColor1 = !textColor1;
    }
}
