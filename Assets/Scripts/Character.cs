using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected float speed;
    protected Rigidbody2D hero;
    protected Vector2 move;
    protected bool kill = false;
    Animator anim;
    public void Init(float speed)
    {
        hero = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        this.speed = speed;
    }
    
    public void ChooseAnimation()
    {
        if (move != new Vector2(0, 0))
        {
            anim.SetBool("isActionEnd", false);
            if (move.x != 0)
            {
                anim.SetFloat("X", move.x);
                anim.SetFloat("Y", 0);
            }
            else
            {
                anim.SetFloat("Y", move.y);
                anim.SetFloat("X", 0);
            }
        }
        else
        {
            anim.SetBool("isActionEnd", true);
            anim.SetFloat("X", 0);
            anim.SetFloat("Y", 0);
        }
        anim.SetBool("Kill", kill);
    }
}
