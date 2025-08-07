using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Init : MonoBehaviour
{
    public List<Enemy_Stats> Enemies;

    public Player player;

    public void init()
    {
        Enemies = new List<Enemy_Stats>();
    }

    public void Add_enemy(int x, int y, int buffed_stat)
    {
        Enemies.Add(new Enemy_Stats(x, y, buffed_stat));
        //Debug.Log("Added enemy at \nx = " + x + " y = " + y);
    }

    public void Update_Static_Variables(int enemy_index)
    {
        //update Player Stats
        Static_Variables.player_shield_damage = player.shield_damage;
        Static_Variables.player_sword_damage = player.sword_damage;
        Static_Variables.player_magic_damage = player.magic_damage;

        Static_Variables.enemy_shield_damage = Enemies[enemy_index].Shield_damage;
        Static_Variables.enemy_sword_damage = Enemies[enemy_index].Sword_damage;
        Static_Variables.enemy_magic_damage = Enemies[enemy_index].Magic_damage;
    }
}

public struct Enemy_Stats
{
    public int x_location;
    public int y_location;
    public int Shield_damage;
    public int Sword_damage;
    public int Magic_damage;

    public Enemy_Stats(int x, int y, int buffed_stat)
    {
        x_location = x;
        y_location = y;
        switch(buffed_stat)
        {
            case 1:
            {
                Shield_damage = 2;
                Sword_damage = 1;
                Magic_damage = 1;
                break;
            }
            case 2:
            {
                Shield_damage = 1;
                Sword_damage = 2;
                Magic_damage = 1;
                break;
            }
            case 3:
            {
                Shield_damage = 1;
                Sword_damage = 1;
                Magic_damage = 2;
                break;
            }
            default:
            {
                Shield_damage = 1;
                Sword_damage = 1;
                Magic_damage = 1;
                break;
            }
        }
    }
}