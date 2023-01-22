using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpook : MonoBehaviour
{
    Animator cowAnim;
    //bool abducted;
    // Start is called before the first frame update
    void Start()
    {
        cowAnim = GetComponent<Animator>();
        //abducted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Beam"))
        {
            //abducted = true;
            cowAnim.SetBool("SuckedUp", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        cowAnim.SetBool("SuckedUp", false);
    }
}
