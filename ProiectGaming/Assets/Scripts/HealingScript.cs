using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingScript : MonoBehaviour
{
    public float healingAmmount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            var player = collision.GetComponent<PlayerManager>();
            player.Heal(healingAmmount);
            Destroy(gameObject);
        }
    }
}
