using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public string WinnerSuspect = "Never";
    public string WinnerWeapon = "Win";

    private int currentLevel;

    private Text weaponInput;
    private Text suspectInput;

    // Use this for initialization
    void Awake () {

        DontDestroyOnLoad(transform.gameObject);

        currentLevel = 0;
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level > 0)
        {
            //Find weapon and suspect input
            weaponInput = GameObject.Find("Weapon_input").transform.gameObject.GetComponent<Text>();
            suspectInput = GameObject.Find("Suspect_input").transform.gameObject.GetComponent<Text>();

            if ((weaponInput != null) && (suspectInput != null))
            {
                weaponInput.text = "";
                suspectInput.text = "";
                currentLevel = 1;
            }
        }
    }

    public void ChangeHunchValue(string objectName, string objectTag)
    {
        if(objectTag == "Suspect")
        {
            suspectInput.text = objectName;
        }
        else if(objectTag == "Weapon")
        {
            weaponInput.text = objectName;
        }
    }

    public void MakeHunch()
    {
        if ((weaponInput.text != "") && (suspectInput.text != ""))
        {
            //Comprobar si la sospecha es correcta
            if((weaponInput.text == WinnerWeapon) && (suspectInput.text == WinnerSuspect))
            {
                WinGame();
            }
            //Si no, cargar siguiente nivel
            else
            {
                Debug.Log("Passed!!");
                StartCoroutine(LoadNewScene(currentLevel));
            }
        }
    }

    void WinGame()
    {

    }

    IEnumerator LoadNewScene(int currentLvl)
    {
        //fade out the game and load a new level
        float fadeTime = GameObject.Find("GameController").GetComponent<SceneFading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(currentLevel + 1);
    }

    //Function for menu play button
    public void Wrapper(int targetLevel)
    {
        StartCoroutine(LoadNewScene(targetLevel));
    }

    public int GetLevel()
    {
        return currentLevel;
    }
}
