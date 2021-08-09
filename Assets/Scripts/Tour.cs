using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tour : MonoBehaviour
{
    [SerializeField]
    public GameObject tourPanel;

    public Text headingText;
    public Text quitText;
    public Text readText;
    public Text setupText;
    public Text listenText;
    public Text speakText;
    public Text interactionPanelText;
    public Text f1Text;
    public Text f2Text;
    public Text takeTourText;
    public Text nextText;
    public Text prevText;

    // Start is called before the first frame update
    void Start()
    {
        tourPanel.SetActive(false);
        //aboutUsText.gameObject.SetActive(false);
        //quitText.gameObject.SetActive(false);
        //readText.gameObject.SetActive(false);
        //setupText.SetActive(false);
        //listenText.SetActive(false);
        //f1Text.SetActive(false);
        //f2Text.SetActive(false);
        //takeTourText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeTour()
    {
        //Debug.Log("Tour");
        if (tourPanel != null)
        {
            bool isActive = tourPanel.activeSelf;
            tourPanel.SetActive(!isActive);

        }

        headingText.transform.position = new Vector2(Screen.width / 2, Screen.height/2);

        quitText.transform.position = new Vector2(Screen.width - 210f, Screen.height - 90f);
        readText.transform.position = new Vector2(Screen.width - 210f, Screen.height - 210f);
        setupText.transform.position = new Vector2(Screen.width - 210f, Screen.height - 330f);

        f1Text.transform.position = new Vector2(220f, Screen.height - 90f);
        f2Text.transform.position = new Vector2(220f, Screen.height - 210f);
        takeTourText.transform.position = new Vector2(220f, Screen.height - 330f);

        listenText.transform.position = new Vector2(Screen.width - 240f, 210f);
        speakText.transform.position = new Vector2(Screen.width - 240f, 90f);

        interactionPanelText.transform.position = new Vector2(Screen.width / 2, 175f);

        nextText.transform.position = new Vector2(Screen.width / 2 + 400f, Screen.height - 700f);
        prevText.transform.position = new Vector2(Screen.width / 2 - 400f, Screen.height - 700f);
    }

    

    //void Delay(GameObject obj)
    //{
    //    StartCoroutine(ExampleCoroutine());
    //    obj.SetActive(false);
    //}

    IEnumerator ExampleCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        obj.SetActive(false);
    }

}
