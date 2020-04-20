using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    List<Card> deck;

    
    void Start()
    {
        var board = FindObjectOfType<BoardManager>();
        foreach(Card card in deck)
        {
            card.onClicked += () =>
            {
                board.Spawn(card.prefab, 1, 1);
                Destroy(card);

            };

        }
    }

   
}
