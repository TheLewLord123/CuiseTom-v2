using System;
using System.Net;
using Lean.Touch;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class BallPlacer_Instance : MonoBehaviour
{
    public static BallPlacer_Instance instance;
    [SerializeField] RectTransform Rectplacer, RectHat;
    [SerializeField] BallList ballList;
    [SerializeField] BallStats NextBall, CurrentBall;
    [SerializeField] Image nextBallImage, currentBallImage;
    
    [SerializeField] float leftLimit, rightLimit,bottomLimit;
    bool fingerPlaced = false;
    bool oneBall = false;
    SpawnBalls_Instance SB;
    void OnEnable()
    {
        LeanTouch.OnFingerDown += FingerPlaced;
        LeanTouch.OnFingerUpdate += Positioning;
        LeanTouch.OnFingerUp += FingerLifted;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    void Start()
    {
        UpdateImages(ballList.ballStats[Random.Range(0, 3)], ballList.ballStats[Random.Range(0, 3)]);
        SB = SpawnBalls_Instance.instance;
        LeanTouch.OnFingerDown += FingerPlaced;
        LeanTouch.OnFingerUpdate += Positioning;
        LeanTouch.OnFingerUp += FingerLifted;
    }
    void OnDisable()
    {
        LeanTouch.OnFingerDown -= FingerPlaced;
        LeanTouch.OnFingerUpdate -= Positioning;
        LeanTouch.OnFingerUp -= FingerLifted;
    }
    private void Positioning(LeanFinger finger)
    {
        if (fingerPlaced)
        {
            Vector2 ScreenPosition = finger.ScreenPosition;
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rectplacer.parent as RectTransform, ScreenPosition, Camera.main, out localPoint);
            if (localPoint.y < bottomLimit)
            {
                oneBall = false;
                return;
            }
            if (localPoint.x < leftLimit)
            {
                localPoint.x = leftLimit;
            }
            else if (localPoint.x > rightLimit)
            {
                localPoint.x = rightLimit;
            }
            Rectplacer.localPosition = new Vector3(localPoint.x, Rectplacer.localPosition.y, Rectplacer.localPosition.z);
            RectHat.localPosition = new Vector3(localPoint.x, RectHat.localPosition.y, RectHat.localPosition.z);
        }
    }
    private void FingerPlaced(LeanFinger finger)
    {
        fingerPlaced = true;
        oneBall = true;
    }
    //NOTE: SpawnBalls when finger lifted
    private void FingerLifted(LeanFinger finger)
    {
        fingerPlaced = false;
        if (oneBall)
        {
            SB.SpawnBalls(Rectplacer.position, CurrentBall.level);
            UpdateImages(ballList.ballStats[Random.Range(0, 3)], NextBall);
            oneBall = false;
        }
    }
    void UpdateImages(BallStats nextbs, BallStats currentbs)
    {
        CurrentBall = currentbs;
        NextBall = nextbs;
        currentBallImage.sprite = CurrentBall.sprite;
        nextBallImage.sprite = NextBall.sprite;
        currentBallImage.GetComponent<RectTransform>().localScale = new Vector3(CurrentBall.size, CurrentBall.size, 0);
        nextBallImage.GetComponent<RectTransform>().localScale = new Vector3(CurrentBall.size, CurrentBall.size, 0);
    }

    
}
