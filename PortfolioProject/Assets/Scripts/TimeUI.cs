using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{

    private float _seconds;

    private int _minutes;

    private TextMeshProUGUI _timerText;

    private string _text;
    // Start is called before the first frame update
    void Start()
    {
        _timerText = GetComponent<TextMeshProUGUI>();
        _seconds = 0;
        _minutes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds >= 60.0f)
        {
            ++_minutes;
            _seconds = 0;
        }

        if (_minutes < 10)
        {
            if (_seconds < 10)
            {
                _text = $"0{_minutes}:0{(int)_seconds}";
            }
            else
            {
                _text = $"0{_minutes}:{(int)_seconds}";
            }
        }
        else
        {
            if (_seconds < 10)
            {
                _text = $"{_minutes}:0{(int) _seconds}";
            }
            else
            {
                _text = $"{_minutes}:{(int) _seconds}";
            }
        }

        _timerText.text = _text;
    }
}
