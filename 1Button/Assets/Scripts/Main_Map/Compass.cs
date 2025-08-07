using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Compass : MonoBehaviour
{
    public TextMeshProUGUI Compass_Text;

    public void UpdateCompass(int rotation)
    {
        switch (rotation)
        {
            case 0:
                {
                    Compass_Text.text = "N";
                    break;
                }
            case 1:
                {
                    Compass_Text.text = "E";
                    break;
                }
            case 2:
                {
                    Compass_Text.text = "S";
                    break;
                }
            case 3:
                {
                    Compass_Text.text = "W";
                    break;
                }
        }
    }
}
