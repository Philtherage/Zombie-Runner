using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float timeBetweenZoom = 1f;


    bool isZoomed = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
        else if (!isZoomed)
        {
            FPCamera.fieldOfView = Mathf.Lerp(zoomedIn, zoomedOut, timeBetweenZoom);
        }
        
    }
}
