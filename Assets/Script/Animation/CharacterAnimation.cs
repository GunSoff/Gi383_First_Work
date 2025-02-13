using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimation : MonoBehaviour
{
    private Characters character;

    void Awake()
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
                c.Anim.SetBool("IsWalk", false);
                c.Anim.SetBool("IsDie", false);
                break;
            case CharState.Walk:
                c.Anim.SetBool("IsWalk", true);
                c.Anim.SetBool("IsIdle", false);
                c.Anim.SetBool("IsDie", false);
                break;
                case CharState.Die:
                c.Anim.SetBool("IsDie",true);
                c.Anim.SetBool("IsWalk", false);
                c.Anim.SetBool("IsIdle", false);
                break;
        }
    }

    void Update()
    {
        ChooseAnimation(character);
    }
}
