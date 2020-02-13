﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        if (!muzzleFlash) { Debug.Log("Muzzle Flash Prefab Not linked to weapon"); return; }
        RaycastHit hit;       
        muzzleFlash.Play();

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            EnemyHealth target = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (target)
            {
                target.TakeDamage(damage);
            }
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            return;
        }
             
    }
}
