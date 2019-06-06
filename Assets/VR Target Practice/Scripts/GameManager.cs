using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Pistol left, right;

    AudioSource startSound;
    StartGame start;
    //static TextMeshPro currScore, highScore, timer;
    static int duration = 30;
    static bool isCountingDown = false;
    static int curr = 0, high = 0, timeRemaining;


    GameManager instance;

    void Start() {
        instance = this;
        start = GetComponent<StartGame>();
        startSound = GetComponent<AudioSource>();
    }

    public void Begin() {
        startSound.Play();
        //timer.text = duration.ToString();

        if (!isCountingDown) {
            isCountingDown = true;
            timeRemaining = duration;
            Invoke("Tick", 1f);
        }

        left.enabled = true;
        right.enabled = true;
    }

    public static bool Playing() {
        return isCountingDown;
    }

    private void Tick() {
        timeRemaining--;
        //timer.text = timeRemaining.ToString();

        if (timeRemaining > 0) {
            Invoke("Tick", 1f);
        } else {
            Debug.Log("ending game, score is " + curr);
            //Game over
            left.enabled = false;
            right.enabled = false;
            curr = 0;
            //currScore.text = curr.ToString();
            isCountingDown = false;
            start.enabled = true;
        }

    }

    public static void TargetHit(int type) {
        if (isCountingDown) {
            curr++;
            //currScore.text = curr.ToString();

            if (curr > high) {
                high = curr;
                //highScore.text = high.ToString();
            }
        }
    }
}
