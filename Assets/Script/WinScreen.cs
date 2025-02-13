using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private SceneManager sceneManager;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sceneManager.LoadSceneWin();
        }
    }
}
