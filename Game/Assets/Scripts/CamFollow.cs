using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
   public Transform target;
    public float smoothTime = 0.3f;
    public float zSmooth = -2f;
    public float xSmooth = 0f;


    void FixedUpdate()
 {
     if(target == null) {
        if( GameObject.FindGameObjectWithTag("Player") != null) {
                target = GameObject.FindGameObjectWithTag("Player").transform;
         }
         
     }
      Vector3 targetPos = new Vector3() {
          x = target.position.x + xSmooth,
          y = target.position.y + zSmooth,
          z = target.position.z - 10,
      };

      Vector3 pos = Vector3.Lerp(transform.position, targetPos, 3 * Time.deltaTime);  
     transform.position = pos;
 }


    
}
