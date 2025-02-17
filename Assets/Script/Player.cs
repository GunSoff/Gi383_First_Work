using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerLocation
{
    NormalHouse,
    DollHouse
}
public class Player : Characters
{   
    [Header("Player Status")]
    [SerializeField] private bool micro;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public bool canOut = false;
    [SerializeField] public bool checkDead = false;
    [SerializeField] public bool stealth = false;
    [SerializeField] public PlayerLocation playerLocation;
    
    [Header("Win Lose Condition")]
    [SerializeField] public GameObject LosePanel;
    [SerializeField] public GameObject WinImage;
    [SerializeField] private float timeToEnd;
    [SerializeField] public bool win;
    
    [Header("Movement")]
    [SerializeField] int movementSpeed = 5;
    [SerializeField] float xInput;
    [SerializeField] float zInput;

    [Header("ObtainedKeys")] 
    public List<KeyFor> keys = new List<KeyFor>();

    private void Awake()
    {
        timeToEnd = 10f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            micro = !micro;
        }
        MoveBYKB();
        MicroMacro();
        if (Input.GetKeyDown(KeyCode.Y))
        {
            checkDead = !checkDead;
        }
        
        if(checkDead)
        {
            SetState(CharState.Die);
            LosePanel.SetActive(true);
            timeToEnd -= Time.deltaTime;
            if (timeToEnd <= 0)
            {
                Application.Quit();
            }
        }
        else if (xInput == 0 && zInput == 0 && checkDead == false)
        {
            SetState(CharState.Idle);
        }
        else 
        {
             SetState(CharState.Walk);  
        }

        if (win)
        {
            WinImage.SetActive(true);
            timeToEnd -= Time.deltaTime;
            if (timeToEnd <= 0)
            {
                Application.Quit();
            }
        }
    }

    void MoveBYKB()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        
        Vector3 dir = (transform.forward * zInput) + (transform.right * xInput);
        transform.position += dir * movementSpeed * Time.deltaTime;
        if (xInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (xInput > 0)
        {
            spriteRenderer.flipX = false;   
        }
    }

    void MicroMacro()
    {
        if (micro)
        {
            playerTransform.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        }
        else
        {
            playerTransform.transform.localScale = new Vector3(0.3f,0.3f,0.3f);
        }
    }
}


