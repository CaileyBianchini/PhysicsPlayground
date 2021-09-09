using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTempDeathBehaviour : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            _animator.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ragdoll"))
        {
            _animator.enabled = true;
        }
    }

}
