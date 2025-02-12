using System;
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
    [SerializeField] private Location location = Location.Down;

    private void Update()
    {
        if(TestL && Input.GetKeyDown(KeyCode.E))
        {
            if (location == Location.Down)
            {
                playerPrefab.transform.position = playerPrefab.transform.position;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
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
    }
}
