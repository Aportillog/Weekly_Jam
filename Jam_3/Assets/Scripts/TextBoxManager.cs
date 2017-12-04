using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextBoxManager : MonoBehaviour {

    public TextAsset textFile;
    public string levelText;
    public string[] textLines;

    public bool dlgBoxActive;

    private int currentLine = 0;
    private int endAtLine = 0;

    private GameObject dialogBox;       //Dialog box for holding text
    private Text dialogBoxText;         //Text of the dialog box

    private bool isTyping = false;
    private bool cancelTyping = false;
    private float typeSpeed = 0.06f;

    //private GameController m_scriptGameController;
    private AudioSource source;


    void Start () {

        //m_scriptGameController = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
        //Get audio source 
        source = GetComponent<AudioSource>();
        //Get current level
        //currentLevel = m_scriptGameController.GetLevel();

    }

    private void OnLevelWasLoaded(int level)
    {
        if(level > 0)
        {
            Debug.Log(level);
            //Find Dialog box and Text box for the speech
            dialogBox = GameObject.Find("Dialog_box");
            dialogBoxText = GameObject.Find("Dialog_text").GetComponent<Text>();

            if (textFile != null)
            {
                levelText = (textFile.text.Split(new string[] { "[End Level]" }, StringSplitOptions.RemoveEmptyEntries)[level]);          //Get the text for the current level from the text file
                textLines = (levelText.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries));                                //Split that text by "\n"
            }

            if (endAtLine == 0)
            {
                endAtLine = textLines.Length - 1;
            }

            if (dlgBoxActive)
            {
                StartCoroutine(EnableDialogBox(7f));
            }
            else
            {
                DisableDialogBox();
            }
            
        }
    }


    void Update () {

        if (dlgBoxActive)
        {

            if (Input.GetMouseButtonDown(1))
            {
                if (!isTyping)
                {
                    currentLine++;

                    if (currentLine > endAtLine)
                    {
                        DisableDialogBox();
                    }
                    else
                    {
                        StartCoroutine(TextScroll(textLines[currentLine]));
                    }
                }
                else if (isTyping && !cancelTyping)
                {
                    cancelTyping = true;
                }
            }

        }

	}


    IEnumerator EnableDialogBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        dialogBox.SetActive(true);
        dlgBoxActive = true;
    }

    public void DisableDialogBox()
    {
        dialogBox.SetActive(false);
        dlgBoxActive = false;
    }


    private IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        dialogBoxText.text = "";
        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            dialogBoxText.text += lineOfText[letter];
            source.Play();
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialogBoxText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }
}
