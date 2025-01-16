using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class timeEvent : MonoBehaviour
{
    public Image percentageImage;
    public float totalTime = 3.0f; // Total time for the timer in seconds.

    private float currentTime = 0.0f;
    private float currentPercentage = 0.0f;

    [SerializeField] bool isHover = false;
    ControlVideo controlVideo;

    GameObject interactorName;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        UpdatePercentage();
        controlVideo = GameObject.FindObjectOfType<ControlVideo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHover)
        {
            // Increment the timer.
            currentTime += Time.deltaTime;

            // Calculate the current percentage.
            currentPercentage = Mathf.Clamp01(currentTime / totalTime);

            // Update the percentage display.
            UpdatePercentage();

            // Check if the timer has reached the total time.
            if (currentTime >= totalTime)
            {
                // Timer has reached its end. You can perform additional actions here if needed.
                controlVideo.PlayVideo360();
            }


        }
        else
        {
            ResetState();
        }

    }
    public void OnHoverEntered(HoverEnterEventArgs args)
    {

        interactorName = args.interactorObject.transform.gameObject;

        if (args.interactorObject.transform.CompareTag("gaze"))
        {
            isHover = true;
        }
        else
        {
            Button button = GetComponent<Button>();
            button.interactable = true;
        }

    }

    public void OnHoverExited(HoverExitEventArgs args)
    {

        if (interactorName.CompareTag(args.interactorObject.transform.tag))
        {
            if (interactorName.CompareTag("gaze"))
            {
                isHover = false;
            }
            else
            {
                Button button = GetComponent<Button>();
                button.interactable = false;
            }    
        }
    }

    //public void HoverChange(bool _isHover)
    //{
    //    //When first hover. It will make the _Ishover true. Making isHover true.
    //    isHover = _isHover;
    //}


    public void ResetState()
    {
        currentTime = 0.0f;
        currentPercentage = 0.0f;
        isHover = false;
        UpdatePercentage();
    }

    private void UpdatePercentage()
    {
        // Update the UI text to display the current percentage.
        percentageImage.fillAmount = currentPercentage;
    }
}
