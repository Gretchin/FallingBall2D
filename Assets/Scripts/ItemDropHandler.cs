using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
  GameHandler gameHandler;

  void Start()
  {
    gameHandler = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
  }

  public void OnDrop(PointerEventData eventData)
  {
    if (gameHandler.IsSimulated())
    {
      return;
    }
    GameObject gameItem = eventData.pointerDrag;
    GameObject slotItem = eventData.pointerEnter;
    if (gameItem && slotItem.transform.tag == "Slot")
    {
      GameObject invItem = gameItem.tag == "InventaryItem"
        ? gameItem
        : gameItem.GetComponent<DragAndRotating>()?.invItem;

      if (invItem)
      {
        GameObject newInvItem = Instantiate(invItem);
        newInvItem.transform.SetParent(transform);
        newInvItem.transform.SetPositionAndRotation(transform.position, transform.rotation);
      }
      Destroy(gameItem);
    }
  }
}
