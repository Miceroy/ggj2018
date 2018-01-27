﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour {
    public Camera cam;
    float totalFilmedTime = 0;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Ray ray = cam.ScreenPointToRay(new Vector3(1280 / 2, 720 / 2, 0));
        UnityEngine.RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TargetToFilm ttf = hit.transform.gameObject.GetComponent<TargetToFilm>();
            if (ttf)
            {
                totalFilmedTime += Time.deltaTime;
                if(totalFilmedTime > ttf.timeToFilm)
                {
                    totalFilmedTime = 0;
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().targetFilmingCompleted(ttf);
                }
            }
        }
        else
        {
            totalFilmedTime -= Time.deltaTime;
            if (totalFilmedTime < 0) totalFilmedTime = 0;
        }

        if(totalFilmedTime > 0)
            GameObject.FindWithTag("GameController").GetComponent<GameController>().updateTotalFilmedTime(totalFilmedTime);
    }
}