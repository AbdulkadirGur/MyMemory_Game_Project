using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class GameControl : MonoBehaviour
{
    int numChoices;

    GameObject chooseButton;
    GameObject itselfBTN;
    public AudioSource [] voices;
    public GameObject[] buttons; 

    public Sprite defaultSprite;
    void Start()
    {
        numChoices = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonsState(bool state)  // coklu tiklamaya izin vermiyor tum butonlari kapatiyor
    {
        foreach (var item in buttons)
        {
            if (item !=null)    // dizide silinen objeleri dikkate almiyor
            {
                item.GetComponent<UnityEngine.UI.Image>().raycastTarget = state;
            }
           
        }
    }
    public void GetObjects(GameObject obj) // tiklandiginda objeyi esitliyor ve childin imageni atiyor
    {
        itselfBTN=obj;
        itselfBTN.GetComponent<UnityEngine.UI.Image>().sprite = itselfBTN.GetComponentInChildren<SpriteRenderer>().sprite;
        itselfBTN.GetComponent<UnityEngine.UI.Image>().raycastTarget = false;
    }
    public void MyButtonClick(int value)
    {
        Control(value);
    }

    void Control(int getValue )
    {
        if (numChoices == 0)// first button click 
        {
            numChoices = getValue;
            chooseButton= itselfBTN;
            voices[1].Play();
        }
        else // Pressing any button a second time
        {
           StartCoroutine(checkIT(getValue));
        }
    }

    IEnumerator checkIT(int getValue) // butonlara tiklandiginda 1 saniye gec calistiryor 
    {
        buttonsState(false);
        yield return new WaitForSeconds(1);
        if (numChoices == getValue)
        {
            //Debug.Log("Matched");
            chooseButton.GetComponent<UnityEngine.UI.Image>().enabled = false;
            itselfBTN.GetComponent<UnityEngine.UI.Image>().enabled = false;

            //itselfBTN.GetComponent<UnityEngine.UI.Image>().enabled = false;
           // itselfBTN.GetComponent<UnityEngine.UI.Button>().enabled = false;
            /*
            Destroy(chooseButton.gameObject);
            Destroy(itselfBTN.gameObject);*/

            numChoices = 0;
            chooseButton = null;
            buttonsState(true);

        }
        else
        {
            // Debug.Log("did not Matched");
            voices[2].Play();
            itselfBTN.GetComponent<UnityEngine.UI.Image>().sprite = defaultSprite;
            chooseButton.GetComponent<UnityEngine.UI.Image>().sprite = defaultSprite;
           
            buttonsState(true);
            numChoices = 0;
            chooseButton = null;
        }
    }
}
