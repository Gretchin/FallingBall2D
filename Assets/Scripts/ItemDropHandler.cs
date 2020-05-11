using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{

  public void OnDrop(PointerEventData eventData)
  {
    GameObject gameItem = eventData.pointerDrag;
    GameObject slotItem = eventData.pointerEnter;
    if (gameItem && slotItem.transform.tag == "Slot")
    {
      GameObject invItem = gameItem.GetComponent<DragAndRotating>().invItem;
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
