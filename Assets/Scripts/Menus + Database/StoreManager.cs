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

    private Button[] buttons;
    private string[] owned;

    void Start()
    {
        PlayerPrefs.SetInt("Green Slime", 1);
        PlayerPrefs.SetInt("Current Skin", 0);
        PlayerPrefs.SetInt("Random Select", 0);
        buttons = new Button[] { Button1, Button2, Button3, Button4, Button5, Button6, ButtonRandom };
        owned = new string[] { "Green Slime", "Blue Slime", "Light Blue Slime", "Orange Slime", "Purple Slime", "Red Slime", "Random Select" };
        CoinCount1.text = PlayerPrefs.GetInt("coinCount").ToString();
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
    }

    void conditionalOnAndOff()
    {

        foreach (Button button in buttons)
        {

        }

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
        else
        {
            ButtonRandom.interactable = true;
            if (PlayerPrefs.GetInt("coinCount") < 100)
            {
                Button1.interactable = false;
                Button2.interactable = false;
                Button3.interactable = false;
                Button4.interactable = false;
                Button5.interactable = false;
                Button6.interactable = false;
            }
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
    }

    void ButtonChange(string intName, Sprite skin, Button button, int price, Text wallet, int skinNum)
    {
        if (PlayerPrefs.GetInt(intName) == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = skin;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = skin;
            PlayerPrefs.SetInt(intName, 1);
            if (PlayerPrefs.GetInt("Random Select") == 0)
            {
                PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - price);
            }
            else
            {
                PlayerPrefs.SetInt("coinCount", PlayerPrefs.GetInt("coinCount") - price / 2);
                PlayerPrefs.SetInt("Random Select", 0);
            }
            
            wallet.text = PlayerPrefs.GetInt("coinCount").ToString();
        }
    }
}
