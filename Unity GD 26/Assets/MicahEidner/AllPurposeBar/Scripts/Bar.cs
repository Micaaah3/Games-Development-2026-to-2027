using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    private Boolean _isScreenOverlay = false;

    [SerializeField]
    private Vector3 _position;

    [SerializeField]
    private Slider _slider;


    [SerializeField]
    private TextMeshProUGUI _text;
    
    [SerializeField]
    private Image _background;
    [SerializeField]
    private Image _fill;
    [SerializeField]
    private Boolean _isTesting = false;

    private void Start()
    {
        SetBackgroundColor(_backgroundColor);
        SetMainColor(_mainColor);
        
        SetBarMax(_barMax);
        SetBarMin(_barMin);
        
        SetCurrent(_current);

        if (_isScreenOverlay)
        {
            _position = transform.localPosition;
        }
        
        SetPosition(_position);
    }

    private void Update()
    {
        if (!_isTesting)
            return;
        
        SetBackgroundColor(_backgroundColor);
        SetMainColor(_mainColor);
        
        SetCurrent(_current);
        SetBarMax(_barMax);
        SetBarMin(_barMin);
        SetPosition(_position);
        SetTitle(_title);
        
    }
    
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
        _slider.minValue = _barMin;
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
        _slider.maxValue = _barMax;
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
        _slider.value = _current;
    }

    public void SetCurrentPercent(float percentage)
    {
        var value = GetBarMax() * percentage;

        if (_isTesting)
            Debug.Log("Bar new current value is now: " + value + " from using " + (percentage*100) + "%");
        _current = value;
        _slider.value = _current;
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
        _fill.color = _mainColor;
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
        _background.color = _backgroundColor;
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
        _text.text = _title;
    }
    public bool GetIsTesting()
    {
        return _isTesting;
    }

    public void SetIsTesting(bool value)
    {
        if (_isTesting)
            Debug.Log("Bar new title is now: " + value);
        _isScreenOverlay = value;
    }
    public bool GetIsScreenOverlay()
    {
        return _isTesting;
    }

    public void SetIsScreenOverlay(bool value)
    {
        if (_isTesting)
            Debug.Log("Bar new title is now: " + value);
        _isScreenOverlay = value;
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
        
        if (_isScreenOverlay)
        {
            transform.localPosition = _position;
            return;
        }
        transform.position = _position;
    }

    public TextMeshProUGUI Text
    {
        get => _text;
        set => _text = value;
    }
    #endregion
}
