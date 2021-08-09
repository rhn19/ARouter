using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField]
    public Text interactionText;

    private static readonly string databaseURL = $"https://not-a-router-default-rtdb.firebaseio.com/";
    public Text CurrentInstruction;
    public int index;
    Instruction steps = new Instruction();
    public int indi = 0;
    private GameObject Pointer_Power_Input;
    private GameObject Pointer_LAN_Ports;
    private GameObject Pointer_LED;
    private GameObject Pointer_Input_RJ;
    private GameObject Pointer_USB_Port;
    private GameObject Pointer_WPS;
    private GameObject Pointer_Reset_Button;


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
        //Debug.Log(steps.step1);
    }


    // Update is called once per frame
    void Update()
    {

        if (index == 1){
            CurrentInstruction.text = "" + steps.step1;
           
                try
                {

                    Pointer_LAN_Ports.SetActive(false);

                    Pointer_Input_RJ.SetActive(true);
                }

                catch (NullReferenceException e)
                {

                }
            

        }
        else if (index == 2)
            CurrentInstruction.text = "" + steps.step2;
        else if (index == 3)
            CurrentInstruction.text = "" + steps.step3;
        else if (index == 4)
            CurrentInstruction.text = "" + steps.step4;
        else
            CurrentInstruction.text = "" + steps.step5;
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Scenario 2")
        {
            if (indi == 0)
            {

                findOverlay();
            }
        }

    }

    public void speakInstruction()
    {
        interactionText.text = "Speaking...";
        StartCoroutine(ExampleCoroutine());
        voice.GetComponent<speechController>().StartSpeaking(CurrentInstruction.text);
    }

    public void OnRight()
    {
        if (index < 5)
        {
            index++;
            interactionText.text = "Next Instruction";
            StartCoroutine(ExampleCoroutine());
        }

        if (index == 1)
        {
            CurrentInstruction.text = "" + steps.step1;
            try
            {
                
                Pointer_LAN_Ports.SetActive(false);
                
                Pointer_Input_RJ.SetActive(true);
            }

            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 2)
        {
            CurrentInstruction.text = "" + steps.step2;
            try
            {
                
                Pointer_Input_RJ.SetActive(false);
                
                Pointer_Power_Input.SetActive(false);
                
                Pointer_LAN_Ports.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 3)
        {
            CurrentInstruction.text = "" + steps.step3;
            try
            {
                
                Pointer_LAN_Ports.SetActive(false);
                
                Pointer_Power_Input.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 4)
        {
            CurrentInstruction.text = "" + steps.step4;
            try
            {
                
                Pointer_Power_Input.SetActive(false);
                
                Pointer_LED.SetActive(false);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else
        {
            CurrentInstruction.text = "" + steps.step5;
            try
            {

                
                Pointer_LED.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
    }

    public void OnLeft()
    {
        if (index > 1)
        {
            index--;
            interactionText.text = "Previous Instruction";
            StartCoroutine(ExampleCoroutine());
        }   

        if (index == 1)
        {
            CurrentInstruction.text = "" + steps.step1;
            try
            {

                Pointer_LAN_Ports.SetActive(false);

                Pointer_Input_RJ.SetActive(true);
            }

            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 2)
        {
            CurrentInstruction.text = "" + steps.step2;
            try
            {

                Pointer_Input_RJ.SetActive(false);

                Pointer_Power_Input.SetActive(false);

                Pointer_LAN_Ports.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 3)
        {
            CurrentInstruction.text = "" + steps.step3;
            try
            {

                Pointer_LAN_Ports.SetActive(false);

                Pointer_Power_Input.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else if (index == 4)
        {
            CurrentInstruction.text = "" + steps.step4;
            try
            {

                Pointer_Power_Input.SetActive(false);

                Pointer_LED.SetActive(false);
            }
            catch (NullReferenceException e)
            {

            }

        }
        else
        {
            CurrentInstruction.text = "" + steps.step5;
            try
            {


                Pointer_LED.SetActive(true);
            }
            catch (NullReferenceException e)
            {

            }

        }
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

    public void loadScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void findOverlay()
    {
        try
        {
            Pointer_Power_Input = GameObject.Find("Pointer_Power_Input");
            Pointer_Power_Input.SetActive(false);
            Pointer_LAN_Ports = GameObject.Find("Pointer_LAN_Ports");
            Pointer_LAN_Ports.SetActive(false);
            Pointer_LED = GameObject.Find("Pointer_LED");
            Pointer_LED.SetActive(false);
            Pointer_Input_RJ = GameObject.Find("Pointer_Input_RJ-11");
            Pointer_Input_RJ.SetActive(false);
            Pointer_USB_Port = GameObject.Find("Pointer_USB_Port");
            Pointer_USB_Port.SetActive(false);
            Pointer_WPS = GameObject.Find("Pointer_WPS/WIFI_Button");
            Pointer_WPS.SetActive(false);
            Pointer_Reset_Button = GameObject.Find("Pointer_Reset_Button");
            Pointer_Reset_Button.SetActive(false);
            indi = 1;
        }
        catch (NullReferenceException e)
        {
            indi = 0;
        }
    

    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        interactionText.text = "";
    }

}
