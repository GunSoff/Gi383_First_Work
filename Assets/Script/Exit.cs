using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private bool col = false;
    [SerializeField] private GameObject exit;

    [SerializeField] private float time;
    // Update is called once per frame
    void Awake()
    {
        time = 5f;
    }
    void Update()
    {
        if (player.canOut && Input.GetKeyDown(KeyCode.E)&&col)
        {
            exit.SetActive(true);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Application.Quit();
            }
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            col = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            col = false;
        }
    }
}
