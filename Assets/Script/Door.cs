using System;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] protected Collider collider;
    [SerializeField] protected KeyFor keyForThisDoor;
    [SerializeField] protected Player player;
    [SerializeField] protected bool isDoorClose;
    [SerializeField] protected bool isAtDoor;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsRightKey(player) && isAtDoor)
        {
            if (keyForThisDoor == KeyFor.FrontDoor)
            {
                player.canOut = true;
            }
            isDoorClose = false;
            collider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            isAtDoor = true;
            if (isDoorClose == false)
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
            return true;
        }
        else if (player.keys.Count == 0)
        {
            return false;
        }
        else
        {
            return false;
        }
    }
}
