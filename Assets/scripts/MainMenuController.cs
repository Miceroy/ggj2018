using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public void quit()
    {
        Application.Quit();
    }

    public void start()
    {
        Application.LoadLevel("game_main");
    }
}
