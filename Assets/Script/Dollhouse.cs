using System;
using UnityEngine;

public class Dollhouse : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Collider collider;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private bool isTrigger;
    [SerializeField] private bool isAllowed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && isAllowed)
            {
                player.transform.position = spawnPos.transform.position;
            }
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
