using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    int numChoices;
    void Start()
    {
        numChoices = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MyButtonClick(int value)
    {
        if(numChoices == 0)// first button click 
        {
            numChoices = value;
        }
        else // Pressing any button a second time
        {
            if(numChoices == value)
            {
                Debug.Log("Eslesti");
                numChoices = 0;
            }
            else
            {
                Debug.Log("Eslesmedi");
                numChoices = 0;
            }
        }
    }
}
