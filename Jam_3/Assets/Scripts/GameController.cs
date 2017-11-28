using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text weaponInput;
    public Text suspectInput;
    public string WinnerSuspect = "Ross";
    public string WinnerWeapon = "Tusk";

    private int level;


    // Use this for initialization
    void Start () {
        weaponInput.text = "";
        suspectInput.text = "";
        level = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
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
                level++;
                LoadNewScene(level);
            }
        }
    }

    void WinGame()
    {

    }

    public void LoadNewScene(int lvl)
    {
        //fade out the game and load a new level
        //float fadeTime = GameObject.Find("GameController").GetComponent<SceneFading>().BeginFade(1);
        //yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(lvl);
    }
}
