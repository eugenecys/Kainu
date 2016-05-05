using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SixenseHand))]

public class HandController : MonoBehaviour
{

    public enum Side
    {
        Left,
        Right
    }

    public Side side;

    private SixenseHand sxHand;
    private List<EventManager.GameEvent> pEvents;

    #region UnityDefaults

    void Awake()
    {
        sxHand = GetComponent<SixenseHand>();
        pEvents = new List<EventManager.GameEvent>();
        initObjectInteractions();
        initGestureRecognition();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (EventManager.GameEvent pEvent in pEvents)
        {
            pEvent();
        }

    }

    #endregion

    #region Object_Interactions

    public Interactable activeObject;
    public bool grabbing;

    void initObjectInteractions()
    {
        pEvents.Add(pollPos);
    }

    void pollPos()
    {

    }

    void grab()
    {

    }

    void throwObject(Fetchable fObj, Vector3 vect)
    {

    }

    #endregion

    #region Gesture_Recognition
    
    int bufferLength = 10;
    float dp2Thresh = Constants.CONTROLLER_ACCELERATION_THRESHOLD;
    float dp3Thresh = Constants.CONTROLLER_JERK_THRESHOLD;
    Vector3[] dp3Buffer;
    Vector3[] dp2Buffer;
    Vector3[] dpBuffer;
    Vector3[] pBuffer;
    int inflectionCount;
    int timeConst = 60;
    int pollDelay = 2;
    int pollCount = 0;
    int evalWindow = 2;
    bool isEvaluating = false;
    int evalCount = 0;
    float maxDp2Mag;
    float maxDp3Mag;
    float dp3Max = 800f;
    private int bufferSize = 10;
    private int bufferPtr = 0;
    private int prevPtr = 0;

    void initGestureRecognition()
    {
        //Creates inflection buffers
        bufferPtr = 0;
        dp3Buffer = new Vector3[bufferSize];
        dp2Buffer = new Vector3[bufferSize];
        dpBuffer = new Vector3[bufferSize];
        pBuffer = new Vector3[bufferSize];
        for (int i = 0; i < bufferLength; i++)
        {
            dp3Buffer[i] = Vector3.zero;
            dp2Buffer[i] = Vector3.zero;
            dpBuffer[i] = Vector3.zero;
            pBuffer[i] = Vector3.zero;
        }
    }

    void addToBuffer(Vector3 pos)
    {
        int prevIndex = (bufferPtr + bufferLength - 1) % bufferLength;
        pBuffer[bufferPtr] = pos;

        //Calculates inflection plot
        dpBuffer[bufferPtr] = (pBuffer[bufferPtr] - pBuffer[prevIndex]) / pollDelay * timeConst;
        dp2Buffer[bufferPtr] = (dpBuffer[bufferPtr] - dpBuffer[prevIndex]) / pollDelay * timeConst;
        dp3Buffer[bufferPtr] = (dp2Buffer[bufferPtr] - dp2Buffer[prevIndex]) / pollDelay * timeConst;
        float dp2Mag = dp2Buffer[bufferPtr].magnitude;
        float dp3Mag = dp3Buffer[bufferPtr].magnitude;
        if (dp2Mag > dp2Thresh || dp3Mag > dp3Thresh)
        {
            if (!isEvaluating)
            {
                evalCount = 0;
                isEvaluating = true;
                maxDp2Mag = dp2Mag;
                maxDp3Mag = dp3Mag;
            }
            else {
                if (maxDp2Mag < dp2Mag)
                {
                    maxDp2Mag = dp2Mag;
                }
                if (maxDp3Mag < dp3Mag)
                {
                    maxDp3Mag = dp3Mag;
                }
            }

        }
        if (isEvaluating)
        {
            if (evalCount > evalWindow)
            {
                isEvaluating = false;
                if (maxDp3Mag > dp3Max)
                {
                    maxDp3Mag = dp3Max;
                }
                
                //TODO: Add in object to activate shake


                maxDp2Mag = 0;
                maxDp3Mag = 0;
            }
            evalCount += 1;
        }
        bufferPtr = (bufferPtr + 1) % bufferLength;
    }
    
    Vector3 getMeanVelocity()
    {
        Vector3 total = Vector3.zero;
        for (int i = 0; i < dpBuffer.Length; i++)
        {
            //Change to Gaussian function as per previous code from Lightscape
            total = total + dpBuffer[i];
        }
        return total / Time.deltaTime / bufferSize;
    }

    void updateDyBuffer()
    {
        bufferPtr = (bufferPtr + 1) % bufferSize;
        prevPtr = (bufferPtr + bufferSize - 1) % bufferSize;
        pBuffer[bufferPtr] = transform.position;
        dpBuffer[bufferPtr] = pBuffer[bufferPtr] - pBuffer[prevPtr];
    }


    #endregion

}
