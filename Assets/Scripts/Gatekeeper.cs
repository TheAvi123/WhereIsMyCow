using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatekeeper : MonoBehaviour
{
    // Start is called before the first frame update
    private CowType mChosenCowType;
    private DialogueResponse mCorrectCowDialog = new DialogueResponse(3f,"Gatekeeper: My cow! You found my cow!", "");
    private DialogueResponse mDefaultCowDialog = new DialogueResponse(3f, "Gatekeeper: You blind? That's not my cow!", "Keep looking");
    private DialogueResponse mNotBrownDialog = new DialogueResponse(3f, "Gatekeeper: Nooo! My cow's not brown!","Gatekeeper's cow isn't brown");
    private DialogueResponse mNotBlackDialog = new DialogueResponse(3f, "Gatekeeper: My cow's not black! Find me my cow!", "Gatekeeper's cow isn't black");
    private DialogueResponse mNotWhiteDialog = new DialogueResponse(3f, "Gatekeeper: My cow's not white! Gimme my cow!", "Gatekeeper's cow isn't white");
    private DialogueResponse mNotGreenDialog = new DialogueResponse(3f, "Gatekeeper: Green!? My cow's not green!", "Gatekeeper's cow isn't green");
    private DialogueResponse mNotGoldDialog = new DialogueResponse(3f, "Gatekeeper: My cow's not gold! Where's my cow!?", "Gatekeeper's cow isn't gold");
    private DialogueResponse mTooSmallDialog = new DialogueResponse(3f, "Gatekeeper: Too small! That's not my cow!", "Gatekeeper's cow is bigger");
    private DialogueResponse mTooBigDialog = new DialogueResponse(3f, "Gatekeeper: Too big! My cow's small!", "Gatekeeper's cow is smaller");
    private DialogueResponse mTooSoftDialog = new DialogueResponse(3f, "Gatekeeper: That's not my cow! Too soft!", "Gatekeeper's cow isn't soft");
    private DialogueResponse mNotSoftDialog = new DialogueResponse(3f, "Gatekeeper: Too hard! My cow's soft! Where's my cow?", "Gatekeeper's cow is softer");
    private DialogueResponse mSaysMooDialog = new DialogueResponse(3f, "Gatekeeper: Too hard! My cow's soft! Where's my cow?", "Gatekeeper's cow is harder");
    private DialogueResponse mDoesntMooDialog = new DialogueResponse(3f, "Gatekeeper: My cow doesn't moo. Not mine!", "Gatekeeper's cow doesn't moo");
    private DialogueResponse mHasWingsDialog = new DialogueResponse(3f, "Gatekeeper: That's not my cow! My cow has wings!", "Gatekeeper's cow has wings");
    private DialogueResponse mNoWingsDialog = new DialogueResponse(3f, "Gatekeeper: Not my cow! My cow don't fly! ", "Gatekeeper's cow can't fly");

    public CowType ChosenCowType
    {
        get
        {
            return mChosenCowType;
        }
        set
        {
            mChosenCowType = value;
        }
    }
    void Start()
    {
        mChosenCowType = (CowType)Random.Range(0, 12);
        Debug.Log(mChosenCowType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.parent != null)
        {
            GameObject potentialCowObject = col.gameObject.transform.parent.gameObject;
            if (potentialCowObject.tag == "cow")
            {
                TryDeliverCow(potentialCowObject.GetComponent<Test_Cow>().TypeOfCow);
            }
        
        }
    }


    private bool CheckCow(CowType cowToCheck)
    {
        if (cowToCheck == ChosenCowType)
        {
            return true;
        }
        return false;
    }

    private DialogueResponse GetCowComparisonResponse(CowType cowToCheck)
    {
        if (cowToCheck == ChosenCowType)
        {
            return mCorrectCowDialog;
        }
        return mDefaultCowDialog;
    }

    public void TryDeliverCow(CowType cow)
    {
        DialogueResponse response = GetCowComparisonResponse(cow);
        DialogueUIManager.Instance.UpdateLatestClues(response.clueText);
        DialogueUIManager.Instance.StartPlayDialog(response.duration, response.dialogueText);
    }
}


public class DialogueResponse
{
    public float duration;
    public string dialogueText;
    public string clueText;

    public DialogueResponse(float dur, string dial, string clue)
    {
        this.duration = dur;
        this.dialogueText = dial;
        this.clueText = clue;
    }
}



