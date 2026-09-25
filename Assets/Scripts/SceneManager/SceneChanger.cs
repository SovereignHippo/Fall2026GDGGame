using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
         SceneManager.LoadScene(sceneName);
    }
}
