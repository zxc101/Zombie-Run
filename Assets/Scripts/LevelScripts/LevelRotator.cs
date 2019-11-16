using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotator : MonoBehaviour
{
   public Transform target;

   void Update()
   {
       if (Input.GetKeyDown(KeyCode.Q))
       {
           Rotate(-90);
       }

       if (Input.GetKeyDown(KeyCode.E))
       {
           Rotate(90);
       }
    }

   void Rotate(int angle)
   {
       transform.RotateAround(target.transform.position,Vector3.left,angle);
   }

}
