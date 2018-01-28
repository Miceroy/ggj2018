using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour {
    public CrosshairController crosshair;
    public Camera cam;
    float totalFilmedTime = 0;
    float decreaseCooldown;

    // Use this for initialization
    void Start () {
        decreaseCooldown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        TargetToFilm ttf=null;
        UnityEngine.Ray ray = cam.ScreenPointToRay(new Vector3(1280 / 2, 720 / 2, 0));
        UnityEngine.RaycastHit [] hits = Physics.RaycastAll(ray);
        bool nowHitting = false;
        for (int i=0; i< hits.Length; ++i)
        {
            ttf = hits[i].transform.gameObject.GetComponent<TargetToFilm>();
            if (ttf && ttf.targetActive)
            {
                nowHitting = true;
                totalFilmedTime += Time.deltaTime;
                GameObject.FindWithTag("GameController").GetComponent<GameController>().updateTotalFilmedTime(totalFilmedTime);

                if(crosshair.hasShot() == true)
                {
                    totalFilmedTime = 0;
                    GameObject.FindWithTag("GameController").GetComponent<GameController>().targetFilmingCompleted(ttf);
                    ttf.targetActive = false;
                }
                break;
            }
        }

        crosshair.setFocus(ttf, nowHitting);

        if(nowHitting)
            decreaseCooldown = 0;
        else
            decreaseCooldown += Time.deltaTime;

        if (nowHitting == false && decreaseCooldown > 3.0f)
        {
            totalFilmedTime -= 0.5f*Time.deltaTime;
            if (totalFilmedTime < 0) totalFilmedTime = 0;
        }
    }
}
