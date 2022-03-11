using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject uiRoot;

    private bool onCredits = false;
    private float timePassed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(onCredits)
        {
            timePassed += Time.deltaTime;
            if (timePassed >= 5f)
            {
                onCredits = false;
                timePassed = 0f;
                LoadMenu();
            }
        }
    }


    public void LoadMainScene()
    {
        //uiRoot.SetActive(false);
        SceneManager.LoadScene("DemoScene");
    }

    public void LoadCredits()
    {
        onCredits = true;
        timePassed = 0f;

        SceneManager.LoadScene("CreditsSCene");
    }

    public void LoadMenu()
    {
        //uiRoot.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
}
