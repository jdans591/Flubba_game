using UnityEngine;

public class AchievementManager : MonoBehaviour {

	// Green complete ticks for achievements 1-4
	public GameObject Complete1;
	public GameObject Complete2;
	public GameObject Complete3;
	public GameObject Complete4;

	// Padlock for achievements 1-4
	public GameObject Lock1;
	public GameObject Lock2;
	public GameObject Lock3;
	public GameObject Lock4;

	public LevelSelectManager levelSelectManager;
	
	// Total number of coins the player has collected
	int coinCount;

	// Best time taken for each level by player
	float level1Best;
	float level2Best;
	float level3Best;
	float level4Best;

	// Represents whether a level is locked or not ("true" or "false") - stored in local storage
	string level2Locked;
	string level3Locked;
	string level4Locked;

	// Add ticks to achievements which have been completed
	void Start() {
		UpdateAchievements();
	}

	// Checks which achievements are complete
	void UpdateAchievements() {
		UpdateAchievement1();
		UpdateAchievement2();
		UpdateAchievement3();
		UpdateAchievement4();
	}

	void UpdateAchievement1() {
		// Get level locked status from local storage
		level2Locked = PlayerPrefs.GetString("level2Locked");
		level3Locked = PlayerPrefs.GetString("level3Locked");
		level4Locked = PlayerPrefs.GetString("level4Locked");

		// Check if that all levels are unlocked
		if ((level2Locked.Equals("false")) && (level3Locked.Equals("false")) && (level4Locked.Equals("false"))) {
			// Hide lock
			Lock1.SetActive(false);
			// Display completion tick
			Complete1.SetActive(true);
		}
	}

	void UpdateAchievement2() {
		// Get total number of coins collected by player
		coinCount = PlayerPrefs.GetInt("coinCount");

		// Check if player has collected atleast 1,000 coins
		if (coinCount >= 1000) {
			// Hide lock
			Lock2.SetActive(false);
			// Display completion tick
			Complete2.SetActive(true);
		}
	}

	void UpdateAchievement3() {
		float[,] benchmark = levelSelectManager.benchmark;
		// Get player's best times for each level
		level1Best = PlayerPrefs.GetFloat("level1Best");
		level2Best = PlayerPrefs.GetFloat("level2Best");
		level3Best = PlayerPrefs.GetFloat("level3Best");
		level4Best = PlayerPrefs.GetFloat("level4Best");
		bool gold = false;

		// Check if player has earned a 3-star rating for any level
		if ((level1Best <= benchmark[2, 0]) && (level1Best != 0)) {
			gold = true;
		} else if ((level2Best <= benchmark[2, 1]) && (level2Best != 0)) {
			gold = true;
		} else if ((level3Best <= benchmark[2, 2]) && (level3Best != 0)) {
			gold = true;
		} else if ((level4Best <= benchmark[2, 3]) && (level4Best != 0)) {
			gold = true;
		}

		// If 3-star has been achieved
		if (gold) {
			// Hide lock
			Lock3.SetActive(false);
			// Display completion tick
			Complete3.SetActive(true);
		}
	}

	void UpdateAchievement4() {
		float[,] benchmark = levelSelectManager.benchmark;
		// Get player's best times for each level
		level1Best = PlayerPrefs.GetFloat("level1Best");
		level2Best = PlayerPrefs.GetFloat("level2Best");
		level3Best = PlayerPrefs.GetFloat("level3Best");
		level4Best = PlayerPrefs.GetFloat("level4Best");

		// Check if player has earned a 3-star rating for all levels
		if ((level1Best <= benchmark[2, 0]) && (level1Best != 0)) {
			if ((level2Best <= benchmark[2, 1]) && (level2Best != 0)) {
				if ((level3Best <= benchmark[2, 2]) && (level3Best != 0)) {
					if ((level4Best <= benchmark[2, 3]) && (level4Best != 0)) {
						// Hide lock
						Lock4.SetActive(false);
						// Display completion tick
						Complete4.SetActive(true);
					}
				}
			}
		}
	}
}
