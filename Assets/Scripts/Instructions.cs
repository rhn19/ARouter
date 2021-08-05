using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    private static readonly string databaseURL = $"https://not-a-router-default-rtdb.firebaseio.com/";
    public Text CurrentInstruction;
    public int index;
    Instruction steps = new Instruction();

    private GameObject voice;

    // Use this for initialization
    void Start()
    {
        voice = GameObject.Find("VoiceController");
        index++;
        RestClient.Get<Instruction>($"{databaseURL}instructions.json").Then(response =>
        {
            steps = response;
            //Debug.Log(steps.step1);
            //prevscore = user2.userScore;
            //PastScore.gameObject.SetActive(true);
            //StartCoroutine("WaitUnhide");
            //PastScore.text = "" + user.userScore;
        });

        CurrentInstruction.text = "" + steps.step1;
        Debug.Log(steps.step1);
    }


    // Update is called once per frame
    void Update()
    {
        if (index == 1)
            CurrentInstruction.text = "" + steps.step1;
        else if(index == 2)
            CurrentInstruction.text = "" + steps.step2;
        else if (index == 3)
            CurrentInstruction.text = "" + steps.step3;
        else if (index == 4)
            CurrentInstruction.text = "" + steps.step4;
        else
            CurrentInstruction.text = "" + steps.step5;

        voice.GetComponent<speechController>().StartSpeaking(CurrentInstruction.text);
    }


    public void OnRight()
    {
        if (index < 5)
            index++;
    }

    public void OnLeft()
    {
        if (index > 1)
            index--;
    }


    public void QuitApp()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void openUrl()
    {
        Application.OpenURL("https://drive.google.com/file/d/1vjjeUIOCqCP2luLykEm2y4qBqtZhqSdn/view?usp=sharing");
    }

}
