using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class FirstLoad : MonoBehaviour
{
    public SceneSO persis; 
    private void Awake()
    {
        persis.scene.LoadSceneAsync(LoadSceneMode.Additive);
        
    }
}
