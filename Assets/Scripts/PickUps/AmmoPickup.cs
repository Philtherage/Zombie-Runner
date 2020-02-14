using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    [SerializeField] AmmoType ammoType;
    [SerializeField] int amount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Ammo>().AddAmmo(ammoType, amount);
            Destroy(gameObject);
        }

    }

}
