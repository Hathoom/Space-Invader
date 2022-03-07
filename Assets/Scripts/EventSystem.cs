using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    public UI ui;

    private float highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetFloat("highScore", 20);
        highScore = PlayerPrefs.GetFloat("highScore");
        ui.setHighScore(highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
