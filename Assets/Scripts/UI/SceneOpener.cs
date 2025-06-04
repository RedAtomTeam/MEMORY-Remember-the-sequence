using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpener : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void OpenScene()
    {
        SceneManager.LoadSceneAsync(_sceneName);
    }
}
