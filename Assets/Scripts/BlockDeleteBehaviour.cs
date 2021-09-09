using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeleteBehaviour : MonoBehaviour
{
    public MeshRenderer _object;
    private Collider _collision;

    private void Awake()
    {
        _object = GetComponent<MeshRenderer>();
        _collision = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _object.enabled = false;
            _collision.enabled = false;
        }
    }
}
