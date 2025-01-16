using Evereal.VRVideoPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterface : MonoBehaviour
{
    private IMediaPlayer mediaPlayer = new UnityMediaPlayer();

    event FirstFrameReadyEvent firtfame = delegate { Debug.Log("FirstFrame"); };
    // Start is called before the first frame update
    void Start()
    {
        mediaPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
