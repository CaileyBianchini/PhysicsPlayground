using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTempDeathBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ragdoll"))
        {
            _animator.enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ragdoll"))
        {
            _animator.enabled = true ;
        }
    }
}
