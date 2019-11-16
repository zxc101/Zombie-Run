using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        PlayerHealth playerHP = GetPlayer(collider.transform).GetComponent<PlayerHealth>();
        if (playerHP.tag == "Player")
        {
            if (playerHP != null)
            {
                playerHP.Damage();
            }
        }
    }

    private Transform GetPlayer(Transform player)
    {
        if (player.parent == null)
        {
            return player;
        }
        else
        {
            return GetPlayer(player.parent);
        }
    }
}
