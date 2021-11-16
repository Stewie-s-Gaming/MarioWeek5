using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter player = other.GetComponent<ScoreCounter>();
        if (player)
        {
            player.CollectCoin();
            Destroy(this.gameObject);
        }
    }
}
