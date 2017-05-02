using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ex02
{
    public class Game
    {
        private Deck playDeck;
        private int currentCard;
        private Player[] players;
        private Cards discardedCards;
        public Game()
        {
            playDeck = new Deck(true);
            playDeck.Shuffle();
            currentCard = 0;
            playDeck.LastCardDown += Reshuffle;
            discardedCards = new Cards();
        }
        private void Reshuffle(object source, EventArgs args)
        {
            Console.WriteLine("Discarded cards reshuffled into deck.");
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException("A maximum of 7 players may play this game.");
            if (newPlayers.Length < 2)
                throw new ArgumentException("A minium of 2 players may play this game.");
            players = newPlayers;
        }
        private void DealHands()
        {
            for (int p = 0; p < players.Length; ++p)
            {
                for (int c = 0; c < 7; ++c)
                {
                    players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
                }
            }
        }
        public int PlayGame()
        {
            //only play if players exist.
            if (players == null)
                return -1;
            //deal initial hands.
            DealHands();
            //initialize game vars, including an initial card to place on the table: playCard.
            bool GameWon = false;
            int currentPlayer;
            Card playCard = playDeck.GetCard(currentCard++);
            discardedCards.Add(playCard);
            //Main game loop, continuew until GameWon==true.
            do
            {
                //loop through players in each game round.
                for (currentPlayer = 0; currentPlayer < players.Length;currentPlayer++)
                {
                    //write out current player, player hand, and the card on the table.
                    Console.WriteLine($"{players[currentPlayer].Name}'s turn.");
                    Console.WriteLine("Current hand:");
                    foreach (Card card in players[currentPlayer].PlayHand)
                    {
                        Console.WriteLine(card);
                    }
                    Console.WriteLine($"Card in play: {playCard}");
                    //prompt player to pick up card on table or draw a new one.
                    bool inputOK = false;
                    do
                    {
                        Console.WriteLine("Press T to take card in play or D to draw:");
                        string input = Console.ReadLine();
                        if (input.ToLower() == "t")
                        {
                            //Add card from table to player hand.
                            Console.WriteLine($"Drawn: {playCard}");
                            //remove from discarded cards if possible
                            //(if deck is reshuffled it won't be there any more.
                            if (discardedCards.Contains(playCard))
                                discardedCards.Remove(playCard);
                            players[currentPlayer].PlayHand.Add(playCard);
                            inputOK = true;
                        }
                        if (input.ToLower() == "d")
                        {
                            //add new card from deck to player hand.
                            Card newCard;
                            //only add card if it isn't already in a player hand or in the discard pile
                            bool cardIsAvaliable;
                            do
                            {
                                newCard = playDeck.GetCard(currentCard++);
                                //check if card is in discard pile
                                cardIsAvaliable = !discardedCards.Contains(newCard);
                                if (cardIsAvaliable)
                                {
                                    //loop throuth al player hands to see if newCard 
                                    //is already in a hand.
                                    foreach (Player testPlayer in players)
                                    {
                                        if (testPlayer.PlayHand.Contains(newCard))
                                        {
                                            cardIsAvaliable = false;
                                            break;
                                        }
                                    }
                                }
                            } while (!cardIsAvaliable);
                            //Add the card found to player hand.
                            Console.WriteLine($"Drawn: {newCard}");
                            players[currentPlayer].PlayHand.Add(newCard);
                            inputOK = true;
                        }
                    } while (inputOK == false);
                    //display new hand with cards numbered.
                    Console.WriteLine("New hand:");
                    for (int i = 0; i < players[currentPlayer].PlayHand.Count; ++i)
                    {
                        Console.WriteLine($"{i + 1}: {players[currentPlayer].PlayHand[i]}");
                    }
                    //prompt player for a card to discard.
                    inputOK = false;
                    int choice = -1;
                    do
                    {
                        Console.WriteLine("Choose card to discard:");
                        string input = Console.ReadLine();
                        try
                        {
                            choice = Convert.ToInt32(input);
                            if (choice > 0 && choice <= 8)
                                inputOK = true;
                        }
                        catch
                        {
                            //ignore
                        }
                    } while (!inputOK);
                    //place reference to removed card in playCard
                    //(place the card on the table), then remove card from 
                    //player hand and add to discarded card pile.
                    playCard = players[currentPlayer].PlayHand[choice - 1];
                    players[currentPlayer].PlayHand.RemoveAt(choice - 1);
                    discardedCards.Add(playCard);
                    Console.WriteLine($"Discarding: {playCard}");
                    //space out text for players
                    Console.WriteLine();
                    //check to see if player has won the game, and exit the player loop if so.
                    GameWon = players[currentPlayer].HasWon();
                    if (GameWon == true) break;

                }
            } while (GameWon == false);
            //end game, noting the winning player.
            return currentPlayer;
        }
    }
}
