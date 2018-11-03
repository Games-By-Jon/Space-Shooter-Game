//============================================================//
//                         PickUp                             //
//============================================================//
//                  Created: 2017-08-21 7:14                  //
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

public class PickUp : MonoBehaviour {
    //blic GameObject player;
    public enum pickUpTypes{
        missilePickUp,
        doubleShotPickUp,
        tripleShotPickUp,
        quadShotPickUp,
        extraLifePickUp
    }

    public pickUpTypes pickUpType = pickUpTypes.missilePickUp;
    public float movementSpeed;
    public int scoreWorth;

    void FixedUpdate(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -movementSpeed);
    }

	void Disable(){
		gameObject.SetActive((false));
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            TextPopupController.CreatePopupText(scoreWorth.ToString(), transform);
            GameObject.Find("Player").GetComponent<Player>().ChangeScore(scoreWorth);
            Disable();
        }
    }
}
