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

    //if object collides
    private void OnTriggerEnter(Collider other)
    {
        //with another objected tagged with Player
        if (other.gameObject.CompareTag("Player"))
        {
            //make oject invisble
            _object.enabled = false;
            //and turn off collision for object
            _collision.enabled = false;
        }
    }
}
