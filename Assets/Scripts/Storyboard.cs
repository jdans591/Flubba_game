using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Storyboard : MonoBehaviour {

	public Text text;
	public Text flubText;
	public Text evilText;
	private int count = -1;
	//public Text btnText;
	private int countIntro = -1;
	ButtonText contButton;
	Fader fader;

	// Use this for initialization
	void Start () {
		setText("\"Knife..\"");
		setFlubText("Flubba: Huh?");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("return")){
			countIntro++;
			count++;
			clickedIntro();
			clicked();
		}
	}

	public void setText(string msg){
		text.text = msg;
	}

	public void setFlubText(string msg){
		flubText.text = msg;
	}

	public void setEvilText(string msg){
		evilText.text = msg;
	}

	public void clicked(){
		if (count == 0) {
			setText ("\"Scalpel..\"");
			//count++;
		} else if (count == 1) {
			setText ("\"Sponge..\"");
			//count++;
		} else if (count == 2) {
			setText ("\"Wait! It's convulsing!\"");
			//count++;
		} else if (count == 3) {
			setText ("\"Grab the shotgun! Grab the shotgun!\"");
			//count++
		} else if (count == 4) {
			//Fader fader;
			//fader.EndScene();
			Application.LoadLevel (0);
		}

	}

	public void clickedIntro(){
		if (countIntro == 0) {
			setFlubText ("Flubba: Huh? Where am I?");
		} else if (countIntro == 1) {
			setFlubText ("");
			setEvilText ("Voice: Thank god! You made it!");
		} else if (countIntro == 2) {
			setEvilText ("Voice: Things were looking pretty hairy for a while back there.");
		} else if (countIntro == 3) {
			setEvilText ("");
			setFlubText ("Flubba: What? Who are you?");
		} else if (countIntro == 4) {
			setFlubText ("");
			setEvilText ("Voice: That doesn't matter right now.");
		} else if (countIntro == 5) {
			setEvilText ("Voice: Right now you just need to get out of here.");
		} else if (countIntro == 6) {
			setEvilText ("Voice: Don't worry, I'll help you.");
		}else if (countIntro == 7){
			Application.LoadLevel(3);
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
