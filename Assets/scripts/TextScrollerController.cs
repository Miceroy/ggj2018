using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollerController : MonoBehaviour {
    public RectTransform obj;

	// Use this for initialization
	void Start () {
        obj.anchoredPosition = new Vector2(600, 0);
    }
	
	// Update is called once per frame
	void Update () {
        obj.anchoredPosition -= new Vector2(100 * Time.deltaTime,0);
        if (obj.anchoredPosition.x < -1000)
        {
            obj.anchoredPosition = new Vector2(600, 0);
        }
    }
}
