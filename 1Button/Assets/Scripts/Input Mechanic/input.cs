using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    public Movement movement;
    public InputMaster controls;
    private void Awake()
    {
        controls = new InputMaster();;
        controls.Player.Hold.performed += ctx => Hold();
        controls.Player.Press.performed += ctx => Press();
    }

    private void Press()
    {
        Debug.Log("Press");
        movement.Move();
    }

    private void Hold()
    {
        Debug.Log("Hold");
        controls.Player.Press.canceled += ctx => Awake();
        movement.Rotate();
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
