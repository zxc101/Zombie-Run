using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private EPlayerItemTypes type;
    [SerializeField] private float power;

    private void OnTriggerStay(Collider collider)
    {
        Player player = GetPlayer(collider.transform).GetComponent<Player>();
        if (player.tag == "Player")
        {
            if (player != null)
            {
                if(type == EPlayerItemTypes.Enemy)
                {
                    player.Damage(power);
                }
                else if (type == EPlayerItemTypes.Heal)
                {
                    player.Heal(power);
                    transform.gameObject.SetActive(false);
                }
                else
                {
                    player.GetItem(transform);
                    transform.gameObject.SetActive(false);
                }
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
