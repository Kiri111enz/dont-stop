using System;
using TMPro;
using UnityEngine;

public class Timer : RepeaterWithDelay
{
    [Space]
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _format = @"mm\:ss";
    [SerializeField] private float _time;

    protected override void OnRepeat()
    {
        _time += Delay;
        DisplayTime();
    }

    private void DisplayTime()
    {
        _text.text = TimeSpan.FromSeconds(_time).ToString(_format);
    }
}
