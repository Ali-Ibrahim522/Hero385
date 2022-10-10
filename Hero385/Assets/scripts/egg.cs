using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg : MonoBehaviour
{
    private float projSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * (projSpeed * Time.smoothDeltaTime);
    }

    private void OnBecameInvisible()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            gameSystem.decreaseEggCount();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "GreenUp") {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
                gameSystem.decreaseEggCount();
            }
        }
    }
}
