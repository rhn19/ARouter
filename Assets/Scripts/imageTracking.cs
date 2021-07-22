using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class imageTracking : MonoBehaviour
{
    private ARTrackedImageManager aRTrackedImageManager;
    private TextMeshProUGUI text;
    

    private void Awake() {
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        text = FindObjectOfType<TextMeshProUGUI>();
    }

    private void OnEnable() {
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable() {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs){
        foreach (ARTrackedImage trackedImage in eventArgs.added){
           UpdateImage(trackedImage); 
        }
        foreach (ARTrackedImage trackedImage in eventArgs.updated){
           UpdateImage(trackedImage); 
        }
        foreach (ARTrackedImage trackedImage in eventArgs.removed){
            text.text = "Scan the Router";
        }

    }

    private void UpdateImage(ARTrackedImage trackedImage){
    
        if ( trackedImage.referenceImage.name == "router-front"){
           text.text = "Front"; 
        }

        else if (trackedImage.referenceImage.name == "router-side"){
           text.text = "Side"; 
        }
        else{
            text.text = "Back";
        }
    }
}
