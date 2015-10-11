using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls visibility of leaderboard screens for different levels
public class LeaderboardManager : MonoBehaviour {

    //public GameObject CanvasLevel1 = GameObject.Find("CanvasLevel1");
    public GameObject CanvasLevel1;
    //public GameObject CanvasLevel2 = GameObject.Find("CanvasLevel2");
    public GameObject CanvasLevel2;
    public GameObject CanvasLevel3;
    public GameObject CanvasLevel4;

    // Hides the current leaderboard and shows the next (if forward button pressed) or previous (if back button pressed) leaderboard
    public void ChangeLeaderboard (int lvl) {

        //CanvasLevel1 = GameObject.Find("CanvasLevel1");
        //CanvasLevel2 = GameObject.Find("CanvasLevel2");
        //CanvasLevel3 = GameObject.Find("CanvasLevel3");
        //CanvasLevel4 = GameObject.Find("CanvasLevel4");

        switch (lvl) {
            // Level 1 next
            case 1:
                CanvasLevel1.SetActive(false);
                CanvasLevel2.SetActive(true);
                break;
            // Level 2 back
            case 2:
                CanvasLevel2.SetActive(false);
                CanvasLevel1.SetActive(true);
                break;
            // Level 2 next
            case 3:
                CanvasLevel2.SetActive(false);
                CanvasLevel3.SetActive(true);
                break;
            // Level 3 back
            case 4:
                CanvasLevel3.SetActive(false);
                CanvasLevel2.SetActive(true);
                break;
            // Level 3 next
            case 5:
                CanvasLevel3.SetActive(false);
                CanvasLevel4.SetActive(true);
                break;
            // Level 4 back
            case 6:
                CanvasLevel4.SetActive(false);
                CanvasLevel3.SetActive(true);
                break;
        }

    }
	
}
