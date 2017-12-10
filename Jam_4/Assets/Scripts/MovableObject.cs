using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour {

    private SpriteRenderer m_SpriteRenderer;
    public Color m_previousColor;
    public Color m_CantPlaceColor;              //Select color in unity, remember to set alpha to 255
    public Color m_NormalColor;
    public Color m_HighlightedColor;

    public bool canMove;
    public float moveSpeed = 1.5f;

    private bool canPlace;

	// Use this for initialization
	void Start () {

        //Fecth SpriteRenderer from the go
        m_SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        m_previousColor = m_NormalColor;
        //Let objects to be placed at the start
        canPlace = true;
	}
	

	void Update () {
        //Move object with mouse if can move
        if (canMove)
        {
            MoveWithMouse();
            if (Input.GetButtonDown("Fire2") && canPlace)
            {
                SetCanMove(false);
            }
        }
	}


    private void MoveWithMouse()
    {
        this.transform.position = Vector2.Lerp(transform.position, GetMousePosition(), moveSpeed);
    }

    private Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        //Change object position once placed
        if (!canMove)
        {
            SetCanMove(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canMove)
        {
            if (m_SpriteRenderer.color != m_CantPlaceColor)
                m_previousColor = m_SpriteRenderer.color;
            m_SpriteRenderer.color = m_CantPlaceColor;
            canPlace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canMove)
        {
            m_SpriteRenderer.color = m_previousColor;
            canPlace = true;
        }
        
    }

    private void OnMouseEnter()
    {
        if (!canMove)
        {
            m_previousColor = m_SpriteRenderer.color;
            m_SpriteRenderer.color = m_HighlightedColor;
        }
    }
    private void OnMouseExit()
    {
        if (!canMove)
        {
            m_SpriteRenderer.color = m_NormalColor;
        }
    }

    public void SetCanMove(bool target)
    {
        canMove = target;
    }
}
