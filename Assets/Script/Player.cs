using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool micro;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite idleSprite;
    private GameObject ladder;
    [Header("Movement")]
    [SerializeField] int movementSpeed = 5;
    [SerializeField] float xInput;
    [SerializeField] float zInput;

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

        if (xInput == 0 && zInput == 0)
        {
            spriteRenderer.sprite = idleSprite;
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


