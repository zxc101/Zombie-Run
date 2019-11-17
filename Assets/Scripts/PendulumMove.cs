using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stopTime;
    [SerializeField] private float angle;
    
    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(stopTime);
        while (true)
        {
            Quaternion target = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                                 transform.rotation.eulerAngles.y,
                                                 transform.rotation.eulerAngles.z + angle * Mathf.Cos(Time.fixedTime));
            
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.fixedDeltaTime * speed);
            yield return new WaitForFixedUpdate();
        }
    }
}
