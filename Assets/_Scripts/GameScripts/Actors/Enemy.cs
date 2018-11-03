//============================================================//
//                         Enemy                              //
//============================================================//
//                  Created: 2017-08-22 12:21 am              //
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

public class Enemy : MonoBehaviour {
    public int scoreWorth;
    public bool onScreen = false;

    void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Weapon"){
			GameObject.Find("Player").GetComponent<Player>().ChangeScore(scoreWorth);
            GameObject.Find("Player").GetComponent<Player>().killCount++;
            TriggerExplosion();
            DisplayScore();
			Disable();
		}

		if (other.gameObject.tag == "Screen"){
			onScreen = true;
		}
    }

    private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Screen"){
            onScreen = false;
		}
    }

    public void TriggerExplosion(){
        FindObjectOfType<EnemyManager>().SpawnParticalHalo(transform.position);
    }

    public void Disable(){
        onScreen = false;
		gameObject.SetActive((false));
	}

    public void DisplayScore(){
		TextPopupController.CreatePopupText(scoreWorth.ToString(), transform);
    }
}
