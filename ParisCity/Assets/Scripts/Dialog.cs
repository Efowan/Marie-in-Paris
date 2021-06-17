using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI continueE;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    bool triggering;

    private void Start()
    {
        StartCoroutine(Type());
        continueE.text = " ";
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E) && triggering)
        {
            NextSentence();
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text =  "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit2D);
        if (other.gameObject.tag == "Marie")
        {
            triggering = true;
            continueE.gameObject.SetActive(true);
            continueE.text = "Press E to continue...";
            textDisplay.gameObject.SetActive(true);
            Debug.Log("Meow");
        }
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if (other.gameObject.tag == "Marie")
        {
            triggering = false;
            continueE.text = " ";
            continueE.gameObject.SetActive(false);
            textDisplay.gameObject.SetActive(false);
        }
    }

    

}
