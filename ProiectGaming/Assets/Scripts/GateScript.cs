using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            string level = Random.Range(1,7).ToString();
            level = "Level" + level;

            GameManager.Instance.OpenNextLevel(level);
        }
    }
}
