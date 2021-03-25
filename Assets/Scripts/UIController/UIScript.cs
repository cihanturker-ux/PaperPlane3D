using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Image _tapToLaunchPanel;
    public Image _gameOverPanel;
    public Text _coinText;
    public Text _meterText;
    public Text _gainedCoinText;
    public static UIScript instance;
    private void Awake()
    {
        instance = this;
    }
    public void OnClickGamaOverButton()
    {
        //game over panelinde ki butona basýnca oyun resetleniyor.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
