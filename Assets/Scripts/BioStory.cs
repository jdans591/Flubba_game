using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BioStory : MonoBehaviour {
	
	public Text evilText;
	public Text btnText;
	private int countIntro = 0;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return")){
			clickedIntro();
		}
	}
	
	public void setEvilText(string msg){
		evilText.text = msg;
	}
	
	public void clickedIntro(){
		if (countIntro == 0) {
			setEvilText ("Voice: Congratulations, you've escaped from Bohr's chemistry lab.");
			countIntro++;
		} else if (countIntro == 1) {
			setEvilText ("Voice: This is Bohr's biology lab where he spends most of his time. You should find him here.");
			countIntro++;
		} else if (countIntro == 2) {
			setEvilText ("Voice: You're going to have to kill him if you want any chance of escaping.");
			countIntro++;
		} else if (countIntro == 3) {
			Application.LoadLevel(1);
		}
	}
	
	IEnumerable changeScene(){
		float fadeTime = GameObject.Find("IntroCanvas").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(0.8f);
		Application.LoadLevel(3);
		yield break;
	}

	public void skipped(){
		Application.LoadLevel(3);
	}
}
