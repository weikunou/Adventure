using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 门类
/// </summary>
public class Door : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.FindDoor(gameObject);

        gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
}
