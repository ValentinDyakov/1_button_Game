using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class mainMenu : MonoBehaviour
{
    public levelLoader lvlLoader;

    public GameObject newGame;
    public GameObject newGame_Highlighted;
    public GameObject exit;
    public GameObject exit_Highlighted;

    public TextAsset map_txt;

    public int current_selection;

    void Start()
    {
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Map_data/");
        string temp_map_txt_path = Application.streamingAssetsPath + "/Map_data/" + "temp_map.txt";

        if (!File.Exists(temp_map_txt_path))
        {
            File.WriteAllText(temp_map_txt_path, map_txt.ToString());
        }
        else
        {
            File.Delete(temp_map_txt_path);
            File.WriteAllText(temp_map_txt_path, map_txt.ToString());
        }
    }

    public void Selection()
    {
        switch (current_selection)
        {
            case 1:
                exit_Highlighted.SetActive(false);
                newGame_Highlighted.SetActive(true);

                current_selection = 2;
                break;
            case 2:
                exit_Highlighted.SetActive(true);
                newGame_Highlighted.SetActive(false);

                current_selection = 1;
                break;
        }
    }
    public void Select()
    {
        switch (current_selection)
        {
            case 2:
            {

                lvlLoader.loadNextLevel();
                Static_Variables.player_location_x = 1;
                Static_Variables.player_location_y = 1;
                Static_Variables.rotations = 0;
                break;
            }

            case 1:
                Application.Quit();
                break;
        }
    }
}
