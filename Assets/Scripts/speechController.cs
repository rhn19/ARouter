using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using UnityEngine.UI;

public class speechController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    [SerializeField]
    Text UiText;

    private void Start() {
        Setup(LANG_CODE);
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
    #if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
    #endif
        CheckPermission();
    }

    void CheckPermission(){
    #if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
           Permission.RequestUserPermission(Permission.Microphone);
        }
    #endif
       
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
    
    #endregion

    #region Speech To Text

    public void StartListening(){
        SpeechToText.instance.StartRecording();
    }
    public void StopListening(){
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result){
        UiText.text = result;
    }
    void OnPartialSpeechResult(string result){
        UiText.text = result;
    }
    #endregion

    void Setup (string code){
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);

    }

}