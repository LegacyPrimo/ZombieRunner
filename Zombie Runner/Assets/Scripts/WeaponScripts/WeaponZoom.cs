using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float defaultFieldOfView = 60f;
    [SerializeField] private float closerFieldOfView = 20f;

    [SerializeField] private bool zoomKeyPressed;
    [SerializeField] private bool canZoom;

    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private float defaultMouseSensitivity = 4f;
    [SerializeField] private float focusedMouseSensitivity = 1.5f;

    // Update is called once per frame
    void Update()
    {
        ChangeFieldOfView();
    }

    private void ChangeFieldOfView() 
    {
        if (Input.GetButtonDown("Fire2") && canZoom == true)
        {
            zoomKeyPressed = !zoomKeyPressed;
            ConfigureFieldOfView(zoomKeyPressed);
        }
        else if(canZoom == false)
        {
            ResetFieldOfView();
        }

    }

    private void ConfigureFieldOfView(bool isPressed) 
    {
        if (isPressed == true)
        {
            camera.fieldOfView = closerFieldOfView;
            firstPersonController.m_MouseLook.XSensitivity = focusedMouseSensitivity;
            firstPersonController.m_MouseLook.YSensitivity = focusedMouseSensitivity;
            
        }

        if(isPressed == false )
        {
            camera.fieldOfView = defaultFieldOfView;
            firstPersonController.m_MouseLook.XSensitivity = defaultMouseSensitivity;
            firstPersonController.m_MouseLook.YSensitivity = defaultMouseSensitivity;
        }
    }

    private void ResetFieldOfView() 
    {
        camera.fieldOfView = defaultFieldOfView;
        firstPersonController.m_MouseLook.XSensitivity = defaultMouseSensitivity;
        firstPersonController.m_MouseLook.YSensitivity = defaultMouseSensitivity;
    }
}
