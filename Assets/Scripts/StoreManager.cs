using UnityEngine;
using System.Collections;

public class StoreManager : MonoBehaviour
{

    public GameObject player;
    public GameObject SkinCanvas1;
    public GameObject SkinCanvas2;
    public GameObject SkinCanvas3;
    public GameObject SkinCanvas4;
    public GameObject RandomeCanvas;

    public void ChangeSkinCanvas(int skinNum)
    {
        switch (skinNum)
        {
            //pressed back button from canvas 1
            case 1:
                SkinCanvas1.SetActive(false);
                RandomeCanvas.SetActive(true);
                break;

            //pressed next button from canvas 1
            case 2:
                SkinCanvas1.SetActive(false);
                SkinCanvas2.SetActive(true);
                break;

            //pressed back button from canvas 2
            case 3:
                SkinCanvas2.SetActive(false);
                SkinCanvas1.SetActive(true);
                break;

            //pressed next button from canvas 2
            case 4:
                SkinCanvas2.SetActive(false);
                SkinCanvas3.SetActive(true);
                break;

            //pressed back button from canvas 3
            case 5:
                SkinCanvas3.SetActive(false);
                SkinCanvas2.SetActive(true);
                break;

            //pressed next button from canvas 3
            case 6:
                SkinCanvas3.SetActive(false);
                SkinCanvas4.SetActive(true);
                break;

            //pressed back button from canvas 4
            case 7:
                SkinCanvas4.SetActive(false);
                SkinCanvas3.SetActive(true);
                break;

            //pressed next button from canvas 4
            case 8:
                SkinCanvas4.SetActive(false);
                RandomeCanvas.SetActive(true);
                break;

            //pressed back button from RandomeCanvas
            case 9:
                RandomeCanvas.SetActive(false);
                SkinCanvas4.SetActive(true);
                break;

            //pressed next button from RandomeCanvas
            case 10:
                RandomeCanvas.SetActive(false);
                SkinCanvas1.SetActive(true);
                break;
        }
    }

    public void applySkin(int skinNum)
    {
        switch (skinNum)
        {
            case 1:
                player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                break;

            case 2:
                player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                break;

            case 3:
                player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                break;

            case 4:
                player.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("");
                break;

            case 5:
                int num = Random.Range(1, 4);
                applySkin(num);
                break;
        }
    }
}
