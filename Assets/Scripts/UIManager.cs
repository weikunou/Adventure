using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 管理器类
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static UIManager instance;

    /// <summary>
    /// 金币数量文本
    /// </summary>
    public Text coinText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }


    void Update()
    {
        
    }

    /// <summary>
    /// 更新金币数量
    /// </summary>
    public void UpdateCoinText(int coin)
    {
        coinText.text = "金币：" + (coin + GameManager.instance.currentCoins);
    }
}
