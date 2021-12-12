using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerScript : MonoBehaviour
{

    public Rigidbody rb;

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.up * 7f;
        }
    }
}
