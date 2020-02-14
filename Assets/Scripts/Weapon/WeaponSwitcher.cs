using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeaponIndex = 0;
    [SerializeField] WeaponZoom weaponZoom;


    // Start is called before the first frame update
    void Start()
    {
        SetActiveWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeaponIndex;

        ProcessKeyInput();
        ProcessScrollWheel();

        if(previousWeapon != currentWeaponIndex)
        {
            SetActiveWeapon();
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { currentWeaponIndex = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { currentWeaponIndex = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { currentWeaponIndex = 2; }
    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(currentWeaponIndex >= transform.childCount - 1)
            {
                currentWeaponIndex = 0;
            }
            else
            {
                currentWeaponIndex += 1;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeaponIndex <= 0)
            {
                currentWeaponIndex = transform.childCount - 1;
            }
            else
            {
                currentWeaponIndex -= 1;
            }
        }
    }

    void SetActiveWeapon()
    {
        int weaponIndex = 0;
        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeaponIndex) 
            { 
                weapon.gameObject.SetActive(true);
            }
            else 
            { 
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}
