//============================================================//
//                  Scrolling Texture                         //
//============================================================//
//                  Created: 2017-08-16 9:10pm                //
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

public class ScrollingTexture : MonoBehaviour {
    public enum Axis{
        x,
        y
    }
    public float scollingSpeed;
    public Axis axisToRotate;
    Vector2 offset;
    private void Update(){
        float displacement = Mathf.Repeat(Time.time * scollingSpeed, 1);

        if(axisToRotate == Axis.x){
            offset = new Vector2(displacement, 0);
        }else if(axisToRotate == Axis.y){
            offset = new Vector2(0, displacement);
        }

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);

    }
}
