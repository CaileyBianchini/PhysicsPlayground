using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class KnobBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;

    //Character Behaviour class
    public Camera camera;

    //ray cast
    RaycastHit hit;
    Ray ray;

    private void Awake()
    {
        //calls the variable playerCamera from Character Behaviour class and puts that value in variable camera
        camera = gameObject.GetComponent<CharacterBehaviour>().playerCamera;
        ray = camera.ScreenPointToRay(Input.mousePosition);
    }

    private void Update()
    {
        if (Physics.Raycast(ray, out hit))
        {
            //this moves object towards the mouse position;
            _rigidbody.position = hit.point;
        }
    }
}
