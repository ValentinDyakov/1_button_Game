using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public void wait(int seconds)
    {
        StartCoroutine(waitFunc(seconds));
    }

    IEnumerator waitFunc(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
