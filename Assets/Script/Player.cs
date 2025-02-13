using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public enum PlayerLocation
{
    NormalHouse,
    DollHouse
}
public class Player : Characters
{
    [SerializeField] private bool micro;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public bool canOut = false;
    [SerializeField] public bool checkDead = false;
    [SerializeField] public PlayerLocation playerLocation;
    
    private GameObject ladder;
    [Header("Movement")]
    [SerializeField] int movementSpeed = 5;
    [SerializeField] float xInput;
    [SerializeField] float zInput;

    [Header("ObtainedKeys")] 
    public List<KeyFor> keys = new List<KeyFor>();

    private void Awake()
    {
       ladder = GetComponent<GameObject>();
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
        }
        else if (xInput == 0 && zInput == 0 && checkDead == false)
        {
            SetState(CharState.Idle);
        }
        else 
        {
             SetState(CharState.Walk);  
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


