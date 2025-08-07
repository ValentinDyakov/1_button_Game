using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu_input : MonoBehaviour
{
    public GameObject Canvas;
    mainMenu menu;
    public InputMaster controls;

    public void Awake()
    {
        menu = Canvas.GetComponent<mainMenu>();

        controls = new InputMaster();
        controls.Player.Hold.performed += ctx => Hold();
        controls.Player.Press.performed += ctx => Press();
    }

    public void Hold()
    {
        Debug.Log("hold");
        menu.Select();
    }

    public void Press()
    {
        Debug.Log("press");
        menu.Selection();
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
