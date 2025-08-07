using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Animation : MonoBehaviour
{
    public levelLoader lvlLoader;
    public void enemyCollision()
    {
        lvlLoader.loadNextLevel();
    }
}
