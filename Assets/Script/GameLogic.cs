﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    // Game Objects
    public GameObject card;
    public SpriteRenderer CardSpriteRenderer;
    public ResourceManager resourceManager;
    public CardLogic cl;
    SpriteRenderer sr;

    // Card Movement
    public float fMovingSpeed = 3f;
    public float fsidemargin;
    public float fsidetrigger;

    // UI
    public TMP_Text display;
    public TMP_Text charName;
    public TMP_Text dialogue;

    // Card Variables
    private string leftdialogue;
    private string rightdialogue;
    public Card currentCard;
    public Card testCard;

    void Start()
    {
        sr = card.GetComponent<SpriteRenderer>();
        LoadCard(testCard);

    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        if(Input.GetMouseButton(0) && cl.isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.y = 0f;
            card.transform.position = pos;
        }
        else
        {
            card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        

        //Check Side
        if(card.transform.position.x > fsidemargin)    //Kanan
        {
            dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
        }
        else if(card.transform.position.x < -fsidemargin)   //Kiri
        {
            dialogue.alpha = Mathf.Min(-card.transform.position.x, 1);
        }
        else
        {
            dialogue.alpha = Mathf.Min(card.transform.position.x, 1);
        }
    }

    public void LoadCard(Card card)
    {
        CardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftdialogue = card.leftDialogue;
        rightdialogue = card.RightDialogue;
        currentCard = card;
    }
}
