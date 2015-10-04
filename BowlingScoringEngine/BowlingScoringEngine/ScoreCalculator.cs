using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoringEngine
{
    public static class ScoreCalculator
    {
        public const int MAX_FRAME_SCORE = 30;
        public const int NUMBER_OF_PINS = 10;
        public const int LAST_FRAME = 10;

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
            if (frame.FrameNumber == LAST_FRAME)
            {
                frameScore = CalculateLastFrame(frame);
            }
            else
            {
                //spare
                if (frame.Ball_1.Result + frame.Ball_2.Result == NUMBER_OF_PINS && frame.Ball_1.Result != NUMBER_OF_PINS)
                {
                    frameScore = NUMBER_OF_PINS + getNextFrame(frame, frames).Ball_1.Result;
                }
                //strike
                else if (frame.Ball_1.Result == NUMBER_OF_PINS)
                {
                    //the max score for a single frame is 30 pins
                    frameScore = Math.Min(MAX_FRAME_SCORE, NUMBER_OF_PINS + CalculateFrameScore(getNextFrame(frame, frames), frames));
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
    }
}
