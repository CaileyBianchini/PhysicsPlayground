using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBehaviour : MonoBehaviour
{
    public string nextSceneName;
    public string previousScene;
    public int scene;
    public Canvas level;

    private bool _onObject = false;

    private void Awake()
    {
        level = GetComponent<Canvas>();
    }

    //if object collides
    private void OnTriggerEnter(Collider other)
    {
        //with a object tagged player
        if (other.gameObject.CompareTag("Player"))
        {
            //it will enable the level canvas
            level.enabled = true;
        }
    }

    public void NextScene()
    {
        //this will load scene by its index and name
        SceneManager.LoadScene(sceneName: nextSceneName);
        SceneManager.LoadScene(sceneBuildIndex: scene);
    }
}
