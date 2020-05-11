using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
  public static GameObject itemBeingDragged;

  public GameObject gameItem;

  Vector3 startPosition;

  void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
  {
    GameObject newItem = Instantiate(gameItem);
    newItem.GetComponent<DragAndRotating>().SetIsMoving(true);
    Destroy(gameObject);
  }
  public void OnDrag(PointerEventData eventData) { }
  public void OnEndDrag(PointerEventData eventData) { }
}
