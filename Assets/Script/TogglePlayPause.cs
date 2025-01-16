using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Evereal.VRVideoPlayer;

public class TogglePlayPause : MonoBehaviour
{

    private bool isPause;
    public VRVideoPlayer videoPlayer;
    public RawImage targetTexture;
    public Texture play, pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePlay()
    {
        isPause = !isPause;
        if (isPause)
        {
            targetTexture.texture = pause;
            videoPlayer.Play();
        }
        else
        {
            targetTexture.texture = play;
            videoPlayer.Pause();
        }
    }

    private void OnEnable()
    {
        isPause = true;
    }

    public void checkPlayVideo_Local(bool isPause)
    {
        if (isPause)
        {
            targetTexture.texture = pause;
            videoPlayer.Play();
        }
        else
        {
            targetTexture.texture = play;
            videoPlayer.Pause();
        }
        //public void CloseVideo()
        //{
        //    if (photonview != null)
        //        photonview.RPC("StopVideoRPC", RpcTarget.Others); //Set color
        //}
        //[PunRPC]
        //public void StopVideoRPC()
        //{
        //    Transform videoGallery = transform.parent;
        //    Transform lstButtonAndText = videoGallery.Find("ListButtonAndText");
        //    lstButtonAndText.gameObject.SetActive(true);
        //    gameObject.SetActive(false);

        //}

    }
}
