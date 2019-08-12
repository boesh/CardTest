using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    public class CardManager : MonoBehaviour
    {
        public List<Transform> deck;
        public List<Transform> discardPile;

        public RectTransform discardPilePosition;

        public Transform hand;
        public Transform table;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                GetCardFromDeck();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                DiscardCards();
            }
        }

        void GetCardFromDeck()
        {
            if (deck.Count > 0)
            {
                deck[deck.Count - 1].transform.SetParent(hand);
                deck.Remove(deck[deck.Count - 1]);
            }
        }

        void DiscardCards()
        {
            while (table.childCount != 0)
            {
                table.GetChild(table.childCount - 1).GetComponent<RectTransform>().anchoredPosition = discardPilePosition.anchoredPosition;
                discardPile.Add(table.GetChild(table.childCount - 1));
                table.GetChild(table.childCount - 1).SetParent(discardPilePosition);
            }
        }
    }
}