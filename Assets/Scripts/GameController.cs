using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, DeckListener {
	[SerializeField] private Deck deck;
	[SerializeField] private DiscardPile discardPile;

	// Use this for initialization
	void Start () {
		deck.SetListener (this);

		// Populate deck
		deck.AddSuit(Card.Suit.Hearts);
		deck.AddSuit(Card.Suit.Spades);
		deck.AddSuit(Card.Suit.Clubs);
		deck.AddSuit(Card.Suit.Diamonds);
		//deck.AddCard (Card.CreateCard (Card.Denomination.Ace, Card.Suit.Clubs, deck));

		deck.Shuffle ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDeckDraw(Card card) {
		deck.MoveCardTo (card, discardPile.gameObject);
	}

}
