using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat_UI_Manager : MonoBehaviour
{
    //Managewa koi spritowe da se pokavat
    public GameObject Shield;
    public GameObject Shield_Highlighted;
    public GameObject Sword;
    public GameObject Sword_Highlighted;
    public GameObject Magic;
    public GameObject Magic_Highlighted;

    public GameObject Player_Shield_Sprite;
    public GameObject Player_Sword_Sprite;
    public GameObject Player_Magic_Sprite;

    public GameObject Enemy_Shield_Sprite;
    public GameObject Enemy_Sword_Sprite;
    public GameObject Enemy_Magic_Sprite;

    public GameObject Enemy_Hp_10;
    public GameObject Enemy_Hp_9;
    public GameObject Enemy_Hp_8;
    public GameObject Enemy_Hp_7;
    public GameObject Enemy_Hp_6;
    public GameObject Enemy_Hp_5;
    public GameObject Enemy_Hp_4;
    public GameObject Enemy_Hp_3;
    public GameObject Enemy_Hp_2;
    public GameObject Enemy_Hp_1;

    private GameObject[] Enemy_Health_Bars;

    public GameObject Player_Hp_10;
    public GameObject Player_Hp_9;
    public GameObject Player_Hp_8;
    public GameObject Player_Hp_7;
    public GameObject Player_Hp_6;
    public GameObject Player_Hp_5;
    public GameObject Player_Hp_4;
    public GameObject Player_Hp_3;
    public GameObject Player_Hp_2;
    public GameObject Player_Hp_1;

    private GameObject[] Player_health_Bars;

    public TextMeshProUGUI Player_Shield_Dmg;
    public TextMeshProUGUI Player_Sword_Dmg;
    public TextMeshProUGUI Player_Magic_Dmg;

    public TextMeshProUGUI Enemy_Shield_Dmg;
    public TextMeshProUGUI Enemy_Sword_Dmg;
    public TextMeshProUGUI Enemy_Magic_Dmg;

    public Enemy enemy;
    public Player player;
    public Combat_Manager manager;
    public int current_selection;

    public void Start()
    {
        GameObject[] temp1 = {Enemy_Hp_1, Enemy_Hp_2, Enemy_Hp_3, Enemy_Hp_4, Enemy_Hp_5, Enemy_Hp_6, Enemy_Hp_7, Enemy_Hp_8, Enemy_Hp_9, Enemy_Hp_10};
        Enemy_Health_Bars = temp1;
        GameObject[] temp2 = {Player_Hp_1, Player_Hp_2, Player_Hp_3, Player_Hp_4, Player_Hp_5, Player_Hp_6, Player_Hp_7, Player_Hp_8, Player_Hp_9, Player_Hp_10 };
        Player_health_Bars = temp2;

        Player_Shield_Dmg.text = player.shield_damage.ToString();
        Player_Sword_Dmg.text = player.sword_damage.ToString();
        Player_Magic_Dmg.text = player.magic_damage.ToString();

        Enemy_Shield_Dmg.text = enemy.shield_damage.ToString();
        Enemy_Sword_Dmg.text = enemy.sword_damage.ToString();
        Enemy_Magic_Dmg.text = enemy.magic_damage.ToString();
    }

    public void Update_Health()
    {
        for (int i = 0; i < Enemy_Health_Bars.Length; i++)
        {
            Enemy_Health_Bars[i].SetActive(false);
        }

        for (int i = 0; i < enemy.current_hp; i++)
        {
            Enemy_Health_Bars[i].SetActive(true);
        }
        
        for (int i = 0; i < Player_health_Bars.Length; i++)
        {
            Player_health_Bars[i].SetActive(false);
        }

        for (int i = 0; i < player.current_hp; i++)
        {
            Player_health_Bars[i].SetActive(true);
        }
    }

    public void Move()
    {
        //slaga za active highlighted spritowete spraqmo na koq opciq si rn i q updatewat
        switch(current_selection)
        {
            case 1:
                {
                    Shield_Highlighted.SetActive(false);
                    Sword_Highlighted.SetActive(true);

                    current_selection = 2;
                    break;
                }
            case 2:
                {
                    Sword_Highlighted.SetActive(false);
                    Magic_Highlighted.SetActive(true);

                    current_selection = 3;
                    break;
                }
            case 3:
                {
                    Magic_Highlighted.SetActive(false);
                    Shield_Highlighted.SetActive(true);

                    current_selection = 1;
                    break;
                }
        }
    }

    private void Show_Enemy_Selection()
    {
        int enemy_current_slection = enemy.Chose_Item();
        switch(enemy_current_slection)
        {
            case 1:
            {
                Enemy_Shield_Sprite.SetActive(true);
                Enemy_Sword_Sprite.SetActive(false);
                Enemy_Magic_Sprite.SetActive(false);
                break;
            }
            case 2:
            {
                Enemy_Shield_Sprite.SetActive(false);
                Enemy_Sword_Sprite.SetActive(true);
                Enemy_Magic_Sprite.SetActive(false);
                break;
            }
            case 3:
            {
                Enemy_Shield_Sprite.SetActive(false);
                Enemy_Sword_Sprite.SetActive(false);
                Enemy_Magic_Sprite.SetActive(true);
                break;
            }
        }
    }

    public void Select()
    {
        //player Sprite selction
        switch(current_selection)
        {
            case 1:
            {
                Player_Shield_Sprite.SetActive(true);
                Player_Sword_Sprite.SetActive(false);
                Player_Magic_Sprite.SetActive(false);
                break;
            }
            case 2:
            {
                Player_Shield_Sprite.SetActive(false);
                Player_Sword_Sprite.SetActive(true);
                Player_Magic_Sprite.SetActive(false);
                break;
            }
            case 3:
            {
                Player_Shield_Sprite.SetActive(false);
                Player_Sword_Sprite.SetActive(false);
                Player_Magic_Sprite.SetActive(true);
                break;
            }
        }
        
        //wait a bit?
        
        Show_Enemy_Selection();

        //Wait a bit?

        //Chose Winner
        manager.Is_Winner();
    }
}
