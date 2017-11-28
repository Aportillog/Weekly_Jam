using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {

    private GameController m_scriptGameController;
    void Start()
    {
        m_scriptGameController = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
    }
	void OnMouseDown()
    {
        m_scriptGameController.ChangeHunchValue(this.gameObject.name, this.gameObject.tag);
    }
}
