using System;
using TMPro;
using UnityEngine;

public class Timer : RepeaterWithDelay
{
    [field: Space, SerializeField]
    public float Time { get; private set; }

    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _format = @"mm\:ss";

    public string TextFromTime(float seconds) => TimeSpan.FromSeconds(seconds).ToString(_format);

    protected override void OnRepeat()
    {
        Time += Delay;
        _text.text = TextFromTime(Time);
    }
}
