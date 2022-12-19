using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    int numChoices;

    GameObject chooseButton;
    GameObject itselfBTN;

    public Sprite defaultSprite;
    void Start()
    {
        numChoices = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetObjects(GameObject obj)
    {
        itselfBTN=obj;
        itselfBTN.GetComponent<Image>().sprite = itselfBTN.GetComponentInChildren<SpriteRenderer>().sprite;
    }
    public void MyButtonClick(int value)
    {
        Control(value,itselfBTN);
    }

    void Control(int getValue ,GameObject getObje)
    {
        if (numChoices == 0)// first button click 
        {
            numChoices = getValue;
            chooseButton= getObje;
        }
        else // Pressing any button a second time
        {
            if (numChoices == getValue)
            {
                //Debug.Log("Matched");
                Destroy(chooseButton.gameObject);
                Destroy(getObje.gameObject);

                numChoices = 0;
                chooseButton = null;

            }
            else
            {
                // Debug.Log("did not Matched");
                chooseButton.GetComponent<Image>().sprite = defaultSprite;
                getObje.GetComponent<Image>().sprite = defaultSprite;
              
                numChoices = 0;
                chooseButton = null;
            }
        }
    }
}
