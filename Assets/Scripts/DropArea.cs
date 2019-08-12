using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts
{
    public class DropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            EmptyCardController d = eventData.pointerDrag.GetComponent<EmptyCardController>();
            if (d != null)
            {
                d.placeholderParent = this.transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null)
                return;

            EmptyCardController d = eventData.pointerDrag.GetComponent<EmptyCardController>();
            if (d != null && d.placeholderParent == this.transform)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            EmptyCardController d = eventData.pointerDrag.GetComponent<EmptyCardController>();
            if (d != null)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }
}