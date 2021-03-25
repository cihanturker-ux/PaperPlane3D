using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlayerSettings/PlayerControllerSettings")]
public class PlayerControllerSettings : ScriptableObject
{
    [SerializeField] private float _launchPower;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _playerMass;
    public float _getLaunchPower
    {
        get
        {
            return _launchPower;
        }
    }
    public float _getMoveSpeed
    {
        get
        {
            return _moveSpeed;
        }
    }
    public float _getTurnSpeed
    {
        get
        {
            return _turnSpeed;
        }
    }
    public float _getRotationSpeed
    {
        get
        {
            return _rotationSpeed;
        }
    }
    public float _PlayerMass
    {
        get
        {
            return _playerMass;
        }
        set
        {
            _playerMass = value;
        }
    }
}
