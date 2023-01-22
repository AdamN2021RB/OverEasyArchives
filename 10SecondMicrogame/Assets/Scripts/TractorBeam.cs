using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float vertical;
    

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //OnTriggerEnter2D();
    }

    public void Abduct()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Awake();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Vector2 position = other.transform.position;
        //checks if it's touching stuff with tag

            //other.gameObject.transform.Rotate(0f, 0f, 5f);
            position = Vector2.Lerp(other.transform.position, transform.parent.position, Time.deltaTime * speed);
            other.transform.position = position;
            //other.rigidbody2d.AddForce(direction * force);
            Debug.Log(position);

            other.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //dropping off enemies
        other.GetComponent<Rigidbody2D>().gravityScale = .5f;
    }
}
