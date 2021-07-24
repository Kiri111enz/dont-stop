using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private int _timeLeft;
    [SerializeField] private Game _game;

    private IEnumerator Start()
    {
        _game.IsPaused = true;
        
        while (_timeLeft > 0)
        {
            _text.text = _timeLeft.ToString();
            yield return new WaitForSecondsRealtime(1);
            _timeLeft--;
        }
        
        Destroy(_text.gameObject);
        _game.IsPaused = false;
    }
}
