using System;
using UnityEngine;

public class Dollhouse : MonoBehaviour
{
    [SerializeField] protected Player player;
    [SerializeField] protected Collider collider;
    [SerializeField] protected Transform spawnPos;
    [SerializeField] protected bool isTrigger;
    [SerializeField] public bool isAllowed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isAllowed && isTrigger)
        {
            player.transform.position = spawnPos.transform.position;
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
