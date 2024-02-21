using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public PlayerTypeEventSO toMap2Event;
    public GameObject player1;
    public GameObject player2;
    public GameObject player;
    private bool isLoading;
    [SerializeField]
    private AssetReference currentScene;
    public PlayerTypeEventSO startEvent1;
    public PlayerTypeEventSO startEvent2;
    public SceneSO MenuSO;
    public SceneSO firstScene;
    public Vector3 firstPosition;
    public SceneSO secondScene;
    public Vector3 secondPosition;
    public PlayerTypeEventSO BackToMenuEvent;
    public FloatEventSO loadSceneEvent;
    private void Awake()
    {
        OnBegin();
    }
    private void OnEnable()
    {
        startEvent1.OnEventRaised += Start1;
        startEvent2.OnEventRaised += Start2;
        toMap2Event.OnEventRaised += ToMap2Event;
    }
    private void OnDisable()
    {
        startEvent1.OnEventRaised -= Start1;
        startEvent2.OnEventRaised -= Start2;
        toMap2Event.OnEventRaised -= ToMap2Event;
    }
    public void ToMap2Event()
    {
        LoadScene(secondScene,secondPosition);
    }
    public void BackToMenu()
    {
       
        LoadScene(MenuSO, firstPosition); 
        player.SetActive(false);
    }
    public void OnBegin()
    {
        MenuSO.scene.LoadSceneAsync(LoadSceneMode.Additive);
        currentScene = MenuSO.scene;
    }
    public void Start1()
    {
        player = player1;
        LoadScene(firstScene,firstPosition);
    }
    public void Start2()
    {
        player = player2;
        LoadScene(firstScene, firstPosition);
    }
    public void LoadScene(SceneSO sceneSO,Vector3 positionToGo)
    {
        if (isLoading) return;
        isLoading = true;
        StartCoroutine(ILoadScene(sceneSO,positionToGo));
        
    }
    IEnumerator ILoadScene(SceneSO sceneSO, Vector3 positionToGo)
    {
        player.GetComponent<PlayerControler>().enabled = false;
        loadSceneEvent.OnEventRaised(0);
        yield return new WaitForSeconds(0.5f);
        if (currentScene != null)
            yield return currentScene.UnLoadScene();
        var sceneLoad= sceneSO.scene.LoadSceneAsync(LoadSceneMode.Additive,true);
        currentScene = sceneSO.scene;
        sceneLoad.Completed += AfterSceneLoad;
        player.transform.position = positionToGo;
        loadSceneEvent.OnEventRaised(1);
        yield return new WaitForSeconds(0.5f);
    }
    private void AfterSceneLoad(AsyncOperationHandle<SceneInstance> handle)
    {
        player.GetComponent<PlayerControler>().enabled = true;
        isLoading= false;
    }
}
