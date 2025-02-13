using System;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public enum Location
{
    Up,
    Down
}
public class TP : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private bool TestL;
    [SerializeField] private GameObject tpText;
    [SerializeField] private Location location;

    private void Update()
    {
        if(TestL && Input.GetKeyDown(KeyCode.E))
        {
            if (location == Location.Down)
            {
                playerPrefab.transform.position = new UnityEngine.Vector3(-29f, 8.5f, -0.6f);
            }
            else if (location == Location.Up)
            {
                playerPrefab.transform.position = new UnityEngine.Vector3(-27f, 11.2f, -0.6f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = other.gameObject.name == "Player";
            tpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = !(other.gameObject.name == "Player");
            tpText.SetActive(false);
        }
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = other.gameObject.name == "Player";
            tpText.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = !(other.gameObject.name == "Player");
            tpText.SetActive(false);
        }
    }*/
}
