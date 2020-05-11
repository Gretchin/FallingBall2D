using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
  public GameObject invItem;

  public bool Movable = true;
  bool isMoving;
  Rigidbody2D rb;

  public void OnBeginDrag(PointerEventData eventData)
  {
    Debug.Log("drag");
    // throw new System.NotImplementedException();
  }

  public void OnDrag(PointerEventData eventData)
  {
    Debug.Log("dragsss");
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    Debug.Log("dragEnd");
  }

  public void SetIsMoving(bool isMoving)
  {
    this.isMoving = isMoving;
  }


  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    if (!Movable)
    {
      return;
    }

    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

      switch (touch.phase)
      {
        case TouchPhase.Began:
          if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
          {
            isMoving = true;
          }
          break;

        case TouchPhase.Moved:
          if (isMoving)
          {
            rb.MovePosition(touchPos);

            if (Input.touchCount > 1)
            {
              Touch secondTouch = Input.GetTouch(1);

              Vector2 diff = touch.position - secondTouch.position;
              float angle = (Mathf.Atan2(diff.y, diff.x));
              transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * angle);
            }
          }
          break;

        case TouchPhase.Ended:
          if (isMoving)
          {
            isMoving = false;
          }
          break;
      }
    }
  }
}