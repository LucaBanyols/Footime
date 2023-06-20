using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneFunction(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void restartScene()
    {
        SceneManager.LoadScene("Scenes/" + SceneManager.GetActiveScene().name);
    }
}
