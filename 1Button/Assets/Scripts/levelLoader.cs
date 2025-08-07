using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public void loadNextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            StartCoroutine(loadLevel(0));
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            StartCoroutine(loadLevel(5));
        }
        else
        {
            StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void Load_Main_Menu()
    {
        StartCoroutine(loadLevel(0));
    }
    public void Load_Game_End()
    {
        StartCoroutine(loadLevel(3));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        Debug.Log(levelIndex);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
