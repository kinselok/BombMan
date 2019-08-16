using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroControler : Character
{
    // Start is called before the first frame update
    void Start()
    {
        Init(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Instantiate(Resources.Load("Prefabs/Bomb"), hero.transform.position, Quaternion.identity);//создает чилдом
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
        ChooseAnimation();
        Vector3 CameraPosition = Camera.main.transform.position;
        if (hero.position.x > 0 && hero.position.x < 9) Camera.main.transform.position = new Vector3(transform.position.x, CameraPosition.y, CameraPosition.z);
    }
    void FixedUpdate()
    {
        hero.MovePosition(hero.position + move * Time.fixedDeltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy"|| col.tag == "Bomb")
        {
            kill = true;
            hero.constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(StopGame());
        }
        else return;
    }
    IEnumerator StopGame()
    { 
        yield return new WaitForSeconds(1.0f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);   
    }
}
