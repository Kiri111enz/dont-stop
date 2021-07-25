using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _gameSceneName = "Game";
    
    public void Play() => SceneManager.LoadScene(_gameSceneName, LoadSceneMode.Single);

    public void Quit() => Application.Quit();
}
