using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Canvas _restartMenu;
    [SerializeField] private MonoBehaviour[] _scriptsToDisableOnPause;

    public bool IsPaused
    {
        get => _isPaused;
        set
        {
            if (_isPaused == value)
                return;

            _isPaused = value;
            Time.timeScale = value ? 0 : 1;
            Array.ForEach(_scriptsToDisableOnPause, script => script.enabled = !value);
        }
    }
    private bool _isPaused;

    public void End()
    {
        IsPaused = true;
        _restartMenu.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    
    private void Awake()
    {
        _restartMenu.gameObject.SetActive(false);
    }
}
