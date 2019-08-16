using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character
{
    bool down = true;
    // Start is called before the first frame update
    void Start()
    {
        Init(1.5f);
        move = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation();
    }
    void FixedUpdate()
    {
        hero.MovePosition(hero.position + move * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bomb")
        {
            kill = true;
            hero.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(gameObject, 0.9f);
        }
        if (down)
        {
            move.y = -speed;
            down = false;
        }
        else
        {
            move.y = speed;
            down = true;
        }
    }
}
