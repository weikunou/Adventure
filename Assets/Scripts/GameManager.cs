using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏管理器类
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 单例
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// 是否使用虚拟摇杆
    /// </summary>
    public bool isUsingJoystick;

    /// <summary>
    /// 目标金币数
    /// </summary>
    public int targetCoins;

    /// <summary>
    /// 当前的金币数
    /// </summary>
    public int currentCoins;

    /// <summary>
    /// 门
    /// </summary>
    public GameObject door;

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
        CountCoins();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 计算金币数
    /// </summary>
    public void CountCoins()
    {
        targetCoins = GameObject.Find("Coins").transform.childCount;
    }

    /// <summary>
    /// 查找门
    /// </summary>
    /// <param name="obj">门</param>
    public void FindDoor(GameObject obj)
    {
        door = obj;
    }

    /// <summary>
    /// 显示门
    /// </summary>
    public void ShowDoor()
    {
        door.SetActive(true);
    }

    /// <summary>
    /// 游戏结束
    /// </summary>
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// 下一关
    /// </summary>
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
