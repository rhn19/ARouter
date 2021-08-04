using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;

public class speechController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    private void Start() {
        Setup(LANG_CODE);
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
    }

    

    #region Text To Speech
    
    public void StartSpeaking(string message){
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking(){
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart(){
        Debug.Log("Talking Started...");
    }

    void OnSpeakStop(){
        Debug.Log("Talking Stopped...");
    }

    void Setup (string code){
        TextToSpeech.instance.Setting(code, 1, 1);
    }

    #endregion
}