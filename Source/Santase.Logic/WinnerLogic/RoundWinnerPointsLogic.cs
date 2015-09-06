﻿namespace Santase.Logic.WinnerLogic
{
    public class RoundWinnerPointsPointsLogic : IRoundWinnerPointsLogic
    {
        public RoundWinnerPoints GetWinnerPoints(
            int firstPlayerPoints,
            int secondPlayerPoints,
            PlayerPosition gameClosedBy,
            PlayerPosition noTricksPlayer)
        {
            if (gameClosedBy == PlayerPosition.FirstPlayer)
            {
                if (firstPlayerPoints < 66)
                {
                    return RoundWinnerPoints.Second(3);
                }
            }

            if (gameClosedBy == PlayerPosition.SecondPlayer)
            {
                if (secondPlayerPoints < 66)
                {
                    return RoundWinnerPoints.First(3);
                }
            }

            if (firstPlayerPoints == secondPlayerPoints)
            {
                // Equal points => 0 points to each
                return RoundWinnerPoints.Draw();
            }

            if (firstPlayerPoints < 66 && secondPlayerPoints < 66)
            {
                if (firstPlayerPoints > secondPlayerPoints)
                {
                    return RoundWinnerPoints.First(1);
                }

                if (secondPlayerPoints > firstPlayerPoints)
                {
                    return RoundWinnerPoints.Second(1);
                }
            }

            if (firstPlayerPoints > secondPlayerPoints)
            {
                if (secondPlayerPoints >= 33)
                {
                    return RoundWinnerPoints.First(1);
                }

                if (noTricksPlayer == PlayerPosition.SecondPlayer)
                {
                    return RoundWinnerPoints.First(3);
                }

                // at lest one trick and less than 33 points
                return RoundWinnerPoints.First(2);
            }
            else
            {
                // secondPlayerPoints > firstPlayerPoints
                if (firstPlayerPoints >= 33)
                {
                    return RoundWinnerPoints.Second(1);
                }

                if (noTricksPlayer == PlayerPosition.FirstPlayer)
                {
                    return RoundWinnerPoints.Second(3);
                }

                // at lest one trick and less than 33 points
                return RoundWinnerPoints.Second(2);
            }
        }
    }
}
