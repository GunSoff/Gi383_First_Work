using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class Box : MonoBehaviour
{
    [SerializeField] private bool TestL; 
    [SerializeField ]private bool destroyBox = false;
    [SerializeField] private bool keyBox;
    [SerializeField] private GameObject boxText; // text open box
    [SerializeField] private GameObject tBoxText; //text กล่องถูก
    [SerializeField] private GameObject wBoxText; //text กล่องผิด
    [SerializeField] private Player player;
    [SerializeField] private float time;

    private void Awake()
    {
        time = 2f;   
    }

    void Update()
    {
        if (TestL && Input.GetKeyDown(KeyCode.E))
        {
            boxText.SetActive(false);
            destroyBox = true;
        }
        if (keyBox && destroyBox)
        {
            CountdownCloseTextWithTime(tBoxText, wBoxText, boxText);
        }
        else if (!keyBox && destroyBox)
        {
            CountdownCloseTextWithTime(wBoxText, tBoxText, boxText);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = other.gameObject.name == "Player";
            boxText.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            TestL = !(other.gameObject.name == "Player");
            boxText.SetActive(false);
        }
    }

    private void CountdownCloseTextWithTime(GameObject textActive, GameObject textInactive_1 , GameObject textInactive_2)
    {
        time -= Time.deltaTime;
        if (time > 0)
        {
            textActive.SetActive(true);
            textInactive_1.SetActive(false);
            textInactive_2.SetActive(false);
            Debug.Log("if");
        }
        else
        {
            Debug.Log("else");
            time = 0f;
            textActive.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}