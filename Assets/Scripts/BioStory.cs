using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BioStory : MonoBehaviour {
	
	public Text evilText;
	public Text btnText;
	private int countIntro = 0;

	// Use this for initialization
	void Start () {
		//setFlubText("Flubba: Huh?");
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	public void setEvilText(string msg){
		evilText.text = msg;
	}
	
	public void clickedIntro(){
		if (countIntro == 0) {
			StartCoroutine ("multipleTexts1");
			countIntro++;
		} else if (countIntro == 1) {
			Application.LoadLevel(3);
		}
	}
	
	IEnumerator multipleTexts1(){
		btnText.text = "";
		setEvilText ("Voice: Congratulations, you've escaped from Bohr's chemistry lab.");
		//System.Threading.Thread.Sleep (1000);
		yield return new WaitForSeconds(2);
		setEvilText ("Voice: This is Bohr's biology lab where he spends most of his time. You should find him here.");
		//System.Threading.Thread.Sleep (1000);
		yield return new WaitForSeconds(2);

		setEvilText ("Voice: You're going to have to kill him if you want any chance of escaping.");

		btnText.text = "Continue";
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
