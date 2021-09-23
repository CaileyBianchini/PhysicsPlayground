using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    public Canvas menu;
    public Canvas customMenu;

    private void Awake()
    {
        menu = GetComponent<Canvas>();
        customMenu = GetComponent<Canvas>();
    }

    //this will turn start menu canvas invisible and bring up the custom canvas
    public void StartMenu()
    {
        menu.enabled = false;
    }

    //if player is done customizing they can turn the canvas invisible
    public void customDone()
    {
        menu.enabled = false;
        customMenu.enabled = false;
    }
}
