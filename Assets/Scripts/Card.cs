using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {
	public enum Denomination
	{
		Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
	};
	public enum Suit
	{
		Hearts, Spades, Clubs, Diamonds
	};

	public const float CARD_THICKNESS = 0.01f;

	private Denomination denomination;
	private Suit suit;
	private CardInputListener listener;

	[SerializeField] private Sprite aceHeartsSprite;
	[SerializeField] private Sprite twoHeartsSprite;
	[SerializeField] private Sprite threeHeartsSprite;
	[SerializeField] private Sprite fourHeartsSprite;
	[SerializeField] private Sprite fiveHeartsSprite;
	[SerializeField] private Sprite sixHeartsSprite;
	[SerializeField] private Sprite sevenHeartsSprite;
	[SerializeField] private Sprite eightHeartsSprite;
	[SerializeField] private Sprite nineHeartsSprite;
	[SerializeField] private Sprite tenHeartsSprite;
	[SerializeField] private Sprite jackHeartsSprite;
	[SerializeField] private Sprite queenHeartsSprite;
	[SerializeField] private Sprite kingHeartsSprite;
	[SerializeField] private Sprite aceSpadesSprite;
	[SerializeField] private Sprite twoSpadesSprite;
	[SerializeField] private Sprite threeSpadesSprite;
	[SerializeField] private Sprite fourSpadesSprite;
	[SerializeField] private Sprite fiveSpadesSprite;
	[SerializeField] private Sprite sixSpadesSprite;
	[SerializeField] private Sprite sevenSpadesSprite;
	[SerializeField] private Sprite eightSpadesSprite;
	[SerializeField] private Sprite nineSpadesSprite;
	[SerializeField] private Sprite tenSpadesSprite;
	[SerializeField] private Sprite jackSpadesSprite;
	[SerializeField] private Sprite queenSpadesSprite;
	[SerializeField] private Sprite kingSpadesSprite;
	[SerializeField] private Sprite aceClubsSprite;
	[SerializeField] private Sprite twoClubsSprite;
	[SerializeField] private Sprite threeClubsSprite;
	[SerializeField] private Sprite fourClubsSprite;
	[SerializeField] private Sprite fiveClubsSprite;
	[SerializeField] private Sprite sixClubsSprite;
	[SerializeField] private Sprite sevenClubsSprite;
	[SerializeField] private Sprite eightClubsSprite;
	[SerializeField] private Sprite nineClubsSprite;
	[SerializeField] private Sprite tenClubsSprite;
	[SerializeField] private Sprite jackClubsSprite;
	[SerializeField] private Sprite queenClubsSprite;
	[SerializeField] private Sprite kingClubsSprite;
	[SerializeField] private Sprite aceDiamondsSprite;
	[SerializeField] private Sprite twoDiamondsSprite;
	[SerializeField] private Sprite threeDiamondsSprite;
	[SerializeField] private Sprite fourDiamondsSprite;
	[SerializeField] private Sprite fiveDiamondsSprite;
	[SerializeField] private Sprite sixDiamondsSprite;
	[SerializeField] private Sprite sevenDiamondsSprite;
	[SerializeField] private Sprite eightDiamondsSprite;
	[SerializeField] private Sprite nineDiamondsSprite;
	[SerializeField] private Sprite tenDiamondsSprite;
	[SerializeField] private Sprite jackDiamondsSprite;
	[SerializeField] private Sprite queenDiamondsSprite;
	[SerializeField] private Sprite kingDiamondsSprite;

	private static Object prefabResource = Resources.Load ("CardPrefab");
	private GameObject cardBack;
	private GameObject cardFace;

	void Awake() {
		cardBack = transform.Find ("CardBack").gameObject;
		cardFace = transform.Find ("CardFace").gameObject;
		//Debug.Log (cardBack + " " + cardFace);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		listener.OnMouseDown (this);
	}

	public void FaceUp() {
		//Debug.Log (denomination + " " + suit);
		cardBack.SetActive (false);
	}

	public void MoveTo(GameObject gameObject) {
		AcceptsCard from = transform.parent.GetComponent<AcceptsCard> ();
		AcceptsCard to = gameObject.GetComponent<AcceptsCard> ();
		transform.parent = gameObject.transform;
		from.OnMovedOut (this);
		to.OnMovedIn (this);
	}

	public void AddRandomJiggle(ref float x, ref float y, ref float angle) {
		//Debug.Log ("Jiggling " + x + " " + y + " " + angle);
		x = x + Random.Range(-0.09f, 0.09f);
		y = y + Random.Range(-0.09f, 0.09f);
		angle = angle + Random.Range(-10f, 10f);
	}

	public static Card CreateCard(Denomination denomination, Suit suit) {
		return CreateCard (denomination, suit, null);
	}

	public static Card CreateCard(Denomination denomination, Suit suit, CardInputListener listener) {
		Card card = (Instantiate (prefabResource) as GameObject).GetComponent<Card> ();
		card.denomination = denomination;
		card.suit = suit;
		if (listener != null)
			card.listener = listener;
		//Debug.Log (card.aceClubsSprite);
		//Debug.Log (card.cardBack);
		//Debug.Log (card.cardFace);
		switch (denomination) {
		case Denomination.Ace:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.aceHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.aceSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.aceClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.aceDiamondsSprite; break;
			}
			break;
		case Denomination.Two:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.twoHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.twoSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.twoClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.twoDiamondsSprite; break;
			}
			break;
		case Denomination.Three:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.threeHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.threeSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.threeClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.threeDiamondsSprite; break;
			}
			break;
		case Denomination.Four:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fourHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fourSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fourClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fourDiamondsSprite; break;
			}
			break;
		case Denomination.Five:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fiveHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fiveSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fiveClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.fiveDiamondsSprite; break;
			}
			break;
		case Denomination.Six:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sixHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sixSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sixClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sixDiamondsSprite; break;
			}
			break;
		case Denomination.Seven:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sevenHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sevenSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sevenClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.sevenDiamondsSprite; break;
			}
			break;
		case Denomination.Eight:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.eightHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.eightSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.eightClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.eightDiamondsSprite; break;
			}
			break;
		case Denomination.Nine:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.nineHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.nineSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.nineClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.nineDiamondsSprite; break;
			}
			break;
		case Denomination.Ten:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.tenHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.tenSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.tenClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.tenDiamondsSprite; break;
			}
			break;
		case Denomination.Jack:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.jackHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.jackSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.jackClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.jackDiamondsSprite; break;
			}
			break;
		case Denomination.Queen:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.queenHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.queenSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.queenClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.queenDiamondsSprite; break;
			}
			break;
		case Denomination.King:
			switch (suit) {
			case Suit.Hearts: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.kingHeartsSprite; break;
			case Suit.Spades: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.kingSpadesSprite; break;
			case Suit.Clubs: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.kingClubsSprite; break;
			case Suit.Diamonds: card.cardFace.GetComponent<SpriteRenderer> ().sprite = card.kingDiamondsSprite; break;
			}
			break;
		}
		return card;
	}

}

public interface CardInputListener {
	void OnMouseDown(Card card);
}

public interface AcceptsCard {
	void OnMovedOut(Card card);
	void OnMovedIn(Card card);
}