using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject speakButton;

    [SerializeField]
    public GameObject feedbackButton;

    [SerializeField]
    public GameObject writtenFeedbackButton;

    [SerializeField]
    public GameObject logo;

    [SerializeField]
    public GameObject quitButton;

    [SerializeField]
    public GameObject manualButton;

    [SerializeField]
    public GameObject setupButton;

    [SerializeField]
    public GameObject prevButton;

    [SerializeField]
    public GameObject nextButton;

    [SerializeField]
    public GameObject instructionText;

    // Start is called before the first frame update
    void Start()
    {
        logo.transform.position = new Vector2(Screen.width/2, Screen.height - 90f);
        quitButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 90f);
        manualButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 210f);
        setupButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 330f);

        instructionText.transform.position = new Vector2(Screen.width / 2, Screen.height - 300f);
        nextButton.transform.position = new Vector2(Screen.width / 2 + 400f, Screen.height - 300f);
        prevButton.transform.position = new Vector2(Screen.width / 2 - 400f, Screen.height - 300f);
        speakButton.transform.position = new Vector2(Screen.width - 90f, 90f);

        feedbackButton.transform.position = new Vector2(90f, Screen.height - 90f);
        writtenFeedbackButton.transform.position = new Vector2(90f, Screen.height - 210f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
