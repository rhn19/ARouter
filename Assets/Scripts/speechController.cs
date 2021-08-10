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

    GameObject next, prev, man, help, exit;


    private void Start() {
        //scriptManager = GameObject.Find("ScriptManager");
        next = GameObject.Find("NextButton");
        prev = GameObject.Find("PrevButton");
        man = GameObject.Find("ManualButton");
        help = GameObject.Find("HelpButton");
        exit = GameObject.Find("QuitButton");
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
        UiText.text = "Listening...";
    }
    public void StopListening(){
        SpeechToText.instance.StopRecording();
        UiText.text = "";
    }

    void OnFinalSpeechResult(string result){
        //UiText.text = result;
        if (result.Contains("next")){
            //scriptManager.GetComponent<Instructions>().OnRight();
            next.GetComponent<Button>().onClick.Invoke();
        }
        else if (result.Contains("previous")){
            //scriptManager.GetComponent<Instructions>().OnLeft();
            prev.GetComponent<Button>().onClick.Invoke();
        }
        else if (result.Contains("manual")){
            //scriptManager.GetComponent<Instructions>().OnLeft();
            man.GetComponent<Button>().onClick.Invoke();
        }
        else if (result.Contains("help")){
            //scriptManager.GetComponent<Instructions>().OnLeft();
            help.GetComponent<Button>().onClick.Invoke();
        }
        else if (result.Contains("exit") || result.Contains("quit")){
            //scriptManager.GetComponent<Instructions>().OnLeft();
            exit.GetComponent<Button>().onClick.Invoke();
        }
        

        //UiText.text = "Listening..";
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
