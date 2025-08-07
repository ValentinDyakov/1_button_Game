using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat_Manager : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    public Combat_UI_Manager UI_Manager;
    public InputMaster controls;
    public levelLoader lvlLoader;

    public TextMeshProUGUI text;

    private int player_damage;
    private int enemy_damage;

    public void Is_Winner()
    {
        controls = new InputMaster();
        int enemy_choise = enemy.current_selection;
        int player_choise = UI_Manager.current_selection;

        switch(player_choise)
        {
            case 1:
                player_damage = player.shield_damage;
                break;
            case 2:
                player_damage = player.sword_damage;
                break;
            case 3:
                player_damage = player.magic_damage;
                break;
        }

        switch(enemy_choise)
        {
            case 1:
                enemy_damage = enemy.shield_damage;
                break;
            case 2:
                enemy_damage = enemy.sword_damage;
                break;
            case 3:
                enemy_damage = enemy.magic_damage;
                break;
        }

        if(player_choise == 1 && enemy_choise == 2)
        {
            enemy.current_hp -= player_damage;
            UI_Manager.Update_Health();
        }
        else if(player_choise == 2 && enemy_choise == 3)
        {
            enemy.current_hp -= player_damage;
            UI_Manager.Update_Health();
        }
        else if(player_choise == 3 && enemy_choise == 1)
        {
            enemy.current_hp -= player_damage;
            UI_Manager.Update_Health();
        }
        else if(player_choise != enemy_choise)
        {
            player.current_hp -= enemy_damage;
            UI_Manager.Update_Health();
        }

        if (player.current_hp <= 0)
        {
            text.text = "You Lost :c";
            lvlLoader.Load_Main_Menu();
        }

        if (enemy.current_hp <= 0)
        {
            text.text = "You Won!";
            lvlLoader.loadNextLevel();
        }
    }

}
