using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlaneController;

public class UILauncPower : MonoBehaviour
{
    public Image _launchPowerImage;    
    public static UILauncPower instance;
    [SerializeField]
    float fillSpeed;
    bool fillUp = false;
    float _launchPower;
    public float _getLaunchPower
    {
        get
        {
            return _launchPower;
        }
    }
    private void Awake()
    {
        instance = this;
        _launchPowerImage = GetComponent<Image>();
    }   
    void Update()
    {
        if (!PlaneInputManager.instance._isFirstMove)
        {
            //ekrana dokunana kadar f�rlatma aray�z� s�rekli hareket ediyor.
            FillImage();
        }
        else
        {
            //ekrana t�kland�ktan sonra f�rlatma g�c� aray�z�n� kapat�yor.
            transform.parent.gameObject.SetActive(false);
        }
        
    }    
    void FillImage()
    {
        if (_launchPowerImage.fillAmount==0)
        {
            //amount 0 olunca yukar� hareket etmesi i�in de�i�ken true yap�l�yor
            fillUp = true;
        }
        else if (_launchPowerImage.fillAmount==1)
        {
            //amount 1 olunca a�a�� hareket etmesi i�in de�i�ken false yap�l�yor
            fillUp = false;
        }
        if (fillUp)
        {
            //f�rlatma g�c� aray�z�n� yukar�ya hareket ettiriyor.
            _launchPowerImage.fillAmount += fillSpeed * Time.deltaTime;
        }
        else
        {
            //f�rlatma g�c� aray�z�n� a�a�� hareket ettiriyor
            _launchPowerImage.fillAmount -= fillSpeed * Time.deltaTime;
        }
        //t�kland��� andaki g�ce eri�mek i�in ataman�n yap�ld��� yer
        _launchPower = _launchPowerImage.fillAmount;
    }
}
