using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneBehaviour : MonoBehaviour
{
    public string nextSceneName;
    public string previousScene;
    public int scene;

    private bool _onObject = false;

    private void ChangeScene(string previousScene)
    {
        SceneManager.LoadScene(sceneName: nextSceneName);
        SceneManager.LoadScene(sceneBuildIndex: scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onObject = true;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter) && _onObject == true)
        {
            //transition

            //load scene
            ChangeScene(previousScene);
            _onObject = false;
        }
    }
}
