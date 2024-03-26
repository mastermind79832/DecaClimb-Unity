using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerScript : MonoBehaviour
{

    [SerializeField] private Rigidbody m_Rigidbody;
    [SerializeField] private float m_JumpVelocity;

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Ground")
        {
            m_Rigidbody.velocity = Vector3.up * m_JumpVelocity;
        }
    }
}
