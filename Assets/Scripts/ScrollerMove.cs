using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerMove : MonoBehaviour
{
    [SerializeField] private Transform endPosition;
    [SerializeField] private float speed;
    [SerializeField] private float stopTime;

    private Vector3 direction => endPosition.position - transform.position;

    private void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(stopTime);
        while (true)
        {
            transform.position += direction * speed * Mathf.Cos(Time.fixedTime * speed) * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
