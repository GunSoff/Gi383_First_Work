using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private bool col = false;
    [SerializeField] private SceneManager sceneManager;
    // Update is called once per frame
    void Awake()
    {
        
    }
    void Update()
    {
        if (player.canOut && Input.GetKeyDown(KeyCode.E)&&col)
        {
            sceneManager.LoadSceneWin();
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
