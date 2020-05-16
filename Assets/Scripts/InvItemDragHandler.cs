using UnityEngine;
using UnityEngine.EventSystems;

public class InvItemDragHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
  public GameObject gameItem;
  GameHandler gameHandler;

  void Start()
  {
    gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
  }

  void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
  {
    if (gameHandler.IsSimulated() || !gameItem)
    {
      return;
    }
    // Vector2 чтобы обнулить координату z
    Vector2 newGameItemPosition = Camera.main.ScreenToWorldPoint(gameObject.transform.position);
    GameObject newItem = Instantiate(gameItem, newGameItemPosition, Quaternion.identity);
    newItem.GetComponent<DragAndRotating>()?.SetIsMoving(true);
    Destroy(gameObject);
  }
  public void OnDrag(PointerEventData eventData) { }
  public void OnEndDrag(PointerEventData eventData) { }
}
