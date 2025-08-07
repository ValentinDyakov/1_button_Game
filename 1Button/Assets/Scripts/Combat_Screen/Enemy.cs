using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //tuka sa neshtata swyrzani s enemito, za sega prosto move da izbira na random edna opciq
    public int current_selection;
    public int current_hp;

    private int player_previous_selection;
    private int player_previous_selection_X2;

    public int shield_damage;
    public int sword_damage;
    public int magic_damage;

    private int previous_decision;

    public Combat_UI_Manager UI_Manager;

    public int turn;

    void Awake()
    {
        shield_damage = Static_Variables.enemy_shield_damage;
        sword_damage = Static_Variables.enemy_sword_damage;
        magic_damage = Static_Variables.enemy_magic_damage;
    }

    public int Chose_Item()
    {
        turn++;

        player_previous_selection_X2 =player_previous_selection;
        player_previous_selection = UI_Manager.current_selection;


        if(player_previous_selection == player_previous_selection_X2)
        {
            Debug.Log("Caught you ;)");
            if (Random.Range(1,4) == 1)
            {
                Debug.Log("HA HA HA!");
                switch(player_previous_selection)
                {
                    case 1:
                        current_selection =  3;
                        break;
                    case 2:
                        current_selection = 1;
                        break;
                    case 3:
                        current_selection = 2;
                        break;
                }
            }
        }
        else
        {
            current_selection =  Random.Range(1,4);
        }

        return current_selection;
    }
}
