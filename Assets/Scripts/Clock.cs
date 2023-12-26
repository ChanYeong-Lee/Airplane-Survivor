using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public static Clock Instance { get; private set; }
    [HideInInspector] public int minutes;
    [HideInInspector] public int seconds;
    private float count;
    private bool running;
    public bool Running { get { return running; } }
    public void Awake()
    {
        Instance = this;
        ResetClock();
    }

    public void ResetClock()
    {
        running = false;
        count = 0;
        minutes = 0;
        seconds = 0;
    }

    public void StartClock()
    {
        running = true;
    }

    public void StopClock()
    {
        running = false;
    }

    private void Update()
    {
        if (running)
        {
            count += Time.deltaTime;
            if (count >= 1)
            {
                count -= 1;
                seconds++;
                GameManager.Instance.player.Score++;
                if (seconds >= 60)
                {
                    minutes++;
                    seconds -= 60;
                }
            }
        }
    }
}
