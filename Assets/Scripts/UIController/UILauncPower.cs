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
            //ekrana dokunana kadar fýrlatma arayüzü sürekli hareket ediyor.
            FillImage();
        }
        else
        {
            //ekrana týklandýktan sonra fýrlatma gücü arayüzünü kapatýyor.
            transform.parent.gameObject.SetActive(false);
        }
        
    }    
    void FillImage()
    {
        if (_launchPowerImage.fillAmount==0)
        {
            //amount 0 olunca yukarý hareket etmesi için deðiþken true yapýlýyor
            fillUp = true;
        }
        else if (_launchPowerImage.fillAmount==1)
        {
            //amount 1 olunca aþaðý hareket etmesi için deðiþken false yapýlýyor
            fillUp = false;
        }
        if (fillUp)
        {
            //fýrlatma gücü arayüzünü yukarýya hareket ettiriyor.
            _launchPowerImage.fillAmount += fillSpeed * Time.deltaTime;
        }
        else
        {
            //fýrlatma gücü arayüzünü aþaðý hareket ettiriyor
            _launchPowerImage.fillAmount -= fillSpeed * Time.deltaTime;
        }
        //týklandýðý andaki güce eriþmek için atamanýn yapýldýðý yer
        _launchPower = _launchPowerImage.fillAmount;
    }
}
