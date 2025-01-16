using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class checkXRRay : MonoBehaviour
{
    [SerializeField] private XRBaseInteractor interactor;

    [SerializeField] timeEvent timeEvent;
    [SerializeField] ControlVideo controlVideo;
    [SerializeField] XRGazeInteractor gazeInteractor;

    [SerializeField] bool isHit = false;
    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the XR Ray Interactor on this GameObject.
        interactor = GetComponent<XRBaseInteractor>();

        // Subscribe to the OnSelectEnter and OnSelectExit events.
        //interactor.selectEntered.AddListener(OnRaycastHit);
        //interactor.selectExited.AddListener(OnRaycastExit);

        timeEvent = GameObject.FindObjectOfType<timeEvent>();
        controlVideo = GameObject.FindObjectOfType<ControlVideo>();
        gazeInteractor = GameObject.FindObjectOfType<XRGazeInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit)
        {
            timeEvent.enabled = false;
            controlVideo.PlayVideo360();
            gazeInteractor.enabled = false;
        }
        else
        {
            timeEvent.enabled = true;
            gazeInteractor.enabled = true;
        }
            
    }

    //private void OnRaycastHit(SelectEnterEventArgs args)
    //{
    //    // Handle the ray hit event.
    //    Debug.Log("Ray hit a collider: " + args.interactableObject);
     

    public void hitCollider(bool _isHit)
    {
        isHit = _isHit;
    }
        
    //}

    //private void OnRaycastExit(SelectExitEventArgs args)
    //{
    //    // Handle the ray exit event.
    //    Debug.Log("Ray exited the collider: " + args.interactableObject);
    //}
}
