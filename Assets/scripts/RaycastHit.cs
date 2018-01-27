using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour {
    public CrosshairController crosshair;
    public Camera cam;
    float totalFilmedTime = 0;
    int hitsCount = 0;
    float decreaseCooldown;
    //bool prevHitting;
    // Use this for initialization
    void Start () {
        decreaseCooldown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Ray ray = cam.ScreenPointToRay(new Vector3(1280 / 2, 720 / 2, 0));
        UnityEngine.RaycastHit [] hits = Physics.RaycastAll(ray);
        bool nowHitting = false;
        for (int i=0; i< hits.Length; ++i)
        {
            TargetToFilm ttf = hits[i].transform.gameObject.GetComponent<TargetToFilm>();
            if (ttf && ttf.targetActive)
            {
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

        crosshair.setFocus(nowHitting);
        if(nowHitting)
            decreaseCooldown = 0;
        else
            decreaseCooldown += Time.deltaTime;

        if (nowHitting == false && decreaseCooldown > 3.0f)
        {
            //   Debug.Log("Now hitting" + hits);
            totalFilmedTime -= 0.5f*Time.deltaTime;
            if (totalFilmedTime < 0) totalFilmedTime = 0;
        }

        if (totalFilmedTime > 0)
            GameObject.FindWithTag("GameController").GetComponent<GameController>().updateTotalFilmedTime(totalFilmedTime);
        
    //    prevHitting = nowHitting;
    }
}
