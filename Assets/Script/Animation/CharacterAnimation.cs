using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimation : MonoBehaviour
{
    private Characters character;

    void Start()
    {
        character = GetComponent<Characters>();
    }

    private void ChooseAnimation(Characters c)
    {
        c.Anim.SetBool("IsIdle", false);
        c.Anim.SetBool("IsWalk", false);
        c.Anim.SetBool("IsDie", false);

        switch (c.CharState)
        {
                case CharState.Idle:
                c.Anim.SetBool("IsIdle", true);
                break; 
                case CharState.Walk:
                c.Anim.SetBool("IsWalk", true);
                break;
                case CharState.Die:
                c.Anim.SetBool("IsDie",true);
                break;
        }
    }

    void Update()
    {
        ChooseAnimation(character);
    }
}
