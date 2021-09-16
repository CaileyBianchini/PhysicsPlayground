﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DoorKnobBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private bool _closeQuaters = false;

    //Character Behaviour class
    public Camera camera;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //if objects collides with object
    private void OnTriggerEnter(Collider other)
    {
        //tagged Player
        if (other.gameObject.CompareTag("Player"))
        {
            //_closeQuaters  will become true
            _closeQuaters = true;
        }
    }

    //if object exits collidtion with object
    private void OnTriggerExit(Collider other)
    {
        //tagged Player
        if (other.gameObject.CompareTag("Player"))
        {
            //_closeQuaters will become false
            _closeQuaters = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _closeQuaters == true)
        {
            //ray cast
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //calls the variable playerCamera from Character Behaviour class and puts that value in variable camera
            if (Physics.Raycast(ray, out hit))
            {
                //this moves object towards the mouse position;
                _rigidbody.position = hit.point;
            }
        }
    }
}