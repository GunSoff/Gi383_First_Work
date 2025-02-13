using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider collider;
    [SerializeField] private KeyFor keyForThisDoor;
    [SerializeField] private Player player;
    [SerializeField] private bool isDoorClose;
    [SerializeField] private bool isAtDoor;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsRightKey(player) && isAtDoor)
        {
            isDoorClose = false;
            collider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isAtDoor = true;
            if (!isDoorClose)
            {
                collider.enabled = false;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isAtDoor = false;
        }
    }

    private bool IsRightKey(Player player)
    {
        if (player.keys.Contains(keyForThisDoor))
        {
            Debug.Log("player have key");
            return true;
        }
        else
        {
            Debug.Log("player don't have key");
            return false;
        }
    }
}
