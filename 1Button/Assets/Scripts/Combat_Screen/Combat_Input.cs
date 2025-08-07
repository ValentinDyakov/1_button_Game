using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Input : MonoBehaviour
{
    //input manager obache za combat
    public Combat_UI_Manager UI_Manager;
    public Player player;
    public InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Hold.performed += ctx => Hold();
        controls.Player.Press.performed += ctx => Press();
        player.Set_Stats();
    }

    private void Press()
    {
        UI_Manager.Move();
    }

    private void Hold()
    {
        controls.Player.Press.canceled += ctx => Awake();
        UI_Manager.Select();
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
