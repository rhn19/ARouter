using Proyecto26;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackHandler : MonoBehaviour
{
    public InputField feedbackText;

    [Serializable]
    public class Rating
    {
        public int rating;
        public string timestamp;
    }

    public class Feedback
    {
        public string description;
        public string timestamp;
    }

    [SerializeField]
    public GameObject submitButton;

    [SerializeField]
    public GameObject feedbackPanel;

    [SerializeField]
    public GameObject writtenFeedbackPanel;

    [SerializeField]
    public GameObject feedbackButton;

    [SerializeField]
    public GameObject writtenFeedbackButton;


    private static readonly string databaseURL = $"https://not-a-router-default-rtdb.firebaseio.com/";

    // Use this for initialization
    void Start()
    {
        feedbackPanel.SetActive(false);
        writtenFeedbackPanel.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeFeedback()
    {
        Debug.Log("Feedback");
        if (feedbackPanel != null)
        {
            bool isActive = feedbackPanel.activeSelf;
            feedbackPanel.SetActive(!isActive);
            writtenFeedbackButton.SetActive(isActive);
        }
    }

    public void TakeWrittenFeedback()
    {
        
        Debug.Log("Written Feedback");
        if (feedbackPanel != null)
        {
            bool isActive = writtenFeedbackPanel.activeSelf;
            writtenFeedbackPanel.SetActive(!isActive);
            //feedbackButton.SetActive(isActive);
        }

    }

    public void SubmitWrittenFeedback()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Feedback feedback = new Feedback();
        feedback.description = feedbackText.text;
        feedback.timestamp = date;

        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}writtenFeedback.json", feedback).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Posted Written Feedback");
        submitButton.SetActive(false);
        feedbackText.GetComponent<InputField>().readOnly = true;
    }

    public void TakeFeedbackRating5()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Rating rate = new Rating();
        rate.rating = 5;
        rate.timestamp = date;
        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}feedback.json", rate).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Great!");
        feedbackPanel.SetActive(false);
        writtenFeedbackButton.SetActive(true);
        feedbackButton.GetComponent<Button>().interactable = false;
    }

    public void TakeFeedbackRating4()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Rating rate = new Rating();
        rate.rating = 4;
        rate.timestamp = date;
        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}feedback.json", rate).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Good!");
        feedbackPanel.SetActive(false);
        writtenFeedbackButton.SetActive(true);
        feedbackButton.GetComponent<Button>().interactable = false;
    }

    public void TakeFeedbackRating3()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Rating rate = new Rating();
        rate.rating = 3;
        rate.timestamp = date;
        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}feedback.json", rate).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Okay");
        feedbackPanel.SetActive(false);
        writtenFeedbackButton.SetActive(true);
        feedbackButton.GetComponent<Button>().interactable = false;
    }

    public void TakeFeedbackRating2()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Rating rate = new Rating();
        rate.rating = 2;
        rate.timestamp = date;
        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}feedback.json", rate).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Can be Better");
        feedbackPanel.SetActive(false);
        writtenFeedbackButton.SetActive(true);
        feedbackButton.GetComponent<Button>().interactable = false;
    }

    public void TakeFeedbackRating1()
    {
        DateTime dt = DateTime.Now;
        String date;
        date = dt.ToString("r", DateTimeFormatInfo.InvariantInfo);

        Rating rate = new Rating();
        rate.rating = 1;
        rate.timestamp = date;
        //Debug.Log(rate.timestamp);
        RestClient.Post<Rating>($"{databaseURL}feedback.json", rate).Then(response => { Debug.Log("Posted"); });

        Debug.Log("Can be More Better");
        feedbackPanel.SetActive(false);
        writtenFeedbackButton.SetActive(true);
        feedbackButton.GetComponent<Button>().interactable = false;
    }
}
