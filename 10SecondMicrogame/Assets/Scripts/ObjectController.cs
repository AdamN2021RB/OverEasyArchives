using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

   void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Beam"))
        {
            transform.Rotate(0f, 0f, 5f);
        }
    }

}

//gonna find another solution
