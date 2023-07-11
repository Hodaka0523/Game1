using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TimeCountController : MonoBehaviour
{
    [SerializeField] int _minute;
    [SerializeField] float _seconds;
    float _oldSeconds;
    private Text _timeText;
    GameObject _player;
    public static float _score = default(float);
    public void Start()
    {
        _minute = 0;
        _seconds = 0f;
        _oldSeconds = 0f;
        _timeText = GetComponent<Text>();
        _player = GameObject.Find("player"); 
    }
    
    public void Update()
    {
        _seconds += Time.deltaTime;
        if (_seconds >= 60)
        {
            _minute++;
            _seconds -= 60; 
        }
        if(_seconds != _oldSeconds)
        {
            _timeText .text = _minute.ToString("00") + ":" + _seconds.ToString("00");
        }
        _oldSeconds = _seconds;
        if (SceneManegerMain._isGameover == true)
        {
            _score = _minute * 600 + _seconds * 10;           
        }
    }
}
