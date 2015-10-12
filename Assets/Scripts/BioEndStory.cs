using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BioEndStory : MonoBehaviour {
	
	public Text elonText;
	public Text flbText;
	//public Text btnText;
	public Text evilText;
	private int countIntro = -1;

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
			setFlubText ("Flubba: It's over Elon. I'm getting out of this place.");
			//countIntro++;
		} else if (countIntro == 1) {
			setFlubText ("");
			setElonText ("Elon: I knew this day would come, ever since your creator went into hiding!");
			//countIntro++;
		} else if (countIntro == 2) {
			setElonText ("");
			setFlubText ("Flubba: Don't try and fool me.");
		} else if (countIntro == 3) {
			setFlubText ("Flubba: I know it was YOU who created me!");
		} else if (countIntro == 4) {
			setFlubText ("");
			setElonText ("Elon: How do you know that? Did the voice inside your head tell you that?!");
			//countIntro++;
		} else if (countIntro == 5) {
			setElonText ("");
			setFlubText ("");
			evilText.text = "Voice: Don't listen to him, you need to kill him before he calls for help!";
			//countIntro++;
		} else if (countIntro == 6) {
			setFlubText ("");
			evilText.text = "";
			setElonText ("Elon: No, I am not your creator.");
		} else if (countIntro == 7) {
			setElonText ("Elon: Your sole purpose is to cripple those who would dare stand up to your creator.");
		}else if (countIntro == 8){
			setElonText ("Elon: You will not kill again!");
		}else if (countIntro == 9){
			//StartCoroutine("ChangeScene");
			Application.LoadLevel(3);
		}
	}

	public void skipped(){
		Application.LoadLevel(3);
	}
}
