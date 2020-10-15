using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
