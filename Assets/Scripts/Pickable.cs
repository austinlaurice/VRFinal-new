using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

public class Pickable : MonoBehaviour, IPointerClickHandler
{
    private Transform hand;
    private bool picked;
    private Vector3 initPosition, initAngle, pickedAngle;
    private float progress;
    public float duration = 0.05f;
    static Pickable pickedItem = null;
    // Use this for initialization
    void Start()
    {
        hand = GameObject.Find("Hand").transform;
        Debug.Log(GameObject.Find("Hand").ToString());
        pickedAngle = new Vector3(0, 0, 0);
        progress = 0;
        picked = false;
        initPosition = transform.position;
        initAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (!((progress <= 0 && !picked) || (progress >= 1 && picked)))
        {
            if (picked)
            {
                progress += Time.deltaTime / duration;
            }
            else
            {
                progress -= Time.deltaTime / duration;
            }
            transform.position = Vector3.Lerp(initPosition, hand.position, progress);
            transform.localEulerAngles = Vector3.Slerp(transform.TransformDirection(initAngle), pickedAngle, progress);
        }
        if (picked)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(pickedItem != null)
        {
            pickedItem.transform.parent = transform.parent;
            pickedItem.transform.position = transform.position;
            pickedItem.progress = 0;
            pickedItem.transform.rotation = new Quaternion(0, 0, 0, 0);
            pickedItem.picked = false;
        }
        pickedItem = this;
        picked = true;
        transform.parent = hand;
    }
    
    public bool isPicked()
    {
        return picked;
    }
    static public string itemName()
    {
        if (pickedItem == null)
            return "";
        else
            return pickedItem.name;
    }
    static public void useItem()
    {
        GameObject.DestroyImmediate(pickedItem.gameObject);
        pickedItem = null;
        Assert.IsNull(pickedItem);
    }
}
