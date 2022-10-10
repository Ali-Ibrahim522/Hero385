using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private int health = 4;
    public SpriteRenderer plane;
    //public Camera mTheCamera;

    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GreenUp")
        {
            gameSystem.increaseCollisions();
            spawnEnemy();
            Destroy(gameObject);
        }
        else if (collision.gameObject.name == "Egg(Clone)") 
        {
            if (health == 1)
            {
                spawnEnemy();
                Destroy(gameObject);
            }
            else
            {
                plane.color = new Color(plane.color.r, plane.color.g, plane.color.b, plane.color.a * .8f);
                health--;
            }
        }
    }

    void spawnEnemy() {
        gameSystem.increaseDefeated();
        float maxY = Camera.main.orthographicSize;
        float maxX = Camera.main.orthographicSize * Camera.main.aspect;
        float x = Random.Range((-1 * maxX) * .9f, maxX * .9f);
        float y = Random.Range((-1 * maxY) * .9f, maxY * .9f);
        plane.color = new Color(plane.color.r, plane.color.g, plane.color.b, 1f);
        gameObject.transform.name = "Plane";
        GameObject p = Instantiate(gameObject, new Vector3(x, y, 0f), Quaternion.identity);
    }
}
