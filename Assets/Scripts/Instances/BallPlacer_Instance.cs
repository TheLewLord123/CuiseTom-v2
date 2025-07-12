using System;
using System.Net;
using Lean.Touch;
using Unity.VisualScripting;
using UnityEngine;

public class BallPlacer_Instance : MonoBehaviour
{
    public static BallPlacer_Instance instance;
    [SerializeField] RectTransform Rectplacer;
    [SerializeField] GameObject Balls;
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
        if (fingerPlaced) {
            Vector2 ScreenPosition = finger.ScreenPosition;
            // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(ScreenPosition.x, ScreenPosition.y, Camera.main.nearClipPlane));
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Rectplacer.parent as RectTransform, ScreenPosition, Camera.main, out localPoint);
            Rectplacer.localPosition = new Vector3(localPoint.x, Rectplacer.localPosition.y, Rectplacer.localPosition.z);
        }
    }
    private void FingerPlaced(LeanFinger finger)
    {
        fingerPlaced = true;
         oneBall = true;
    }
    private void FingerLifted(LeanFinger finger)
    {
        fingerPlaced = false;
        if (oneBall)
        {
            SB.SpawnBalls(Rectplacer.position,0);
            
            oneBall = false;
        }
    }
    
}
