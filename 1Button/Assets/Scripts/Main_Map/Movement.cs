using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    
    public GameObject Compass_Obj;
    public Compass compass;

    public Combat_Animation cbAnim;

    Map_Generator map_gen;
    public GameObject Map_Gen_Object;

    public TextAsset text_map;

    public Combat_Init combat_Init;

    public cameraMovement camera_movement_script;

    int[,] map;
    int[] map_Position = {1,1};

    public int rotations = 0;
    [SerializeField] public Vector3 rotation_amount;
    void Start()
    {
        compass = Compass_Obj.GetComponent<Compass>();
        
        map_gen = Map_Gen_Object.GetComponent<Map_Generator>();
        map = map_gen.Init_map();

        map_Position[0] = Static_Variables.player_location_x;
        map_Position[1] = Static_Variables.player_location_y;

        transform.localPosition = new Vector3(map_Position[1], 0.5f, map_Position[0]);

        for (int i = 0; i < Static_Variables.rotations; i++)
        {
            if (rotations < 3)
                rotations++;
                
            else
                rotations = 0;

            compass.UpdateCompass(rotations);
        }
    }

    public void Move()
    {
        switch (rotations)
        {
            case 0:
            {
                //camMove.cameraMove(new Vector3(0, 0, 1));
                Check_Collision(new int[] {map_Position[0] + 1, map_Position[1]}/*, new Vector3(0, 0, 1) */);
                break;
            }
            case 1:
            {
                //camMove.cameraMove(new Vector3(1, 0, 0));
                Check_Collision(new int[] {map_Position[0], map_Position[1] + 1}/*, new Vector3(1, 0, 0) */);
                break;
            }
            case 2:
            {
                //camMove.cameraMove(new Vector3(0, 0, -1));
                Check_Collision(new int[] {map_Position[0] - 1, map_Position[1]}/*, new Vector3(0, 0, -1) */);
                break;
            }
            case 3:
            {
                Check_Collision(new int[] {map_Position[0], map_Position[1] - 1}/*, new Vector3(-1, 0, 0) */);
                break;
            }
        }
    }

    void Check_Collision(int[] collision_cords)
    {
        switch(map[collision_cords[0], collision_cords[1]])
        {
            case 0:
            {
                map_Position = collision_cords;
                camera_movement_script.Move_Camera();
                break;
            }
            case 2:
            {

                int enemy_index = 0;
                map_Position = collision_cords;

                for (int i = 0; i < combat_Init.Enemies.Count; i++)
                {
                    if (combat_Init.Enemies[i].x_location == collision_cords[0] && combat_Init.Enemies[i].y_location == collision_cords[1])
                    {
                        enemy_index = i;
                        break;
                    }
                }

                Debug.Log("Atacked enemy at x: " + combat_Init.Enemies[enemy_index].y_location + " y: " + combat_Init.Enemies[enemy_index].x_location);
                


                Static_Variables.player_location_x = map_Position[0];
                Static_Variables.player_location_y = map_Position[1];
                Static_Variables.rotations = rotations;

                camera_movement_script.Move_Camera();

                combat_Init.Update_Static_Variables(enemy_index);
                map_gen.Update_Map(combat_Init.Enemies[enemy_index].y_location,combat_Init.Enemies[enemy_index].x_location);
                cbAnim.enemyCollision();
                break;
            }
        }
    }

    public void Move(Vector3 move_vector)
    {
        transform.localPosition = transform.localPosition + move_vector;
    }
    public void Rotate()
    {
        Debug.Log(rotations);
        camera_movement_script.Rotate_Camera();
        //transform.Rotate(rotation_amount);
        if (rotations < 3)
            rotations++;
            
        else
            rotations = 0;

        compass.UpdateCompass(rotations);
    }
}
