using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime=0f;
    private float startTime=60f;
    public Text countdownText;
    private PlayerController plcontroller;
   
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        countdownText.text = "";
        plcontroller = GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        countDown(currentTime);
        
        if (plcontroller.wintxt2.text == "You won the game! Click the player to exit."){
            currentTime = 0;
        }

        else if (currentTime <= 0) {
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        }
    }

    void countDown(float currenttime) {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("00:00");
    }
}
