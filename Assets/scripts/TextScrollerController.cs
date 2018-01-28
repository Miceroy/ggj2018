using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScrollerController : MonoBehaviour {
    public RectTransform obj;
    public Text t;
    List<string> strings = new List<string>();

    public void replaceLastText(string tex, string objName)
    {
        string s = string.Format(tex, objName);
        if (strings.Count > 0)
        {
            strings[strings.Count - 1] = s;
        }
        else
        {            
            t.text = s;
        }
    }

    public void setActiveText(string tex, string objName)
    {
        string s = string.Format(tex, objName);
        if (t.text == "")
        {
            obj.anchoredPosition = new Vector2(600, 0);
            t.text = s;
        }
        else
            strings.Add(s);
    }

	// Update is called once per frame
	void Update () {
        if (t.text.Length > 0)
        {
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
