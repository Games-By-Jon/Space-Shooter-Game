//-------------------------------------------------------------------------------
// SpashScreen Handler declaration
//-------------------------------------------------------------------------------
// Created: 2016-11-05 1:30 AM (EST)
// Updated: 2015-XX-XX X:XX PM (EST)
// Revision: 1
// Version: 1.1.0
//-------------------------------------------------------------------------------
// Author: Jon Thompson
// Contact: @programmer_Jon | Mr.J.Thompson@hotmail.ca 
//-------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpashScreen : MonoBehaviour {

    private ScreenManager SM;
    public Image splash1;
    public Image splash2;
    private Image loadedSpash1;
    private Image loadedSpash2;
    public Canvas canvas;
    public float switchTimer = 5.0f;
    public float timerScreenSwitch;
    public float clickTimer;
    public float clickSwitchTimer = 0.75f;
    private bool splash1shown = false;
    private bool splash2shown = false;


    // Use this for initialization
    void Start() {
        SM = FindObjectOfType<ScreenManager>();
        loadedSpash1 = Instantiate(splash1, Vector3.zero, canvas.transform.rotation) as Image;
        loadedSpash1.transform.SetParent(canvas.transform, false);

        loadedSpash2 = Instantiate(splash2, Vector3.zero, canvas.transform.rotation) as Image;
        loadedSpash2.transform.SetParent(canvas.transform, false);

        loadedSpash1.enabled = true;
        loadedSpash2.enabled = false;
        splash1shown = true;
    }

    // Update is called once per frame
    void Update() {
        timerScreenSwitch += Time.deltaTime;
        clickTimer += Time.deltaTime;

        if (splash1shown && !splash2shown && clickTimer >= clickSwitchTimer && (timerScreenSwitch >= switchTimer || Input.anyKey)) {
            SwitchSplashImage();
            splash2shown = true;
            timerScreenSwitch = 0;
            clickTimer = 0;
        }

        if (splash1shown && splash2shown && clickTimer >= clickSwitchTimer && (timerScreenSwitch >= switchTimer || Input.anyKey)) {
            //SM.SwitchScreen(ScreenManager.Screens.MAINMENU);
        }

    }

    private void SwitchSplashImage() {
        loadedSpash1.enabled = false;
        loadedSpash2.enabled = true;

    }

}
