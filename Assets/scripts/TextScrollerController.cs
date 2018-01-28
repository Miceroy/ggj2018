using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollerController : MonoBehaviour {
    public RectTransform obj;
    public Text t;
  //  bool running = false;
    List<string> strings = new List<string>();
    // Use this for initialization
    void Start () {
    }

  /*  public void setRunning(bool run)
    {
        running = run;
        if (!running)
        {
      //      obj.anchoredPosition = new Vector2(600, 0);
        }
        else
        {
        }
    }*/

    public void setActiveText(string tex)
    {
        if (t.text == "")
        {
            obj.anchoredPosition = new Vector2(600, 0);
            t.text = tex;
        }
        else
            strings.Add(tex);
    }

	// Update is called once per frame
	void Update () {
        if (t.text.Length > 0)
        {
            //Debug.Log("t.text.Length:" + 1000/t.text.Length);
            obj.anchoredPosition -= new Vector2(150 * Time.deltaTime, 0);
            if (obj.anchoredPosition.x < -(t.text.Length*15))
            {
                if (strings.Count > 0)
                {
                    t.text = strings[0];
                    strings.RemoveAt(0);
                }

                obj.anchoredPosition = new Vector2(t.text.Length * 15.0f / 2.0f, 0);
            }
        }
    }
}
