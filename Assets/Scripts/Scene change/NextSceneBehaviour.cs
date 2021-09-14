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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            level.enabled = true;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
        SceneManager.LoadScene(sceneBuildIndex: scene);
    }
}
