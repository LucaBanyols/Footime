using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToJerseyMenu : MonoBehaviour
{
    public void SwitchSceneToJerseyMenu(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
