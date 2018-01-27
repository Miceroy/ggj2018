using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject goToActivate;

    public void targetFilmingCompleted(TargetToFilm ttf)
    {
        Debug.Log("targetFilmingCompleted! Got Score: "+ ttf.scoreValue);
        endMission();
        Invoke("startMission", 5);
    }

    void startMission()
    {
        goToActivate.active = true;
    }

    void endMission()
    {
        goToActivate.active = false;
    }

    public void updateTotalFilmedTime(float totalFilmedTime)
    {
      //  Debug.Log("totalFilmedTime=" + totalFilmedTime);
    }

    // Use this for initialization
    void Start()
    {
        Invoke("startMission", 5);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
