using UnityEngine;
using UnityEngine.InputSystem;

public class SlingshotRubber : MonoBehaviour
{
    public LineRenderer leftBand;
    public LineRenderer rightBand;

    public Transform leftPoint;
    public Transform rightPoint;

    public Transform bird;
    public static SlingshotRubber instance;

    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        leftBand.positionCount = 2;
        rightBand.positionCount = 2;

        HideBands();
    }
    public void DrawBands()
    {

        if (leftBand.positionCount == 0)
            leftBand.positionCount = 2;

        if (rightBand.positionCount == 0)
            rightBand.positionCount = 2;


        // Left band
        leftBand.SetPosition(0, leftPoint.position); //start point position
        leftBand.SetPosition(1, bird.position); //end point position

        // Right band
        rightBand.SetPosition(0, rightPoint.position); //start point position
        rightBand.SetPosition(1, bird.position); //end point position
    }

    public void HideBands()
    {
        leftBand.positionCount = 0;
        rightBand.positionCount = 0;
    }
}
