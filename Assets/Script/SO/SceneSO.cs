using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
[CreateAssetMenu(menuName ="SceneSO")]
public class SceneSO : ScriptableObject
{
    public SceneType sceneType;
    public AssetReference scene;

}
