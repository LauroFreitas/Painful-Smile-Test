﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIValues : MonoBehaviour
{
    public Text valueEnemyTime;
    public Text valueSessonTime;
    [SerializeField] public static string _valueSessonTime{ get; private set; }
    [SerializeField] public static string _valueEnemyTime { get; private set;}

    public void Start()
    {
        ValueSessonTimeUpdate(60);
        ValueEnemyTimeSpawnUpdate(3);
    }
    public void ValueEnemyTimeSpawnUpdate(float _value)
    {
        valueEnemyTime.text = _value.ToString();
        _valueEnemyTime = valueEnemyTime.text;
    }
    public void ValueSessonTimeUpdate(float _value)
    {
        valueSessonTime.text = _value.ToString();
        _valueSessonTime = valueSessonTime.text;
    }
}
