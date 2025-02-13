using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    private GameObject[] allText;
    [SerializeField] private GameObject keyText;
    [SerializeField] private GameObject tpText;
    [SerializeField] private GameObject boxText; // text open box
    [SerializeField] private GameObject tBoxText; //text กล่องถูก
    [SerializeField] private GameObject wBoxText; //text กล่องผิด
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void CloseAllExcept(GameObject textOpen)
    {
        string textOpenName = textOpen.name;
        
    }
}
