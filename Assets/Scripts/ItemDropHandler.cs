using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{

  public void OnDrop(PointerEventData eventData)
  {
    Debug.Log("DRROOOP");

    GameObject gameItem = eventData.pointerDrag;
    GameObject slotItem = eventData.pointerEnter;
    if (gameItem && slotItem.transform.tag == "Slot")
    {
      GameObject invItem = gameItem.GetComponent<DragAndDrop>().invItem;
      if (invItem)
      {
        GameObject newInvItem = Instantiate(invItem);
        newInvItem.transform.SetParent(transform);
        newInvItem.transform.SetPositionAndRotation(transform.position, transform.rotation);
      }
      Destroy(gameItem);
    }
    RectTransform invPanel = transform as RectTransform;
    transform.Rotate(Vector3.forward * 30);
    // if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, input.MousePosition)){
    //     Debug.Log("Drop Item");
    // }
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
