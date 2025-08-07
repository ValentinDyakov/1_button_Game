using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Map_Generator : MonoBehaviour
{
    // Start is called before the first frame update


    public int width;
    public int height;

    public GameObject Wall;
    public GameObject Floor;
    public GameObject Enemy;
    public GameObject Boss;

    //public TextAsset text_map;
    public string temp_map_path;

    public Combat_Init combat_Init;

    public int[,] Init_map()
    {
        temp_map_path = Application.streamingAssetsPath + "/Map_data/" + "temp_map.txt";
        string input = File.ReadAllText(temp_map_path);
        Debug.Log(input);
        string[] y_split = input.Split('\n');
        string[] master_split = input.Split(',');
        int x_length = master_split.Length / y_split.Length;
        int[,] result = new int[y_split.Length, x_length];

        for (int y = 0 ; y < y_split.Length; y++)
        {
            for (int x = 0; x < x_length; x++)
            {
                int type = int.Parse(master_split[y * x_length + x]);
                result[y_split.Length - 1 - y,x] = type;
            }
        }

        return result;
    }

    public void Update_Map(int enemy_cords_x, int enemy_cords_y)
    {
        temp_map_path = Application.streamingAssetsPath + "/Map_data/" + "temp_map.txt";
        string input = File.ReadAllText(temp_map_path);
        string[] y_split = input.Split('\n');
        string[] master_split = input.Split(',');
        int x_length = master_split.Length / y_split.Length;
        int[,] result = new int[y_split.Length, x_length];

        //turn the text file into a matrix and remove the specific enemy
        for (int y = 0 ; y < y_split.Length; y++)
        {
            for (int x = 0; x < x_length; x++)
            {
                int type = int.Parse(master_split[y * x_length + x]);
                if (x == enemy_cords_x && y == y_split.Length - 1 - enemy_cords_y)
                {
                    type = 0;
                }
                result[y_split.Length - 1 - y,x] = type;
            }
        }

        //clear text file
        File.WriteAllText(temp_map_path, "");

        string dump = "";

        //write the updated matrix back into the text file
        for (int y = 0 ; y < y_split.Length; y++)
        {
            for (int x = 0; x < x_length; x++)
            {
                File.AppendAllText(temp_map_path, result[y_split.Length - 1 - y,x].ToString().Trim() + ",");
                dump += result[y_split.Length - 1 - y,x].ToString().Trim() + ",";
            }

            if (y != y_split.Length - 1)
            {
                dump += "\n";
                File.AppendAllText(temp_map_path, "\n");
            }
        }

        Debug.Log(dump);
    }

    void Start()
    {
        int [,] map = Init_map();

        width = map.GetLength(1);
        height = map.Length / map.GetLength(1);

        combat_Init.init();

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < height; x++)
            {
                Instantiate(Floor, new Vector3(y, 0, x), Quaternion.identity);
                Instantiate(Floor, new Vector3(y, 1, x), Quaternion.identity);
                switch (map[x,y])
                {
                    case 1:
                        {
                            Instantiate(Wall, new Vector3(y, 0.5f, x), Quaternion.identity);
                            break;
                        }
                    case 2:
                        {
                            combat_Init.Add_enemy(x, y, Random.Range(1,4));
                            Instantiate(Enemy, new Vector3(y, 0.5f, x), Quaternion.identity);
                            break;
                        }
                }
            }
        }
    }
}
