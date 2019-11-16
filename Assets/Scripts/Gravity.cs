using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    const float speed = 9.81f;
    private void Update()
    {
        Physics.gravity = -transform.up * speed;
    }
}
