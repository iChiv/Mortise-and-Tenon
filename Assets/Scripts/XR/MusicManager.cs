using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            // 销毁新场景中重复的音乐播放器实例
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // 防止在加载新场景时销毁背景音乐播放器
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // 可以添加更多控制背景音乐的方法，如播放、暂停等
}
