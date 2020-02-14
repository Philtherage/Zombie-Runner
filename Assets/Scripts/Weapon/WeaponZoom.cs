using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float timeBetweenZoom = 1f;

    [SerializeField] float mouseSpeedXIN = 1f;
    [SerializeField] float mouseSpeedYIN = 1f;

    [SerializeField] RigidbodyFirstPersonController fpController;

    float oldMouseSensitivityX = 2;
    float oldMouseSensitivityY = 2;
    bool isZoomed = false;

    

    // Start is called before the first frame update
    void Start()
    {
        oldMouseSensitivityX = fpController.mouseLook.XSensitivity;
        oldMouseSensitivityY = fpController.mouseLook.YSensitivity;
    }

    // Update is called once per frame
    void Update()
    {              
        Zoom();
    }

    private void Zoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isZoomed = !isZoomed;
        }
        if (isZoomed)
        {
            FPCamera.fieldOfView = Mathf.Lerp(zoomedOut, zoomedIn, timeBetweenZoom);
            fpController.mouseLook.XSensitivity = mouseSpeedXIN;
            fpController.mouseLook.YSensitivity = mouseSpeedYIN;
        }
        else if (!isZoomed)
        {
            FPCamera.fieldOfView = Mathf.Lerp(zoomedIn, zoomedOut, timeBetweenZoom);
            fpController.mouseLook.XSensitivity = oldMouseSensitivityX;
            fpController.mouseLook.YSensitivity = oldMouseSensitivityY;

        }
        
    }

    private void OnDisable()
    {
        ZoomOutOnWeaponSwitch();
    }

    private void ZoomOutOnWeaponSwitch()
    {
        if (isZoomed)
        {
            isZoomed = false;
        }
        FPCamera.fieldOfView = Mathf.Lerp(zoomedIn, zoomedOut, timeBetweenZoom);
        fpController.mouseLook.XSensitivity = oldMouseSensitivityX;
        fpController.mouseLook.YSensitivity = oldMouseSensitivityY;
    }
}
