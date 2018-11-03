//============================================================//
//                         Laser Disable                      //
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

public class LaserDisable : MonoBehaviour {

    void OnEnable(){
        Invoke("Disable", 1.75f);
    }

    public void Disable(){
        gameObject.SetActive((false));
    }

    void OnDisable(){
        CancelInvoke();
    }
}
