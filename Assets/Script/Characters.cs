using UnityEngine;

public enum CharState
{
    Idle,
    Walk,
    Stealth,
    Die
}
public abstract class Characters : MonoBehaviour
{
    [SerializeField] 
    protected Animator anim;
    public Animator Anim {get{return anim;}}
    [SerializeField] 
    protected CharState charState;
    public CharState CharState {get { return charState; }}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetState(CharState s)
    {
        charState = s;
    }
}
