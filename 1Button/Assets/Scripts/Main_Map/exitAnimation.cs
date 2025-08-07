using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitAnimation : MonoBehaviour
{
    public levelLoader lvlLoader;
    public void exitAnim()
    {
        lvlLoader.loadNextLevel();
    }
}
