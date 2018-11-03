//============================================================//
//                         Disable                            //
//============================================================//
//                  Created: 2018-01-09 9:15am                //
//                  Updated: 2017-XX-XX                       //
//                  Version 1.0.0                             //
//                  Revisions 0                               //
//============================================================//
// Author: Jonathan Thompson                                  //  
// Contact: @programmerJon | Mr.j.thompson@hotmail.ca         //
//============================================================//
// Used to Disable an object after a time.                    //
//============================================================//
//                   Resvision notes:                         //
//                                                            //
//                                                            //
//============================================================//
using UnityEngine;

public class DisableOnTime : MonoBehaviour{
    public float timeToDisable;

	void OnEnable(){
		Invoke("Disable", timeToDisable);
	}

	public void Disable(){
		gameObject.SetActive((false));
	}

	void OnDisable(){
		CancelInvoke();
	}
}
