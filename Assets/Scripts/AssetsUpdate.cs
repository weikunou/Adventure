using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// 资源更新类
/// </summary>
public class AssetsUpdate : MonoBehaviour
{
    public string path = "";

    public Transform coins;

    void Start()
    {
        StartCoroutine(UpdatePrefab());
    }

    void Update()
    {
        
    }

    IEnumerator UpdatePrefab()
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path);

        yield return request.SendWebRequest();

        if(request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("下载成功");
        }

        AssetBundle ab = DownloadHandlerAssetBundle.GetContent(request);

        Sprite sprite = ab.LoadAsset<Sprite>("coin");

        foreach(Transform child in coins)
        {
            child.GetComponent<SpriteRenderer>().sprite = sprite;
        }

        ab.Unload(false);
    }
}
