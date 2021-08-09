using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject listenButton;

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
    public GameObject helpButton;

    [SerializeField]
    public GameObject prevButton;

    [SerializeField]
    public GameObject nextButton;

    [SerializeField]
    public GameObject instructionText;

    [SerializeField]
    public GameObject interactionPanel;

    [SerializeField]
    public Text interactionText;

    // Start is called before the first frame update
    void Start()
    {
        logo.transform.position = new Vector2(Screen.width/2, Screen.height - 90f);
        quitButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 90f);
        manualButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 210f);
        setupButton.transform.position = new Vector2(Screen.width - 90f, Screen.height - 330f);

        instructionText.transform.position = new Vector2(Screen.width / 2, Screen.height - 600f);
        nextButton.transform.position = new Vector2(Screen.width / 2 + 400f, Screen.height - 600f);
        prevButton.transform.position = new Vector2(Screen.width / 2 - 400f, Screen.height - 600f);
        listenButton.transform.position = new Vector2(Screen.width - 90f, 210f);
        speakButton.transform.position = new Vector2(Screen.width - 90f, 90f);

        feedbackButton.transform.position = new Vector2(90f, Screen.height - 90f);
        writtenFeedbackButton.transform.position = new Vector2(90f, Screen.height - 210f);
        helpButton.transform.position = new Vector2(90f, Screen.height - 330f);

        interactionPanel.transform.position = new Vector2(Screen.width/2, 90f);
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        interactionText.text = "";
    }
}
