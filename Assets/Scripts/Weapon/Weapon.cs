using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10f;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;



    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && canShoot)
        {         
           StartCoroutine(Shoot());
        }
        
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (!muzzleFlash) { Debug.Log("Muzzle Flash Prefab Not linked to weapon"); yield break; }
        if (ammoSlot.GetAmmo(ammoType) <= 0) { print("Your out of Ammo"); yield break; }
        RaycastHit hit;       
        muzzleFlash.Play();
        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            SpawnHitEffect(hit);
            ammoSlot.UseAmmo(ammoType);

            EnemyHealth target = hit.collider.gameObject.GetComponent<EnemyHealth>();
            if (target)
            {
                target.TakeDamage(damage);
            }
            Debug.Log(hit.collider.gameObject.name);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void SpawnHitEffect(RaycastHit hit)
    {
        if (!hitEffect) { Debug.Log("HitEffect Particle Not Linked to weapon"); return; }
        ParticleSystem spawnedHitEffect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)) as ParticleSystem;
        Destroy(spawnedHitEffect.gameObject, 1f);
    }
}
