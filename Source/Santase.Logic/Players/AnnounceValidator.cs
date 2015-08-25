﻿namespace Santase.Logic.Players
{
    using System.Collections.Generic;
    using System.Linq;

    using Santase.Logic.Cards;

    public class AnnounceValidator : IAnnounceValidator
    {
        public Announce GetPossibleAnnounce(
            IEnumerable<Card> playerCards,
            Card cardToBePlayed,
            Card trumpCard,
            bool amITheFirstPlayer = true)
        {
            if (!amITheFirstPlayer)
            {
                return Announce.None;
            }

            CardType cardTypeToSearch;
            switch (cardToBePlayed.Type)
            {
                case CardType.Queen:
                    cardTypeToSearch = CardType.King;
                    break;
                case CardType.King:
                    cardTypeToSearch = CardType.Queen;
                    break;
                default:
                    return Announce.None;
            }

            var cardToSearch = new Card(cardToBePlayed.Suit, cardTypeToSearch);
            if (!playerCards.Contains(cardToSearch))
            {
                return Announce.None;
            }

            return cardToBePlayed.Suit == trumpCard.Suit ? Announce.Fourty : Announce.Twenty;
        }
    }
}
