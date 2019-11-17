using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float timeForImmortality;
    [SerializeField] private float hp;
    [SerializeField] private List<Transform> items;

    private float timer;

    public float HP => hp;

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    public void Damage(float power)
    {
        if (timer <= 0)
        {
            hp -= 1;
            timer = Time.timeScale + timeForImmortality;
        }
    }

    public void Heal(float power)
    {
        hp += power;
    }

    public void GetItem(Transform item)
    {
        items.Add(item);
    }
}
