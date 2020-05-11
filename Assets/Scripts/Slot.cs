﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

  public GameObject item
  {
    get
    {
      if (transform.childCount > 0)
      {
        return transform.GetChild(0).gameObject;
      }
      return null;
    }
  }

  void IDropHandler.OnDrop(PointerEventData eventData)
  {
    throw new System.NotImplementedException();
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}