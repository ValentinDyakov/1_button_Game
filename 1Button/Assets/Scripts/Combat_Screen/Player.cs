using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int current_hp;
    public int shield_damage;
    public int sword_damage;
    public int magic_damage;

    public void Set_Stats()
    {
        shield_damage = Static_Variables.player_shield_damage;
        sword_damage = Static_Variables.player_sword_damage;
        magic_damage = Static_Variables.player_magic_damage;
    }
}
