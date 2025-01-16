using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Evereal.VRVideoPlayer;

public class ControlVideoPlayerUIVideoPlay : MonoBehaviour
{
    public VRVideoPlayer videoPlayer;
    public Slider slider;
    public ControlVideo controlVideo;

    [SerializeField]
    private TogglePlayPause togglePlayPause;

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = (float)videoPlayer.length;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = (float)videoPlayer.length;

        if (videoPlayer.isPlaying)
        {
            slider.value = (float)videoPlayer.time;

            if ((slider.maxValue - slider.value) <= 0.5f)
            {
                controlVideo.BackVideo360();
            }
        }
    }
    public void onchangeSliderTimelineVideo(float timeVideo)
    {
        //if (videoPlayer.time != timeVideo)
        //{
        //    videoPlayer.time = timeVideo;
        //    videoPlayer.Play();
        //}
    }

    public void SelectSlider()
    {
        togglePlayPause.checkPlayVideo_Local(false);
    }

    public void DeSelect()
    {
        StartCoroutine(PlayVideoAgain());
    }

    IEnumerator PlayVideoAgain()
    {
        videoPlayer.time = slider.value;
        yield return new WaitForSeconds(0.5f);
        togglePlayPause.checkPlayVideo_Local(true);
    }
}
