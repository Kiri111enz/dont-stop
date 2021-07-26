using TMPro;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text _finalTimeText;
    [SerializeField] private TMP_Text _bestTimeText;
    [SerializeField] private string _bestTimeTextFormat = "Best time: {0}";
    [SerializeField] private TMP_Text _newRecordText;
    
    [SerializeField] private Timer _timer;
    [SerializeField] private Game _game;

    private const string BestTimeVarName = "bestTime";

    private void RegisterAndDisplayTime()
    {
        if (_timer.Time >= PlayerPrefs.GetFloat(BestTimeVarName))
        {
            PlayerPrefs.SetFloat(BestTimeVarName, _timer.Time);
            _newRecordText.gameObject.SetActive(true);
        }

        _finalTimeText.text = _timer.TextFromTime(_timer.Time);
        _bestTimeText.text = string.Format(_bestTimeTextFormat, 
            _timer.TextFromTime(PlayerPrefs.GetFloat(BestTimeVarName)));
    }

    private void Awake() => _game.Ended += RegisterAndDisplayTime;
}
