using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, CardInputListener, AcceptsCard {
	private List<Card> cards = new List<Card>(); // 0 = bottom of face-down deck, top of face-up deck
	private DeckListener listener;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetListener(DeckListener listener) {
		this.listener = listener;
	}

	public void OnMouseDown(Card card) {
		if (Object.Equals(card,cards [cards.Count - 1]))
			listener.OnDeckDraw (card);
	}

	public void OnMovedOut(Card card) {
		cards.Remove (card);
		Debug.Log ("Removed " + card + " from deck");
	}

	public void OnMovedIn(Card card) {
	}

	public void AddSuit(Card.Suit suit) {
		AddCard (Card.CreateCard(Card.Denomination.Ace, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Two, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Three, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Four, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Five, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Six, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Seven, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Eight, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Nine, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Ten, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Jack, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.Queen, suit, this));
		AddCard (Card.CreateCard(Card.Denomination.King, suit, this));
	}

	public void AddCard(Card card) {
		card.gameObject.transform.parent = gameObject.transform;
		cards.Add (card);
	}

	public void Shuffle() {
		StartCoroutine ("Layout");
	}

	public void MoveCardTo(Card card, GameObject gameObject) {
		// Lift card a bit so that tweening won't cause it to go under another card before it leaves the deck
		card.transform.localPosition = new Vector3(card.transform.localPosition.x, card.transform.localPosition.y, card.transform.localPosition.z - 0.5f);

		card.MoveTo(gameObject);
	}

	IEnumerator Layout() {
		for (int i = 0; i < cards.Count; i++) {
			cards[i].gameObject.SetActive (false);
			cards[i].transform.localPosition = new Vector3 ((float)(i * 0.01), 0.0f, (float)((i + 1) * -(Card.CARD_THICKNESS)));
		}
		foreach (Card card in cards) {
			card.gameObject.SetActive (true);
			yield return new WaitForSeconds(.005f);
		}
	}

}

public interface DeckListener {
	void OnDeckDraw(Card card);
}