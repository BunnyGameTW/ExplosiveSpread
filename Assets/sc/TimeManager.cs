using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    [SerializeField]
    private float currentTimeScale;

    public enum TimeSpeed {
        speedX075,
        speedX1,
        speedX125,
        speedX15,
        speedX2,
    }

    TimeSpeed timeSpeed;

    public void Init()
    {
        currentTimeScale = 1;
        timeSpeed = TimeSpeed.speedX1;
    }

    public void OnUpdate()
    {
        Time.timeScale = currentTimeScale;
    }

    public void timeTurnFast()
    {
        if (timeSpeed == TimeSpeed.speedX2)
            timeSpeed = TimeSpeed.speedX2;
        else {
            timeSpeed++;
        }

        currentTimeScale = getSpeed(timeSpeed);
    }

    public void timeTurnSlow()
    {
        if (timeSpeed == TimeSpeed.speedX075)
            timeSpeed = TimeSpeed.speedX075;
        else
        {
            timeSpeed--;
        }

        currentTimeScale = getSpeed(timeSpeed);
    }

    float getSpeed(TimeSpeed sp)
    {
        if (sp == TimeSpeed.speedX075)
            return 0.75f;
        else if(sp == TimeSpeed.speedX1)
            return 1;
        else if (sp == TimeSpeed.speedX125)
            return 1.25f;
        else if (sp == TimeSpeed.speedX15)
            return 1.5f;
        else if (sp == TimeSpeed.speedX2)
            return 2f;

        Debug.Log("time speed error");
        return 1;

    }
}
