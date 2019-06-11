﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//tes
//aaaaaaaa


public class DraggableObj : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public GameObject bottom;
    public GameObject top;

    public bool isDragging;

    GameObject bottomDragging;
    GameObject topDragging;

    private void Awake()
    {
 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        bottomDragging = Instantiate(bottom, this.transform);
        bottomDragging.transform.position = eventData.position;
        topDragging = Instantiate(top, this.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        float targetAng = Mathf.Atan2(topDragging.transform.position.y - bottomDragging.transform.position.y, topDragging.transform.position.x - bottomDragging.transform.position.x);
        Debug.Log(Mathf.Rad2Deg * targetAng);
        bottomDragging.transform.eulerAngles = (new Vector3(0.0f, 0.0f, Mathf.Rad2Deg * targetAng - 90.0f));
        topDragging.transform.position = eventData.position;
        topDragging.transform.eulerAngles = (new Vector3(0.0f, 0.0f, Mathf.Rad2Deg * targetAng - 90.0f));
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        topDragging.GetComponent<Rigidbody2D>().simulated = true;
        bottomDragging.GetComponent<Rigidbody2D>().simulated = true;
    }
}
