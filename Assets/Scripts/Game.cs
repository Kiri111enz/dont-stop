using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Canvas _restartMenu;

    private void Awake()
    {
        _restartMenu.gameObject.SetActive(false);
    }

    public void End()
    {
        Pause();
        _restartMenu.gameObject.SetActive(true);
    }

    public void Restart()
    {
        UnPause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private static void Pause() => Time.timeScale = 0;

    private static void UnPause() => Time.timeScale = 1;
}
