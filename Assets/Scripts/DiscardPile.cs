using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscardPile : MonoBehaviour, AcceptsCard {
	private List<Card> cards = new List<Card>(); // 0 = bottom of face-down deck, top of face-up deck

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMovedOut(Card card) {
	}

	public void OnMovedIn(Card card) {
		// Get position of discard pile
		Vector3 globalPosition = transform.TransformVector (transform.localPosition);
		//Debug.Log ("Global position for " + transform.localPosition + " is " + globalPosition);
		// Jiggle the position
		float x = globalPosition.x, y = globalPosition.y, angle = 0.0f;
		card.AddRandomJiggle(ref x, ref y, ref angle);
		// Get desired position of card (position of discard pile + jiggle)
		float zDelta = (float)((cards.Count + 1) * -(Card.CARD_THICKNESS));
		Vector3 destPosition = new Vector3 (x, y, globalPosition.z + zDelta);
		// Tween
		LeanTween.move(card.gameObject, destPosition, 0.1f);
		LeanTween.rotate (card.gameObject, new Vector3 (0, 0, angle), 0.1f);
		//card.gameObject.transform.localPosition = new Vector3 (x, y, (float)((cards.Count + 1) * -(Card.CARD_THICKNESS)));
		//card.gameObject.transform.Rotate (0, 0, angle);

		card.FaceUp ();
		cards.Add (card);
		//Debug.Log ("Added " + card + " to discard pile");
	}
}
