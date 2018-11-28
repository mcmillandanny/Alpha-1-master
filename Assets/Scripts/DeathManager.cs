using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {

    public GameObject killScreen;

	// Use this for initialization
	void Start () {


		
	}

    public void OnDeath(){

        StartCoroutine(KillAndReloadScene());

    }

    // Update is called once per frame
    IEnumerator KillAndReloadScene()
    {
        killScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
