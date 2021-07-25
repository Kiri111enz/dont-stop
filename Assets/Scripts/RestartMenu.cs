using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] private string _menuSceneName = "MainMenu";
    
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);

    public void ReturnToMenu() => SceneManager.LoadScene(_menuSceneName, LoadSceneMode.Single);
}
