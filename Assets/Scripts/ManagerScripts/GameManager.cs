using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlaneController;
public class GameManager : MonoBehaviour
{    
    [SerializeField]
    private int _coinMultiplier;
    public int CoinMultiplier
    {
        get
        {
            return _coinMultiplier;
        }        
    }
    private bool _isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return _isGameOver;
        }
        set
        {
            _isGameOver = value;
        }
    }
    private float _meter = 0;
    public float Meter
    {
        get
        {
            return _meter;
        }
        set
        {
            _meter = value;
        }
    }
    private int _coin = 0;
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
    private int _gainedCoin = 0;
    public int GainedCoin
    {
        get
        {
            return _gainedCoin;
        }
        set
        {
            _gainedCoin = value;
        }
    }
    public static GameManager instance;
    private void Start()
    {
        instance = this;
        if (SaveScript.GetFirstStartData()!=1)
        {
            SaveScript.SetFirstStartData(1);
            SaveScript.SetCoinData(0);
        }        
        UIScript.instance._coinText.text = SaveScript.GetCoinData() + "$";
        UIScript.instance._meterText.text = (int)_meter + "m";

    }
    private void Update()
    {
        if (!_isGameOver && PlaneInputManager.instance._isFirstMove)
        {
            SetMeter();
        }
    }
    private void SetMeter()
    {
        _meter += PlayerController.instance._playerContrrollerSettings._getMoveSpeed*Time.fixedDeltaTime;
        UIScript.instance._meterText.text = _meter + "m";
    }
}
