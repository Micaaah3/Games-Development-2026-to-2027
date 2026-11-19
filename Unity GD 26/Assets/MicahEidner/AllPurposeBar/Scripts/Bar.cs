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

    private GameObject _owner;
    
    // _position can act as an offset to _owner
    private Vector3 _position;

    private bool _ignoreOwner = false;


    #region Constructors
    public Bar()
    {
    }

    public Bar(float min, float curr, float max, Vector3 position)
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
        if (_isTesting)
            Debug.Log("Bar new title is now: " + value);
        _isTesting = value;
    }


    public Vector3 GetPosition()
    {
        return _position;
    }

    public void SetPosition(Vector3 value)
    {
        if (_isTesting)
            Debug.Log("Bar position/offset is now: " + value);
        _position = value;
    }

    public GameObject GetOwner()
    {
        return _owner;
    }

    public void SetOwner(GameObject value)
    {
        if (_isTesting)
            Debug.Log("Bar new owner is now: " + value);
        _owner = value;
    }

    public bool GetIgnoreOwner()
    {
        return _ignoreOwner;
    }

    public void SetIgnoreOwner(bool value)
    {
        if (_isTesting)
            Debug.Log("Bar ignore owner is now " + value);
        _ignoreOwner = value;
    }
    #endregion
}
