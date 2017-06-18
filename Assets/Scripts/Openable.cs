using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Assertions;

public interface Condition
{
    bool isTrue ();
}

public class Openable : MonoBehaviour, IPointerClickHandler
{
    public float duration = .2f;
    private Vector3 closePosition, openPosition, closeAngle, openAngle;
    private bool opening;
    private float progress;
    public GameObject condition;

    void Start()
    {
        Transform opened = transform.Find("opened");
        Assert.IsNotNull(opened);
        closePosition = transform.position;
        openPosition = opened.position;
        closeAngle = transform.eulerAngles;
        openAngle = opened.eulerAngles;
        opening = false;
        progress = 1;
    }

    void Update()
    {
        if (progress < 1)
        {
            progress += Time.deltaTime / duration;
            if (opening)
            {
                transform.position = Vector3.Lerp(closePosition, openPosition, progress);
                transform.eulerAngles = Vector3.Slerp(closeAngle, openAngle, progress);
            }
            else
            {
                transform.position = Vector3.Lerp(openPosition, closePosition, progress);
                transform.eulerAngles = Vector3.Slerp(openAngle, closeAngle, progress);
            }
        }
    }

    void Toggle()
    {
        if (!condition || condition.GetComponent<Condition>().isTrue())
        {
            opening = !opening;
            progress = 1 - progress;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }
}
