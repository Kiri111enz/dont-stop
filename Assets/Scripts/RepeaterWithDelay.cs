using System.Collections;
using UnityEngine;

public abstract class RepeaterWithDelay : MonoBehaviour
{
    [Header("Repeater settings (in seconds)")]
    [SerializeField] private float _delay;
    [SerializeField] private float _delayStep;
    [SerializeField] private float _minimalDelay;

    protected float Delay
    {
        get => _delay = Mathf.Max(_minimalDelay, _delay);
        private set => _delay = Mathf.Max(_minimalDelay, value);
    }
    
    protected abstract void OnRepeat();
    
    private IEnumerator RepetitionLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Delay);
            OnRepeat();

            if (Delay != _minimalDelay) // actually correct here
                Delay -= _delayStep;
        }
    }

    private void Awake() => StartCoroutine(RepetitionLoop());
}
