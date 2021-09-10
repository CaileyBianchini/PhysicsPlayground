using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBehaviour : MonoBehaviour
{
    public string nextSceneName;
    public int scene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetButtonDown("Next"))
        {
            //SceneManager.LoadScene(sceneName: nextSceneName);
             SceneManager.LoadScene(sceneBuildIndex: scene);
        }
    }
}
