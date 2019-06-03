using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Pistol left, right;
    public Text currScore, highScore, timer;
    public int duration = 30;
    public bool isCountingDown = false;

    int curr = 0, high = 0, timeRemaining;
    StartGame start;
    AudioSource startSound;

    void Start () {
        start = GetComponent<StartGame>();
        startSound = GetComponent<AudioSource>();
	}
	
	void Update () {
		
	}

    public void Begin()
    {
        startSound.Play();
        timer.text = duration.ToString();

        if (!isCountingDown)
        {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("Tick", 1f);
        }

        left.enabled = true;
        right.enabled = true;
    }

    private void Tick()
    {
        timeRemaining--;
        timer.text = timeRemaining.ToString();

        if (timeRemaining > 0)
        {
            Invoke("Tick", 1f);
        }
        else
        {
            left.enabled = false;
            right.enabled = false;
            curr = 0;
            currScore.text = curr.ToString();
            isCountingDown = false;
            start.enabled = true;
        }
        
    }

    public void TargetHit()
    {
        if (isCountingDown)
        {
            curr++;
            currScore.text = curr.ToString();

            if (curr > high)
            {
                high = curr;
                highScore.text = high.ToString();
            }
        }
    }
}
