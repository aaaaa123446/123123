using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class UIManger : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public PointManger pointManger;
    public GameObject diePanel;
    public PlayerTypeEventSO startEvent1;
    public PlayerTypeEventSO startEvent2;
    public PlayerTypeEventSO backToMenu;
    public GameObject setButton;
    public GameObject setPanel;
    public Image headImage;
    public Image healthImage;
    public Sprite player1;
    public Sprite player2;
    public float playerMaxHealth;
    public float playerCurrentHealth;
    [SerializeField]
    private string playerName;
    public StringEventSO nameEvent;
    public GameObject playerUI;
    public FloatEventSO OnVolumChangeEvent;
    public AudioMixer mixer;
    public Slider slider;
    public Image sceneLoadPanel;
    public FloatEventSO loadSceneEvent;
    private void OnEnable()
    {
        loadSceneEvent.OnEventRaised += SceneLoad;
        nameEvent.OnEventRaised += GetName;
        backToMenu.OnEventRaised += ButtonDisappear;
        startEvent1.OnEventRaised += ButtonAppear;
        startEvent2.OnEventRaised += ButtonAppear;
        OnVolumChangeEvent.OnEventRaised += OnVolumeChange;
        backToMenu.OnEventRaised += BackToMenu;
    }

    private void OnDisable()
    {
        loadSceneEvent.OnEventRaised -= SceneLoad;
        OnVolumChangeEvent.OnEventRaised -= OnVolumeChange;
        nameEvent.OnEventRaised -= GetName;
        backToMenu.OnEventRaised -= ButtonDisappear;
        startEvent1.OnEventRaised -= ButtonAppear;
        startEvent2.OnEventRaised -= ButtonAppear;
        backToMenu.OnEventRaised -= BackToMenu;
    }
    private void Update()
    {
        if (healthImage.fillAmount > playerCurrentHealth / playerMaxHealth)
        {
            if (healthImage.fillAmount - Time.deltaTime < playerCurrentHealth / playerMaxHealth)
                healthImage.fillAmount = playerCurrentHealth / playerMaxHealth;
            else
                healthImage.fillAmount -= Time.deltaTime;
        }
        else if (healthImage.fillAmount < playerCurrentHealth / playerMaxHealth)
        {
            if(healthImage.fillAmount+Time.deltaTime> playerCurrentHealth / playerMaxHealth)
                healthImage.fillAmount = playerCurrentHealth / playerMaxHealth;
            else
                healthImage.fillAmount += Time.deltaTime;
        }
    }
    public void BackToMenu()
    {
        playerName = "";
    }
    public  void SetHead(PlayerType playerType)
    {
        switch (playerType)
        {
            case PlayerType.player1:
                headImage.sprite = player1;break;
            case PlayerType.player2:
                headImage.sprite = player2;break;
            default:
                break;
        }
        if (playerName == "") playerName = "无名氏";
        playerUI.SetActive(true);
    }
    public void OnHealthyChange(float health)
    {
        playerCurrentHealth = health;
    }
    public void GetName(string name)
    {
        playerName = name;
    }
    public void OpenSetPanel()
    {
       
        setPanel.SetActive(true); 
        Time.timeScale = 0;
    }
    public void ClosesSetPanel()
    {
        Time.timeScale = 1;
        diePanel.SetActive(false);
        setPanel.SetActive(false);
    }
    public void OpenDiePanel()
    {
        if(pointManger.point>=30)
        {
            gameOverText.text = "太棒了不愧是练习时长两年半的"+playerName;
        }
        else if(pointManger.point==29)
        {
            gameOverText.text = "继续加油坚持练习两年半" ;
        }
        else 
        {
            gameOverText.text = "就这，练两分半也能得"+ (pointManger.point+1)+"分啊";
        }
        diePanel.SetActive(true);
        Time.timeScale= 0;
    }
    public void ButtonDisappear()
    { 
        setButton.SetActive(false);
        playerUI.SetActive(false);
       
           
       
    }
    public void ButtonAppear()
    {
        float volume;
        mixer.GetFloat("Master", out volume);
        slider.value = (volume + 80) / 100;
        setButton.SetActive(true);
    }
    public void OnVolumeChange(float volume)
    {
        mixer.SetFloat("Master",volume*100-80);
    }
    public void SceneLoad(float num)
    {
        if(num==0)
        {
            sceneLoadPanel.DOBlendableColor(Color.black,0.5f);
        }
        else
        {
            sceneLoadPanel.DOBlendableColor(Color.clear, 0.5f);
        }
    }
}
