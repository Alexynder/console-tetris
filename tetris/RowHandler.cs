using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class RowHandler
    {
        public static void CheckRows(TetrisGame game)
        {
            int multyplayer = 0;
            int blockcounter = 0;
            for (int i = 0; i < 20; i++)
            {
                blockcounter = 0;
                for (int j = game.deltaX + 1; j < 10 + game.deltaX + 1; j++)
                {
                    if (game.gameField[i, j] == Block.block)
                    {
                        blockcounter++;
                    }
                }
                if (blockcounter == 10)
                {
                    multyplayer += 1;
                    RowHandler.DeleteRow(game,i);
                }
            }
            game.score += game.scoreDelta * multyplayer;
            game.RePrintGame();
        }

        public static void DeleteRow(TetrisGame game,int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = game.deltaX + 1; j < 10 + game.deltaX + 1; j++)
                {
                    game.gameField[i, j] = game.gameField[i - 1, j];
                    game.colorData[i, j] = game.colorData[i - 1, j];
                }
            }
        }
    }
}
