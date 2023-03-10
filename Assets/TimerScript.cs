using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float Timer = 0;

    TMP_Text TimerDisplay;
    Animator TimerAnim;

    private void Awake()
    {
        TimerDisplay = GetComponentInChildren<TMP_Text>();
        TimerAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.Instance.GetComponent<SingleGamemode>().GameFinished.AddListener(ExpandTimer);
    }

    void Update()
    {
        Timer += Time.deltaTime;
        DisplayTime(Timer);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        TimerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ExpandTimer()
    {
        TimerAnim.SetTrigger("ExpandTimer");
    }

    public void FreezeTime()
    {
        Time.timeScale = 0.0f;
    }
}
