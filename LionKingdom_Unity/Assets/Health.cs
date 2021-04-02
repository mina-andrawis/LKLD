using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Player player = GameObject.FindWithTag(Player);
    
    public void OnDestroy()
    {
        player.TakeDamage(-10);
    }
}
