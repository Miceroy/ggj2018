using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void targetFilmingCompleted(TargetToFilm ttf)
    {
        Debug.Log("targetFilmingCompleted! Got Score: "+ ttf.scoreValue);
    }

    public void updateTotalFilmedTime(float totalFilmedTime)
    {
        Debug.Log("totalFilmedTime=" + totalFilmedTime);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
