using System;
using UnityEngine;

public class TP : MonoBehaviour
{
    [SerializeField] private bool TestL;
    [SerializeField] private GameObject tpText;
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
