using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    public void DealDamageToPlayer(int damage)
    {
        FindObjectOfType<PlayerHealth>().PlayerTakeDamage(damage);
    }


}
