using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float timeForImmortality;
    [SerializeField] private float hp;

    private float timer;

    public float HP => hp;

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    public void Damage()
    {
        if (timer <= 0)
        {
            hp -= 1;
            timer = Time.timeScale + timeForImmortality;
        }
    }
}
