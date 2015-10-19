using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public GameObject player;

    public GameObject SkinCanvas1;
    public GameObject SkinCanvas2;
    public GameObject SkinCanvas3;
    public GameObject SkinCanvas4;
    public GameObject SkinCanvas5;
    public GameObject SkinCanvas6;
    public GameObject RandomCanvas;

    public Text CoinCount1;
    public Text CoinCount2;
    public Text CoinCount3;
    public Text CoinCount4;
    public Text CoinCount5;
    public Text CoinCount6;
    public Text CoinCountRandom;

    public Sprite Skin1;
    public Sprite Skin2;
    public Sprite Skin3;
    public Sprite Skin4;
    public Sprite Skin5;
    public Sprite Skin6;

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button ButtonRandom;

    public Text buttonText1;
    public Text buttonText2;
    public Text buttonText3;
    public Text buttonText4;
    public Text buttonText5;
    public Text buttonText6;

    private Button[] buttons;
    private string[] keys;
    private Text[] texts;

    void Start()
    {
        //initialise the player pref int value to indicate green skin is owned by default
        PlayerPrefs.SetInt("Green Slime", 1);

        //put all Buttons, Texts and PlayerPref skin availability indicator into arrays
        buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, ButtonRandom };
        keys = new string[] { "Green Slime", "Blue Slime", "Light Blue Slime", "Orange Slime", "Purple Slime", "Red Slime", "Random Select" };
        texts = new Text[] { buttonText1, buttonText2, buttonText3, buttonText4, buttonText5, buttonText6 };

        //update the wallet coin count
        CoinCount1.text = PlayerPrefs.GetInt("coinCount").ToString();

        //refresh the button states
        conditionalOnAndOff();
    }

    public void ChangeSkinCanvas(int skinNum)
    {
        switch (skinNum)
        {
            //pressed back button from canvas 1
            case 1:
                SkinCanvas1.SetActive(false);
                RandomCanvas.SetActive(true);
                CoinCountRandom.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 1
            case 2:
                SkinCanvas1.SetActive(false);
                SkinCanvas2.SetActive(true);
                CoinCount2.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from canvas 2
            case 3:
                SkinCanvas2.SetActive(false);
                SkinCanvas1.SetActive(true);
                CoinCount1.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 2
            case 4:
                SkinCanvas2.SetActive(false);
                SkinCanvas3.SetActive(true);
                CoinCount3.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from canvas 3
            case 5:
                SkinCanvas3.SetActive(false);
                SkinCanvas2.SetActive(true);
                CoinCount2.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 3
            case 6:
                SkinCanvas3.SetActive(false);
                SkinCanvas4.SetActive(true);
                CoinCount4.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from canvas 4
            case 7:
                SkinCanvas4.SetActive(false);
                SkinCanvas3.SetActive(true);
                CoinCount3.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 4
            case 8:
                SkinCanvas4.SetActive(false);
                SkinCanvas5.SetActive(true);
                CoinCount5.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from canvas 5
            case 9:
                SkinCanvas5.SetActive(false);
                SkinCanvas4.SetActive(true);
                CoinCount4.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 5
            case 10:
                SkinCanvas5.SetActive(false);
                SkinCanvas6.SetActive(true);
                CoinCount6.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from canvas 6
            case 11:
                SkinCanvas6.SetActive(false);
                SkinCanvas5.SetActive(true);
                CoinCount5.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from canvas 6
            case 12:
                SkinCanvas6.SetActive(false);
                RandomCanvas.SetActive(true);
                CoinCountRandom.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed back button from RandomeCanvas
            case 13:
                RandomCanvas.SetActive(false);
                SkinCanvas6.SetActive(true);
                CoinCount6.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;

            //pressed next button from RandomeCanvas
            case 14:
                RandomCanvas.SetActive(false);
                SkinCanvas1.SetActive(true);
                CoinCount1.text = PlayerPrefs.GetInt("coinCount").ToString();
                conditionalOnAndOff();
                break;
        }
    }

    public void applySkin(int skinNum)
    {
        //Take corresponding actions when apply buttons are clicked
        //Set the Current Skin PlayerPrefs int value to the skin's corresponding number each time apply button is pressed
        //so that the skin of the flubba can be globally accessed
        switch (skinNum)
        {
            case 1:
                ButtonChange("Green Slime", Skin1, Button1, 100, CoinCount1, skinNum);
                PlayerPrefs.SetInt("Current Skin", 1);
                break;

            case 2:
                ButtonChange("Blue Slime", Skin2, Button2, 100, CoinCount2, skinNum);
                PlayerPrefs.SetInt("Current Skin", 2);
                break;

            case 3:
                ButtonChange("Light Blue Slime", Skin3, Button3, 100, CoinCount3, skinNum);
                PlayerPrefs.SetInt("Current Skin", 3);
                break;

            case 4:
                ButtonChange("Orange Slime", Skin4, Button4, 100, CoinCount4, skinNum);
                PlayerPrefs.SetInt("Current Skin", 4);
                break;

            case 5:
                ButtonChange("Purple Slime", Skin5, Button5, 100, CoinCount5, skinNum);
                PlayerPrefs.SetInt("Current Skin", 5);
                break;

            case 6:
                ButtonChange("Red Slime", Skin6, Button6, 100, CoinCount6, skinNum);
                PlayerPrefs.SetInt("Current Skin", 6);
                break;

            case 7:
                int num = Random.Range(1, 7);
                PlayerPrefs.SetInt("Random Select", 1);
                applySkin(num);
                CoinCountRandom.text = PlayerPrefs.GetInt("coinCount").ToString();
                break;
        }

        //refresh the buttons again to update the states
        conditionalOnAndOff();
    }

    void conditionalOnAndOff()
    {
        //if the total coin count is less than 50, disable all the apply buttons
        if (PlayerPrefs.GetInt("coinCount") < 50)
        {
            ButtonRandom.interactable = false;
            Button1.interactable = false;
            Button2.interactable = false;
            Button3.interactable = false;
            Button4.interactable = false;
            Button5.interactable = false;
            Button6.interactable = false;
        }
        //if the total coin count is greater than 50, enable the apply button for random skin
        else
        {
            ButtonRandom.interactable = true;

            //if the total coin count is less than 100, all buttons, other than the apply button in the random canvas, are disabled
            if (PlayerPrefs.GetInt("coinCount") < 100)
            {
                Button1.interactable = false;
                Button2.interactable = false;
                Button3.interactable = false;
                Button4.interactable = false;
                Button5.interactable = false;
                Button6.interactable = false;
            }
            //if count is greater than 100, enable all the buttons
            else
            {
                Button1.interactable = true;
                Button2.interactable = true;
                Button3.interactable = true;
                Button4.interactable = true;
                Button5.interactable = true;
                Button6.interactable = true;
            }
        }

        for (int i = 0; i < keys.Length - 1; i++)
        {
            //loop through the PlayerPrefs skin availability indicator to see which one is owned
            if (PlayerPrefs.GetInt(keys[i]) == 1)
            {
                //change the text of the button to select and enable it
                texts[i].text = "Select";
                buttons[i].interactable = true;
            }
            //if skin is not owned, the button should say "Apply"
            else
            {
                texts[i].text = "Apply";
            }
        }

        //at the end of the button checking process, make sure that currently used skin's text is changed and button is disabled
        int currentSkin = PlayerPrefs.GetInt("Current Skin");
        buttons[currentSkin - 1].interactable = false;
        texts[currentSkin - 1].text = "Equipped";
    }

    void ButtonChange(string intName, Sprite skin, Button button, int price, Text wallet, int skinNum)
    {
        //if the skin is already owned, just apply the skin
        if (PlayerPrefs.GetInt(intName) == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = skin;
        }
        //if the skin is not owned yet, change the skin, set the skin's availability indicator to true
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = skin;
            PlayerPrefs.SetInt(intName, 1);

            //deduct 50 coins if the skin is selected by random, otherwise deduct 100
            if (PlayerPrefs.GetInt("Random Select") == 0)
            {
                PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - price);
            }
            else
            {
                PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - price / 2);
                PlayerPrefs.SetInt("Random Select", 0);
            }
            
            //update the total coin count after the skin change
            wallet.text = PlayerPrefs.GetInt("coinCount").ToString();
        }
    }
}
