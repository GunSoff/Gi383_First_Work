using System;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private bool isTrigger;
    [SerializeField] private GameObject noteSprite;
    private bool isActive = false;

    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.E) && !isActive)
        {
            noteSprite.SetActive(true);
            isActive = true;
        }
        else if (isTrigger && Input.GetKeyDown(KeyCode.E) && isActive)
        {
            noteSprite.SetActive(false);
            isActive = false;
        }
        else if (!isTrigger)
        {
            noteSprite.SetActive(false);
            isActive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = false;
        }
    }
}
