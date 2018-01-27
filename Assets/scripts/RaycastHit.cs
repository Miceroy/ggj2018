using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour {
    public Camera cam;
    float totalFilmedTime = 0;
    int hitsCount = 0;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Ray ray = cam.ScreenPointToRay(new Vector3(1280 / 2, 720 / 2, 0));
        UnityEngine.RaycastHit [] hits = Physics.RaycastAll(ray);
        bool nowHitting = false;
     //   Debug.Log("hits.Length:"+ hits.Length);
        for (int i=0; i< hits.Length; ++i)
        {
            TargetToFilm ttf = hits[i].transform.gameObject.GetComponent<TargetToFilm>();
            if (ttf && ttf.targetActive)
            {
              //  Debug.Log("Now hitting" + hitsCount);
                ++hitsCount;
                nowHitting = true;
                totalFilmedTime += Time.deltaTime;
                if(totalFilmedTime > ttf.timeToFilm)
                {
                    totalFilmedTime = 0;
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().targetFilmingCompleted(ttf);
                }
            }
        }

        if(nowHitting == false)
        {
         //   Debug.Log("Now hitting" + hits);
            totalFilmedTime -= Time.deltaTime;
            if (totalFilmedTime < 0) totalFilmedTime = 0;
        }

        if(totalFilmedTime > 0)
            GameObject.FindWithTag("GameController").GetComponent<GameController>().updateTotalFilmedTime(totalFilmedTime);
    }
}
