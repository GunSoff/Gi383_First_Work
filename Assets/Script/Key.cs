using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public enum KeyFor
{
    FrontDoor,
    BathDoor,
    LadderDoor,
    StorageDoor,
    DollHouse,
    None
}

public class Key : MonoBehaviour
{
    [SerializeField] private bool TestL;
    [SerializeField] private GameObject keyText;
    [SerializeField] private int i;
    [SerializeField] private Player player;
    [SerializeField] private KeyFor keyfor;

    private void Awake()
    {
        
    }

    void Update()
    {
        if (TestL && Input.GetKeyDown(KeyCode.E))
        {
            TestL = false;
            keyText.SetActive(false);
            player.keys.Add(keyfor);
            
            gameObject.SetActive(false);
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