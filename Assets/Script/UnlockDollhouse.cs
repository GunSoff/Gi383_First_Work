using System;
using UnityEngine;

public class UnlockDollhouse : MonoBehaviour
{
    [SerializeField] private KeyFor keyForDollhouse = KeyFor.DollHouse;
    [SerializeField] private Player player;
    [SerializeField] private Dollhouse dollhouse;
    private bool isTrigger;

    private void Update()
    {
        if (player.keys.Contains(keyForDollhouse) && Input.GetKeyDown(KeyCode.E) && isTrigger)
        {
            dollhouse.isAllowed = true;
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
        isTrigger = false;
    }
}
