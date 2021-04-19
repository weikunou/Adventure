using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 相机跟随类
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// 跟随目标
    /// </summary>
    public Transform target;

    /// <summary>
    /// 偏移
    /// </summary>
    Vector3 offset;

    void Start()
    {
        // 计算偏移
        offset = transform.position - target.position;
    }


    void Update()
    {

    }

    // 放在 LateUpdate 里可以解决画面抖动
    void LateUpdate()
    {
        // 更新相机位置
        transform.position = target.position + offset;
    }
}
