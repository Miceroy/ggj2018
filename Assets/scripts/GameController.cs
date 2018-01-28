using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float failedMissionPoints = 30;
    public RectTransform timerBar;
    public TextScrollerController textScrollerController;
    // missions
    public string[] infoTexts;
    public string[] missionDefaultObjecNames;
    public GameObject [] missionObjects;
    public float [] missionTimes;
    // other
    public GameObject[] missionEnabledObjects;
    public Text statusText;
    int curMission = 0;
    float totalScore = 0;
    float curTimeLeft = 0;
    bool hasMission = false;
	
	public GameObject SeagullPrefab;
	
    public void targetFilmingCompleted(TargetToFilm ttf)
    {
        totalScore += ttf.scoreValue;
        Debug.Log("targetFilmingCompleted! Got Score: "+ ttf.scoreValue + " Score:" + totalScore);
        textScrollerController.replaceLastText(infoTexts[curMission],ttf.tagName);
        endMission();
    }

    void startMission()
    {
        hasMission = true;
        curTimeLeft = 1.0f;
        //timerBar.sizeDelta = new Vector2(800, 5);
        foreach (GameObject obj in missionEnabledObjects)
        {
            obj.SetActive(true);
        }
        statusText.text = "Start mission";
        missionObjects[curMission].SetActive(true);
        textScrollerController.setActiveText(infoTexts[curMission], "[...]");
    }

    void quitGame()
    {
        statusText.text = "Quit!";
        Application.LoadLevel("main_menu");
    }

    void endMission()
    {
        hasMission = false;
        //   textScrollerController.setRunning(false);
        foreach (GameObject obj in missionEnabledObjects)
        {
            obj.SetActive(false);
        }
        missionObjects[curMission].SetActive(false);
        curMission++;
        textScrollerController.setActiveText("{0}", "");
        if (curMission >= missionObjects.Length)
        {
            statusText.text = "All missions done! Score:"+totalScore;
            Invoke("quitGame", 10);
        }
        else
        {
            statusText.text = "Waiting new mission. Score:" + totalScore;
            Invoke("startMission", 5);
        }
    }

    public void updateTotalFilmedTime(float totalFilmedTime)
    {
        statusText.text = "totalFilmedTime:" + totalFilmedTime;
    }

    // Use this for initialization
    void Start()
    {
		for (int i = 0; i <101;i++)
		{
            GameObject.Instantiate(SeagullPrefab);
		}
        foreach (GameObject obj in missionEnabledObjects)
        {
            obj.SetActive(false);
        }
        statusText.text = "Waiting new mission";
        Invoke("startMission", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasMission)
        {
            curTimeLeft -= Time.deltaTime / missionTimes[curMission];
            if (curTimeLeft < 0.0f)
            {
                textScrollerController.replaceLastText(infoTexts[curMission], missionDefaultObjecNames[curMission]);
                totalScore -= failedMissionPoints;
                endMission();
            }
            timerBar.sizeDelta = new Vector2(curTimeLeft * 800, 5);
        }
    }
}
