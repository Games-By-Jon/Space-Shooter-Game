//============================================================//
//                         Laser                              //
//============================================================//
//                  Created: 2017-08-17 4:45pm                //
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

public class Laser : MonoBehaviour {
    public float movementSpeed;
    public float damage;

    public enum shotType{
        SINGLE,
        DOUBLE,
        TRIPLE,
        QUAD
    };

    public shotType currentShotType = shotType.SINGLE;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, movementSpeed);
	}

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemy"){
            switch(currentShotType){
                case shotType.SINGLE:
                    GetComponent<LaserDisable>().Disable();
                    break;

				case shotType.DOUBLE:
                case shotType.TRIPLE:
                case shotType.QUAD:
                    GetComponentInParent<LaserDisable>().Disable();
                    break;
            }
            //GetComponent<LaserDisable>().Disable();
        }
    }
}
