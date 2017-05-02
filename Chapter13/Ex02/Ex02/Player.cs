using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ex02
{
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        public bool HasWon()
        {
            //题目歧义太过严重，懒得改了，就这样吧
            //我理解成了只要有一套牌符合条件就算赢
            //也就是说只要有三张同花顺或同点数就行

            //以第i张牌开始，是否有同花顺或同点数
            for (int i = 0; i < PlayHand.Count; ++i)
            {
                int sameRankNum = 1;
                for(int j=0;j<PlayHand.Count;++j)
                {
                    if (PlayHand[j].rank == PlayHand[i].rank && i != j)
                        ++sameRankNum;
                }
                if (sameRankNum >= 3) return true;
                if (AreWave(PlayHand[i], 1)) return true;
            }
            return false;
        }
        private bool AreWave(Card thisCard, int index)
        {
            if (index == 3) return true;
            bool areWave = false;
            for (int i = 0; i < PlayHand.Count; ++i)
            {
                if (PlayHand[i].rank == thisCard.rank + 1 && PlayHand[i].suit == thisCard.suit)
                {
                    areWave = AreWave(PlayHand[i], ++index);
                    break;
                }
            }
            return areWave;
        }

    }
}
