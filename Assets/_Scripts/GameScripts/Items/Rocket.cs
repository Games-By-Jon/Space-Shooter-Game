//============================================================//
//                         Rocket                             //
//============================================================//
//                  Created: 2017-08-21 9:55                  //
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

public class Rocket : MonoBehaviour {
	public float movementSpeed;
    public GameObject middleOfScreen;
	//public float damage;

	void Update()	{
        //transform.LookAt(middleOfScreen.transform.position);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, movementSpeed);
	}

	void OnEnable()
	{
		Invoke("Disable", 1f);
	}

	void Disable()
	{
        FindObjectOfType<EnemyManager>().KillAllEnemiesOnScreen();
		gameObject.SetActive((false));
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}
