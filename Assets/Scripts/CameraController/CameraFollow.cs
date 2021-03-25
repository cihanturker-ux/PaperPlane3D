using System;
using UnityEngine;

namespace CameraController
{
    public class CameraFollow : MonoBehaviour
    {
        private GameObject _player;
        private Vector3 distance;
        private void Start()
        {
            _player = GameObject.FindWithTag("Player"); 
            distance = transform.localPosition - _player.transform.position;
        }
        private void Update()
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x,_player.transform.eulerAngles.y,transform.eulerAngles.z);
            transform.position = (_player.transform.position + (Quaternion.Euler(0,transform.eulerAngles.y,0) * Vector3.forward)*distance.z) +new Vector3(0,distance.y,0);
            transform.LookAt(_player.transform);
        }
    }
}

