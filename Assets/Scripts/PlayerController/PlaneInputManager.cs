using UnityEngine;

namespace PlaneController
{
    public class PlaneInputManager : MonoBehaviour
    {
        public bool _isRight;
        public bool _isLeft;
        public bool _isFirstMove;
        public bool _planeMove;
        private float _touchCount;
        private Touch _isTouch;
        public float _touchXPosTwo;
        public float _touchXPosFirst;
        public static PlaneInputManager instance;
        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            _isRight = false;
            _isFirstMove = false;
            _isLeft = false;
        }
        private void Update()
        {
            TouchInput();
        }
        private void TouchInput()
        {
            _touchCount = Input.touchCount;
             if (_touchCount > 0)
             {
                 _isTouch = Input.GetTouch(0);
                 if (_isTouch.phase == TouchPhase.Began)
                 {
                     _touchXPosFirst = Input.mousePosition.x;
                     _isFirstMove = true;
                    //tap to start paneli ekrana dokunulduğunda kapatılıyor.
                    UIScript.instance._tapToLaunchPanel.gameObject.SetActive(false);
                 }
                 else if (_isTouch.phase == TouchPhase.Moved)
                 {
                     // Dokunma Devam ediyor parmagını hareket ettiriyor.
                     // X konumunu algıla
                     _touchXPosTwo = Input.mousePosition.x;
                     if (_touchXPosFirst > _touchXPosTwo)
                     {
                         // Sola gidiyor.
                         _isRight = false;
                         _isLeft = true;
                     }
                     else if (_touchXPosFirst < _touchXPosTwo)
                     {
                         // Saga gidiyor.
                         _isLeft = false;
                         _isRight = true;
                     }
                 }
                 else if (_isTouch.phase == TouchPhase.Ended)
                 {
                     // Elini çekti
                     _isLeft = false;
                     _isRight = false;
                 }
             }   
        }
    }  
}

