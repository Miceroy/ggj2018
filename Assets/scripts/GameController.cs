using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO:
// - MissionObject
//   - Triggeri maalialueella.
//   - 


/*

Mission 1:
1. There is something going on at the side of the city.  We are waiting for footage from our video crew. More updates to follow...
Kun saavut objective alueelle:


Objective 1:
2. A fire has broken out! [Tag] is burning! More updates to follow...
Kun saat tagin lukittua, lue teksti kerran läpi ja sen jälkeen aktivoi seuraava.
Jos aika loppuu kesken, toista teksti default tekstin kanssa ("Tumpelot toimittajat eivät tiedä!"
Default Tekstin lukemisen jälkeen, siirry seuraavaan uutiseen.



Objective2:
3. [Tag] are running around the scene. More updates to follow...


Objective 3:
4. Luckily [Tag] calmed the situation down. Recap of the situation in our late news broadcast

*/


public class GameController : MonoBehaviour
{
    public GameObject goToActivate;

    public void targetFilmingCompleted(TargetToFilm ttf)
    {
        Debug.Log("targetFilmingCompleted! Got Score: "+ ttf.scoreValue);
        endMission();
        Invoke("startMission", 5);
    }

    void startMission()
    {
        goToActivate.SetActive(true);
    }

    void endMission()
    {
        goToActivate.SetActive(false);
    }

    public void updateTotalFilmedTime(float totalFilmedTime)
    {
      //  Debug.Log("totalFilmedTime=" + totalFilmedTime);
    }

    // Use this for initialization
    void Start()
    {
        Invoke("startMission", 5);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
