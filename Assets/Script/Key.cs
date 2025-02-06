using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class Key : MonoBehaviour
{
    [SerializeField] private bool TestL;
    [SerializeField] private GameObject keyText;
    [SerializeField] private int i;
    [SerializeField] private Player player;

    private void Awake()
    {
        
    }

    void Update()
    {
        if (TestL && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            player.canOut = true;
            TestL = false;
            keyText.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = other.gameObject.name == "Player";
            keyText.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = !(other.gameObject.name == "Player");
            keyText.SetActive(false);
        }
    }
}