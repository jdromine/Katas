using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoringEngine
{
    public static class ScoreCalculator
    {
        public static int CalculateTotalScore(List<Frame> frames){
            int totalScore = 0;

            for (int i = 0; i < frames.Count; i++)
            {
                totalScore += CalculateFrameScore(frames[i], frames);
            }

            return totalScore;
        }

        private static int CalculateFrameScore(Frame frame, List<Frame> frames)
        {
            int frameScore = 0;

            //frame 10 allows for a 3rd bonus ball
            if (IsLastFrame(frame))
            {
                frameScore = CalculateLastFrame(frame);
            }
            else
            {
                //spare
                if (IsSpare(frame))
                {
                    frameScore = GameConfiguration.NUMBER_OF_PINS + getNextFrame(frame, frames).Ball_1.Result;
                }
                //strike
                else if (IsStrike(frame))
                {
                    //the max score for a single frame is 30 pins
                    frameScore = Math.Min(GameConfiguration.MAX_FRAME_SCORE, GameConfiguration.NUMBER_OF_PINS + CalculateFrameScore(getNextFrame(frame, frames), frames));
                }
                //not all pins knocked down
                else
                {
                    frameScore = frame.Ball_1.Result + frame.Ball_2.Result;
                }
            }

            return frameScore;
        }

        private static Frame getNextFrame(Frame currentFrame, List<Frame> frames)
        {
            var nextFrames = from f in frames
                        where f.FrameNumber == currentFrame.FrameNumber + 1
                        select f;

            return nextFrames.First();
        }

        private static int CalculateLastFrame(Frame frame)
        {
            return frame.Ball_1.Result + frame.Ball_2.Result + frame.Ball_3.Result;
        }

        private static bool IsLastFrame(Frame frame)
        {
            return frame.FrameNumber == GameConfiguration.LAST_FRAME;
        }

        private static bool IsSpare(Frame frame)
        {
            return frame.Ball_1.Result + frame.Ball_2.Result == GameConfiguration.NUMBER_OF_PINS && frame.Ball_1.Result != GameConfiguration.NUMBER_OF_PINS;
        }

        private static bool IsStrike(Frame frame)
        {
            return frame.Ball_1.Result == GameConfiguration.NUMBER_OF_PINS;
        }
    }
}
