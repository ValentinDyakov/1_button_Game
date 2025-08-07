using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Animator camera_animator;
    public Movement player_movement_script;
    public input input_script;

    void Start()
    {
        camera_animator.SetInteger("rotation", Static_Variables.rotations );
    }

    public void Rotate_Camera()
    {
        camera_animator.SetTrigger("Rotate");
    }

    public void Move_Camera()
    {
        //input_script.enabled = false;
        camera_animator.SetTrigger("Move_Forward");
    }

    public void Reset_Camera_Pos_North()
    {
        Debug.Log("Moved_Forward");
        player_movement_script.Move(new Vector3(0, 0, 1));
        //input_script.enabled = true;
    }
    public void Reset_Camera_Pos_East()
    {
        Debug.Log("Moved_Forward");
        player_movement_script.Move(new Vector3(1, 0, 0));
        //input_script.enabled = true;
    }
    public void Reset_Camera_Pos_South()
    {
        Debug.Log("Moved_Forward");
        player_movement_script.Move(new Vector3(0, 0, -1));
        //input_script.enabled = true;
    }
    public void Reset_Camera_Pos_West()
    {
        Debug.Log("Moved_Forward");
        player_movement_script.Move(new Vector3(-1, 0, 0));
        //input_script.enabled = true;
    }

}
