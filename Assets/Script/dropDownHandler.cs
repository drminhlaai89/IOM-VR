using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using Evereal.VRVideoPlayer;
using System;
using System.Linq;

[Serializable]
public class VideoData
{
    public string videoName;
    public int watchPlayTime;
}

[Serializable]
public class VideoList
{
    public List<VideoData> videos;
}

public class dropDownHandler : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public string devicePath = "";
    public VRVideoPlayer player;

    public List<VideoData> videosData = new List<VideoData>();

    public TMP_Dropdown dropDown;
    public GameObject infoImage;

    public GameObject gazeDisable;

    // Start is called before the first frame update
    void Start()
    {
        dropDown = transform.GetComponent<TMP_Dropdown>();

        dropDown.options.Clear();

        //This will get all the files in device Path
        string[] files = Directory.GetFiles(devicePath)
             .Where(file => file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
             .ToArray();

        //List<string> items = new List<string>();
        //items.Add("Item 1");
        //items.Add("Item 2");



        //Fill dropdown with items  
        foreach (var file in files)
        {
            // Check if the file has a .mp4 extension
            //if (Path.GetExtension(file).Equals(".mp4", StringComparison.OrdinalIgnoreCase))
            //{
            string fileName = Path.GetFileName(file);
            dropDown.options.Add(new TMP_Dropdown.OptionData() { text = fileName });


            videosData.Add(new VideoData { videoName = fileName, watchPlayTime = 0 });
            //}

        }

        if (checkVideosData())
        {
            LoadAllVideosData(videosData);
        }
        SaveAllVideosData();



        dropDownSelected();
    }

    private void Update()
    {
        if (dropDown.IsExpanded)
        {
            infoImage.SetActive(false);
           
        }
        else
        {
            infoImage.SetActive(true);
            
        }
    }

    public void SaveAllVideosData()
    {
        VideoList videosList = new VideoList { videos = videosData };
        string jsonData = JsonUtility.ToJson(videosList);
        PlayerPrefs.SetString("allVideosDataKey", jsonData);
        PlayerPrefs.Save();
    }

    void LoadAllVideosData(List<VideoData> _videosData)
    {
        string jsonData = PlayerPrefs.GetString("allVideosDataKey", "{}");
        VideoList videosList = JsonUtility.FromJson<VideoList>(jsonData);

        foreach (var video in videosList.videos)
        {
            if (checkVideoExsist(video) != null)
            {
                checkVideoExsist(video).watchPlayTime = video.watchPlayTime;
            }
        }
    }

    bool checkVideosData()
    {
        string jsonData = PlayerPrefs.GetString("allVideosDataKey", "{}");
        VideoList videosList = JsonUtility.FromJson<VideoList>(jsonData);

        if (videosList.videos.Count > 0)
        {
            return true;
        }
        return false;
    }

    VideoData checkVideoExsist(VideoData _video)
    {
        foreach (var videoData in videosData)
        {
            if (videoData.videoName == _video.videoName)
            {
                return videoData;
            }
        }
        return null;
    }

    public void dropDownSelected()
    {


        int index = dropDown.value;

        //player.gameObject.SetActive(false);
        player.videoUrl = Path.Combine(devicePath, dropDown.options[index].text);
        //player.Load(player.url, player.autoPlay);
        //StartCoroutine(loadVideo());

        foreach (var videoData in videosData)
        {
            if (videoData.videoName == dropDown.options[index].text)
            {
                textMeshProUGUI.text = videoData.watchPlayTime.ToString();
            }
        }
        dropDown.RefreshShownValue();

    }

    //IEnumerator loadVideo()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    player.gameObject.SetActive(true);

    //    player.Load(player.url, player.autoPlay);
    //}
}
