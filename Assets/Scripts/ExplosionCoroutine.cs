using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCoroutine : MonoBehaviour
{

    public GameObject winScreen;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Winner()
    {

        StartCoroutine(WinnerScreen());

    }


    IEnumerator WinnerScreen()
    {
        yield return new WaitForSeconds(3f);
        winScreen.SetActive(true);
    }

}
