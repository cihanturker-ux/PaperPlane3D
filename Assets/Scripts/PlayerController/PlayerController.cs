using System;
using UnityEngine;

namespace PlaneController
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rb;
        private PlaneInputManager _planeInputManager;        
        public PlayerControllerSettings _playerContrrollerSettings;            
        [SerializeField]
        bool _isLaunched = false;
        public static PlayerController instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _planeInputManager = GetComponent<PlaneInputManager>();
            _rb.mass = _playerContrrollerSettings._PlayerMass;// uçağın kütlesi ayarlanıyor
        }
        private void FixedUpdate()
        {
            //Bir yere çarpılmadığı sürece burası çalışacak
            if (!GameManager.instance.IsGameOver)
            {
                PlayerMove();                
            }            
        }        
        private void PlayerMove()
        {            
            if (_isLaunched)
            {
                transform.Translate(0,0,UILauncPower.instance._getLaunchPower*_playerContrrollerSettings._getMoveSpeed * Time.fixedDeltaTime);// Z ekseninde ileri hareket
            }
            if (_planeInputManager._isFirstMove && !_isLaunched)
            {
                float uilaunchPower = UILauncPower.instance._getLaunchPower;//launch gücü arayüzünde tıklanan andaki güç
                float launchPower = _playerContrrollerSettings._getLaunchPower;//playerın maksimum fırlatma gücü
                Launch(uilaunchPower * launchPower);
                _isLaunched = true;
            }
            else if (_planeInputManager._isRight)
            {
                //sağa doğru hareket etmesi için açılar döndürülüyor
                transform.eulerAngles += new Vector3(0, _playerContrrollerSettings._getTurnSpeed * Time.fixedDeltaTime, -_playerContrrollerSettings._getRotationSpeed * Time.fixedDeltaTime);
                if (transform.eulerAngles.z<=30)
                {
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, 0, 30));
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, 330, 360));
                }
                
            }
            else if (_planeInputManager._isLeft)
            {             
                //sola doğru hareket etmesi için açılar döndürülüyor
                transform.eulerAngles += new Vector3(0, -_playerContrrollerSettings._getTurnSpeed * Time.fixedDeltaTime, _playerContrrollerSettings._getRotationSpeed * Time.fixedDeltaTime);
                if (transform.eulerAngles.z >=330)
                {
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, 330, 360));                    
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z, 0, 30));
                }
            }
            else
            {
                //ekrana basılmadığında uçağın açılarını varsayılana çeviriyor
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }            
            
        }
        //Y ekseninde güç uygulama
        void Launch(float launchPower)
        {
            _rb.AddForce(0,  launchPower * Time.fixedDeltaTime, 0, ForceMode.Impulse);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("LaunchPower"))
            {
                Launch(_playerContrrollerSettings._getLaunchPower);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _rb.constraints = RigidbodyConstraints.FreezeAll;
                //game over paneli yere çarpıldığında açılıyor.
                UIScript.instance._gameOverPanel.gameObject.SetActive(true);
                //oyun bittiğinde hareket kodlarının çalışmaması için değişken true yapılıyor.
                GameManager.instance.IsGameOver = true;
                GameManager.instance.Coin = (int)(GameManager.instance.CoinMultiplier * GameManager.instance.Meter); // coinmultiplier ile meter çarpılıp kazanılan para hesaplanıyor
                UIScript.instance._gainedCoinText.text = GameManager.instance.Coin+"$ Gained!";
                SaveScript.SetCoinData(SaveScript.GetCoinData() + GameManager.instance.Coin);
            }            
        }
    }
}

