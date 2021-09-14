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

    public void StartMenu()
    {
        menu.enabled = false;
        customMenu.enabled = true;
    }

    public void customDone()
    {
        menu.enabled = false;
        customMenu.enabled = false;
    }
}
