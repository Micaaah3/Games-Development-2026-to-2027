using System;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField]
    private float _barMin;
    [SerializeField]
    private float _barMax;
    [SerializeField]
    private float _current;

    [SerializeField]
    private Color _mainColor;
    [SerializeField]
    private Color _backgroundColor;

    [SerializeField]
    private string _title;

    [SerializeField]
    private Boolean _isTesting = false;




    #region Constructors
    public Bar()
    {
    }

    public Bar(float min, float curr, float max)
    {
        SetBarMin(min);
        SetCurrent(curr);
        SetBarMax(max);
        SetMainColor(Color.green);
        SetBackgroundColor(Color.red);
        SetTitle("");
    }

    public Bar(float min, float curr, float max,Color primary, Color secondary)
    {
        SetBarMin(min);
        SetCurrent(curr);
        SetBarMax(max);
        SetMainColor(primary);
        SetBackgroundColor(secondary);
        SetTitle("");
    }

    public Bar(float min, float curr, float max, Color primary, Color secondary,string title)
    {
        SetBarMin(min);
        SetCurrent(curr);
        SetBarMax(max);
        SetMainColor(primary);
        SetBackgroundColor(secondary);
        SetTitle(title);
    }

    #endregion
    #region property get/setters


    public float GetBarMin()
    {
        return _barMin;
    }

    public void SetBarMin(float value)
    {
        if (_isTesting)
            Debug.Log("Bar new min value is now: " + value);
        _barMin = value;
    }

    public float GetBarMax()
    {
        return _barMax;
    }

    public void SetBarMax(float value)
    {
        if (_isTesting)
            Debug.Log("Bar new max value is now: " + value);
        _barMax = value;
    }

    public float GetCurrent()
    {
        return _current;
    }

    public void SetCurrent(float value)
    {
        if (_isTesting)
            Debug.Log("Bar new current value is now: " + value);
        _current = value;
    }

    public void SetCurrentPercent(float percentage)
    {
        var value = GetBarMax() * percentage;

        if (_isTesting)
            Debug.Log("Bar new current value is now: " + value + " from using " + (percentage*100) + "%");
        _current = value;
    }

    public Color GetMainColor()
    {
        return _mainColor;
    }

    public void SetMainColor(Color value)
    {
        if (_isTesting)
            Debug.Log("Bar new main color is now: " + value);
        _mainColor = value;
    }

    public Color GetBackgroundColor()
    {
        return _backgroundColor;
    }

    public void SetBackgroundColor(Color value)
    {
        if (_isTesting)
            Debug.Log("Bar new background color is now: " + value);
        _backgroundColor = value;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTitle(string value)
    {
        if (_isTesting)
            Debug.Log("Bar new title is now: " +  value);
        _title = value;
    }
    public bool GetIsTesting()
    {
        return _isTesting;
    }

    public void SetIsTesting(bool value)
    {
        Debug.Log("Testing Mode for Bar:" + value);
        _isTesting = value;
    }
    #endregion
}
