using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    private GameController m_scriptGameController;
    private GameObject spriteNorm;                   //Normal sprite
    private GameObject spriteHL;                     //Hightlighted sprite

    void Start()
    {
        m_scriptGameController = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
        spriteNorm = this.gameObject.transform.GetChild(0).gameObject;
        spriteHL = this.gameObject.transform.GetChild(1).gameObject;

        //Activar sprite normal y desactivar HL
        spriteNorm.SetActive(true);
        spriteHL.SetActive(false);
    }
	void OnMouseDown()
    {
        m_scriptGameController.ChangeHunchValue(this.gameObject.name, this.gameObject.tag);
    }

    private void OnMouseEnter()
    {
        SetSpriteActive();
    }

    private void OnMouseExit()
    {
        SetSpriteActive();
    }

    private void SetSpriteActive()
    {
        //Si el sprite normal está activado (activeSelf == true), desactivar normal y activar HL
        bool sNActive = spriteNorm.activeSelf;
        spriteNorm.SetActive(!sNActive);
        spriteHL.SetActive(sNActive);
    }
}
