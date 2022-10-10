using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector3 pos;
    private float speed = 20f;
    private float rotateSpeed = 45f;
    public GameObject eggSample;
    public GameObject planeSample;
    public Camera mTheCamera;
    private float nextFireTime = 0;
    private float cooldown = 0.2f;
    private 

    // Start is called before the first frame update
    void Start()
    {
        //mTheCamera = gameObject.GetComponent<Camera>();
        float maxY = mTheCamera.orthographicSize;
        float maxX = mTheCamera.orthographicSize * mTheCamera.aspect;
        for (int i = 0; i < 10; i++) {
            GameObject p = GameObject.Instantiate(planeSample) as GameObject;
            float x = Random.Range((-1 * maxX) * .9f, maxX * .9f);
            float y = Random.Range((-1 * maxY) * .9f, maxY * .9f);
            p.transform.position = new Vector3(x, y, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")) {
            Application.Quit();
        }
        if (Input.GetKeyDown("m")) {
            speed = 20f;
            gameSystem.isMouse = !gameSystem.isMouse;
        }
        if (gameSystem.isMouse)
        {
            mouseMovement();
        }
        else
        {
            keyMovement();
        }
        transform.Rotate(Vector3.forward, -1f * Input.GetAxis("Horizontal") * (rotateSpeed * Time.smoothDeltaTime));
        if (Time.time > nextFireTime)
        {
            if (Input.GetKey("space"))
            {
                GameObject e = GameObject.Instantiate(eggSample) as GameObject;
                gameSystem.spawnEgg(e, transform.position, transform.up);
                nextFireTime = Time.time + cooldown;
            }
        }
    }

    void mouseMovement() {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
    }
    void keyMovement() {
        if (Input.GetKey("w"))
        {
            speed += Input.GetAxis("Vertical");
        }
        else if (Input.GetKey("s"))
        {
            speed += Input.GetAxis("Vertical");
        }
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
    }
}
