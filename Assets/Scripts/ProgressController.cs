using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//this script will track the user's progress in snowman building

public class ProgressController : MonoBehaviour
{
    int CurrentStep = 1;
    int inBetweenStepCounter = 1;
    //string[] pastCallers = new string[15];
    Stack<Object> pastCallers = new Stack<Object>();
    PlaySoundsFromList soundPlayer = null;
    SocketController sockCon = null;

    public GameObject tutorialCanvas;
    public TMP_Text tutorialTitleText;
    public TMP_Text tutorialText;

    void Start()
    {
        //get sound component
        soundPlayer = GetComponent<PlaySoundsFromList>();
        //go to sockCon
        sockCon = GetComponent<SocketController>();
    }
    
    //when this is called by an object, it will move on to the next step of the process
    public void Progress(Object caller)
    {
        //check if object calling this is a new object
        //Debug.Log("Caller ID: " + caller);
        foreach(Object loggedCaller in pastCallers)
        {
            //if caller has already progressed step
            if(loggedCaller == caller)
            {
                //skip process and do not increment
                //Debug.Log("This step has already been completed! Caller ID: " + caller);
                return;
            }
        }
        //caller is a new object: add to stack
        pastCallers.Push(caller);

        // increment step (depending on current)
        switch (CurrentStep)
        {
            //if step is for arms(7), eyes(8), or mouth(9), then need to count up inBetween counter instead

            case 7: //arms
                if (inBetweenStepCounter < 2)
                {
                    inBetweenStepCounter++;
                }else{
                    CurrentStep++;
                    inBetweenStepCounter = 1;
                }
                break;

            case 8: //eyes
                if (inBetweenStepCounter < 2)
                {
                    inBetweenStepCounter++;
                }
                else
                {
                    CurrentStep++;
                    inBetweenStepCounter = 1;
                }
                break;

            case 9: // i have 3 mouths but can't scream 3 times as loud
                if (inBetweenStepCounter < 3)
                {
                    inBetweenStepCounter++;
                }
                else
                {
                    CurrentStep++;
                    inBetweenStepCounter = 1;
                }
                break;

            default: CurrentStep += 1;
                break;
        }
        
        //Debug.Log("Step Completed! Current Step is now: " + CurrentStep + ". InBetweenStep = " + inBetweenStepCounter);
        //play step complete sfx
        if (soundPlayer != null)
            soundPlayer.PlayAtIndex(0);

        //only do menu stuff if counter is on a new step
        if (inBetweenStepCounter == 1)
        {
            //(set window text)
            SetText(CurrentStep);

            //reactivate ui canvas
            tutorialCanvas.SetActive(true);

            //turn on any new sockets
            sockCon.EnableObjects(CurrentStep);
        }

        //if final step (Step 12), cue victory method
        if(CurrentStep >= 12)
        {
            TaskComplete();
        }
    }

    void SetText(int stepNum)
    {
        string newText = "";

        //set title text
        string newTitleText = "Step " + stepNum + ":";
        tutorialTitleText.text = newTitleText;

        //set text of UI
        switch (stepNum)
        {
            case 1:// create base of snowman (should never reach)
                newText = "Find a snowball and roll it up to size! \n\n This will be the base of the snowman.";
                break;

            case 2:// place snowball onto platform
                newText = "Great, now pick up the snowball and place it on the platform.";
                break;

            case 3:// create middle of snowman
                newText = "Find a new snowball and roll it up to size! \n\n This will be the middle of the snowman.";
                break;

            case 4:// place middle onto top
                newText = "Good, now pick up the middle snowball and place it on the top of the base snowball.";
                break;

            case 5:// create head of snowman
                newText = "Find a snowball and roll it up to a small size. \n\n This will be the head of the snowman.";
                break;

            case 6:// place head onto body
                newText = "Great, now pick up the head snowball and place it on top of the middle snowball of the snowman.";
                break;

            case 7:// place arms
                newText = "Find two sticks and place them on either side of the middle snowball.";
                break;

            case 8:// place eyes
                newText = "Find two eyes (made out of coal?) and place them on the snowman's head.";
                break;

            case 9:// place mouth
                newText = "Find three mouth pieces and place them onto the snowman's head.";
                break;

            case 10:// place nose
                newText = "Find a nose and place it on the snowman's face.";
                break;

            case 11:// place hat
                newText = "Find a non-magical hat and place it on top of the snowman's head.";
                break;

            case 12:// celebration text
                newText = "Awesome! Your snowman is complete. \n\n Hope you had fun in this Virtual Winter Wonderland!";
                break;

            default: newText = "Now, complete the next step!";
                break;
        }

        tutorialText.text = newText;
    }

    public void TaskComplete()
    {
        Debug.Log("Task Complete!");

        //play victory sfx
        soundPlayer.PlayAtIndex(1);
    }
}
