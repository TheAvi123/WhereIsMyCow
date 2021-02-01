using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static DialogueUIManager Instance;
    private string[] mLatestClues = new string[10];
    private int latestClueCount = 10;

    [SerializeField]
    private string mInitialClue;
    [SerializeField] private Text cluesText;
    [SerializeField]
    private Text dialogText;
    [SerializeField]
    private GameObject dialogTextObject;

    private Coroutine mDialogCoroutine = null;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < latestClueCount; i++)
        {
            mLatestClues[i] = "";
        }

        UpdateLatestClues(mInitialClue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartPlayDialog(2f, "test dialog");
        }
    }

    public void UpdateLatestClues(string latest)
    {
        //don't update if its the same as most recent
        if (latest != mLatestClues[latestClueCount - 1])
        {
            for (int i = 0; i < (latestClueCount - 1); i++)
            {
                mLatestClues[i] = mLatestClues[i + 1];
            }
            mLatestClues[latestClueCount - 1] = latest;
            UpdateLatestCluesUI();
        }
        
    }


    public void UpdateLatestCluesUI()
    {
        string latestCluesText = "";
        for (int i = 0; i < latestClueCount; i++)
        {
            if (mLatestClues[i] != "")
            {
                latestCluesText += mLatestClues[i] + "\n";
            }
        }
        cluesText.text = latestCluesText;
    }

    public void StartPlayDialog(float seconds, string text)
    {
        if (mDialogCoroutine != null)
        {
            StopCoroutine(mDialogCoroutine);
        }
        mDialogCoroutine = StartCoroutine(PlayDialog(seconds, text));
    }

    public IEnumerator PlayDialog(float seconds, string text)
    {
        dialogText.text = text;
        dialogTextObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        dialogTextObject.SetActive(false);
    }
}
