using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class CardModelController : MonoBehaviour
    {
        public RectTransform targetRectTransform;
        public RectTransform cardRectTransform;

        public Transform panel;

        public Card card;

        public Text tileText;
        public Text descriptionText;

        public Image image;

        void Start()
        {
            tileText.text = card.tile;
            descriptionText.text = card.description;

            image.sprite = card.sprite;
        }

        void Update()
        {
            if (targetRectTransform.parent.name != "Deck")
            {
                if (targetRectTransform.parent.name == "Canvas")
                {
                    cardRectTransform.pivot = Vector2.Lerp(cardRectTransform.pivot, new Vector2(cardRectTransform.pivot.x, 0.5f), 0.3f);
                    cardRectTransform.SetParent(targetRectTransform.parent);
                    cardRectTransform.SetSiblingIndex(1);
                    cardRectTransform.anchoredPosition = Vector2.Lerp(cardRectTransform.anchoredPosition, new Vector2(targetRectTransform.anchoredPosition.x, targetRectTransform.anchoredPosition.y), 0.2f);
                }
                else
                {
                    cardRectTransform.pivot = Vector2.Lerp(cardRectTransform.pivot, new Vector2(cardRectTransform.pivot.x, 1), 0.3f);
                    cardRectTransform.SetParent(panel);
                    cardRectTransform.anchoredPosition = Vector2.Lerp(cardRectTransform.anchoredPosition, new Vector2(targetRectTransform.anchoredPosition.x, targetRectTransform.parent.GetComponent<RectTransform>().anchoredPosition.y), 0.2f);
                }
            }
        }
    }
}
