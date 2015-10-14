using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RevealStory : MonoBehaviour {


	public Text elonText;
	public Text flbText;
	//public Text btnText;
	private int countIntro = -1;
	public Image myImage;
	
	public void Update(){
		if (Input.GetKeyDown("return")){
			countIntro++;
			clicked();
		}
	}
	
	void setElonText(string msg){
		elonText.text = msg;
	}
	
	void setFlubText(string msg){
		flbText.text = msg;
	}
	
	public void clicked(){
		if (countIntro == 0) {
			setFlubText ("Flubba: Did I... Did I kill all these people?");
			//countIntro++;
		} else if (countIntro == 1) {
			setFlubText ("");
			setElonText ("Elon: Yes Flubba, your creator wiped your memory after each one.");
			//countIntro++;
		} else if (countIntro == 2) {
			setFlubText ("");
			setElonText ("Elon: You can't help these ones, but you can still stop your creator.");
		} else if (countIntro == 3) {
			setElonText("");
			setFlubText ("Flubba: Where can I find him?");
		} else if (countIntro == 4) {
			setFlubText ("");
			setElonText ("Elon: He's in the physics lab, but be careful!");
			//countIntro++;
		} else if (countIntro == 5) {
			setFlubText ("");
			setElonText("Elon: If he wipes your memory again then all hope will be lost.");
			//countIntro++;
		} else if (countIntro == 6) {
			setFlubText ("");
			setElonText ("Elon: This is our last chance Flubba, good luck.");
		} else if (countIntro == 7) {
			Application.LoadLevel(3);
		}
	}
	
	public void skipped(){
		Application.LoadLevel(3);
	}
}
