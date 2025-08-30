using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ChangeScene : MonoBehaviour
{
    int sceneIndex;
    bool canChangeScene = false;
    public void ChangeSceneCallback(InputAction.CallbackContext _)
    {
        canChangeScene = true;
    }

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (canChangeScene)
        {
            sceneIndex = (sceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(sceneIndex);
            canChangeScene = false;
        }
    }
}
