using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Vector2 aligment = Aligment();
        transform.position += (Vector3)aligment;
        gameObject.GetComponent<AudioSource>().volume = MenuController.SoundVolume;
        gameObject.GetComponent<AudioSource>().PlayDelayed(1);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Block")
        {
            col.gameObject.GetComponent<Animator>().enabled = true;
            Destroy(col.gameObject, 0.5f);
        }
        else return;
    }
    
    Vector2 Aligment()
    {
        Vector2 aligment = new Vector2(0, 0);
        if (transform.position.x > 0)
            aligment.x = (float)(0.5 - (transform.position.x - System.Math.Truncate(transform.position.x)));
        if (transform.position.x < 0)
            aligment.x = (float)(-0.5 - (transform.position.x - System.Math.Truncate(transform.position.x)));
        if (transform.position.y > 0)
            aligment.y = (float)(0.5 - (transform.position.y - System.Math.Truncate(transform.position.y)));
        if (transform.position.y < 0)
            aligment.y = (float)(-0.5 - (transform.position.y - System.Math.Truncate(transform.position.y)));
        return aligment;
    }
}
