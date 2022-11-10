using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will track the user's progress in snowman building

public class ProgressController : MonoBehaviour
{
    int CurrentStep = 1;
    int inBetweenStepCounter = 1;
    string instructionText = "";
    //string[] pastCallers = new string[15];
    Stack<Object> pastCallers = new Stack<Object>();

    void Start()
    {
        
    }

    void Update()
    {
        
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
                Debug.Log("This step has already been completed! Caller ID: " + caller);
                return;
            }
        }
        //caller is a new object: add to stack
        pastCallers.Push(caller);

        // increment step (depending on current)
        switch (CurrentStep)
        {
            //if step is for arms(7), eyes(8), or mouth(9), then need to count up inBetween counter instead

            case 7:
                if (inBetweenStepCounter > 2)
                {
                    inBetweenStepCounter++;
                }else{
                    CurrentStep++;
                    inBetweenStepCounter = 1;
                }
                break;

            default: CurrentStep += 1;
                break;
        }
        
        Debug.Log("Step Completed! Current Step is now: " + CurrentStep + ". InBetweenStep = " + inBetweenStepCounter);
        //play step complete sfx

        //only do menu stuff if counter is on a new step
        if (inBetweenStepCounter == 1)
        {
            //(set window text)
            instructionText = SetText(CurrentStep);

            //set new tutorial text to ui

            //reactivate ui canvas

        }
        

        //if step 3 or 5, activate the mid and head snowball, respectively
        if(CurrentStep == 3 || CurrentStep == 5)
        {
            ActivateSnowball(CurrentStep);
        }

        //if final step (Step 12), cue victory method
        if(CurrentStep >= 12)
        {
            TaskComplete();
        }
    }

    string SetText(int stepNum)
    {
        string newText = "";

        //set text of UI
        switch (stepNum)
        {
            default:
                break;
        }

        return newText;
    }

    void ActivateSnowball(int stepNum)
    {
        if(stepNum == 3)
        {
            //activate mid snowball gameobject
        }
        else
        {
            //activate head snowball gameobject
        }
    }

    public void TaskComplete()
    {
        Debug.Log("Task Complete!");

        //play victory sfx
    }
}
