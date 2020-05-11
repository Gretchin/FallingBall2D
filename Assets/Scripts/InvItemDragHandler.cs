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
    Debug.Log("beginDrag");
    GameObject newItem = Instantiate(gameItem);
    newItem.GetComponent<DragAndDrop>().SetIsMoving(true);
    Destroy(gameObject);

    // itemBeingDragged = gameObject;
    // startPosition = transform.position;
  }

  public void OnDrag(PointerEventData eventData)
  {
    // Debug.Log("Drag");
    // transform.position = Input.mousePosition;
  }


  public void OnEndDrag(PointerEventData eventData)
  {
    Debug.Log("OnEndDrag");
    // itemBeingDragged = null;
    // transform.position = startPosition;
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
