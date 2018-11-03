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

public class TripleLaser : MonoBehaviour
{
	public float movementSpeedForward;
	public float movementSpeedSide;
	public float damage;

	void Update()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(movementSpeedSide, movementSpeedForward);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			GetComponent<LaserDisable>().Disable();
		}
	}
}
