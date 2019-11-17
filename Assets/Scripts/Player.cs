using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private float timeForImmortality;
    [SerializeField] private float maxHP;
    [SerializeField] private List<Transform> items;

    private float hp;
    private float timer;
    private List<Rigidbody> rbs;

    public float HP => hp;

    private void Start()
    {
        hp = maxHP;
        healthText.text = $"HP: {hp}";
    }

    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
    }

    private void GetRigidBody(Transform t)
    {
        foreach(Transform child in t)
        {
            if (child.GetComponent<Rigidbody>())
            {
                rbs.Add(child.GetComponent<Rigidbody>());
            }
            GetRigidBody(child);
        }
    }

    public void Damage(float power)
    {
        if (hp == 0)
        {
            gameOverText.text = "You Dead!";
            for(int i = 0; i < rbs.Count; i++)
            {
                rbs[i].isKinematic = false;
            }
        }
        if (timer <= 0 && hp > 0)
        {
            Debug.Log("zxc");
            hp -= 1;
            healthText.text = $"HP: {hp}";
            timer = Time.timeScale + timeForImmortality;
        }
    }

    public void Heal(float power)
    {
        if (hp < maxHP)
        {
            hp += power;
            healthText.text = $"HP: {hp}";
        }
    }

    public void GetItem(Transform item)
    {
        items.Add(item);
    }
}
