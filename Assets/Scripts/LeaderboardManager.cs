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

        CanvasLevel1 = GameObject.Find("CanvasLevel1");
        CanvasLevel2 = GameObject.Find("CanvasLevel2");

        switch (lvl) {
            // Level 1 next
            case 1:
                CanvasLevel1.SetActive(false);
                CanvasLevel2.SetActive(true);
                break;
            // Level 2 back
            case 2:
                //asdf
                break;
            // Level 2 next
            case 3:
                //asdf
                break;
            // Level 3 back
            case 4:
                //sadf
                break;
            // Level 3 next
            case 5:
                //asdf
                break;
            // Level 4 back
            case 6:
                //asdf
                break;
        }

    }
	
}
