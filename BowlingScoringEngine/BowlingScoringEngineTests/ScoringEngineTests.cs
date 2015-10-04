using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScoringEngine;


namespace BowlingScoringEngineTests
{
    [TestClass]
    public class ScoringEngineTests
    {
        [TestMethod]
        public void should_calculate_zero_when_all_gutter_balls()
        {
            List<Frame> frames = new List<Frame>();

            for (int i = 1; i <= 10; i++)
            {
                Ball ball1 = new Ball(0);
                Ball ball2 = new Ball(0);
                Ball ball3 = new Ball(0);

                frames.Add(new Frame(i, ball1, ball2, ball3));
            }

            int score = ScoreCalculator.CalculateTotalScore(frames);
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void should_calculate_300_when_all_strikes()
        {
            List<Frame> frames = new List<Frame>();

            for (int i = 1; i <= 9; i++)
            {
                Ball ball1 = new Ball(10);
                Ball ball2 = new Ball(0);
                Ball ball3 = new Ball(0);

                frames.Add(new Frame(i, ball1, ball2, ball3));
            }

            frames.Add(new Frame(10, new Ball(10), new Ball(10), new Ball(10)));

            int score = ScoreCalculator.CalculateTotalScore(frames);
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void should_calculate_20_when_spare_then_5_then_gutters()
        {
            List<Frame> frames = new List<Frame>();

            frames.Add(new Frame(1, new Ball(7), new Ball(3), new Ball(0)));
            frames.Add(new Frame(2, new Ball(5), new Ball(0), new Ball(0)));

            for (int i = 3; i <= 10; i++)
            {
                Ball ball1 = new Ball(0);
                Ball ball2 = new Ball(0);
                Ball ball3 = new Ball(0);

                frames.Add(new Frame(i, ball1, ball2, ball3));
            }

            int score = ScoreCalculator.CalculateTotalScore(frames);
            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void should_calculate_60_when_strike_then_strike_then_strike_then_gutters()
        {
            List<Frame> frames = new List<Frame>();

            frames.Add(new Frame(1, new Ball(10), new Ball(0), new Ball(0)));
            frames.Add(new Frame(2, new Ball(10), new Ball(0), new Ball(0)));
            frames.Add(new Frame(3, new Ball(10), new Ball(0), new Ball(0)));

            for (int i = 4; i <= 10; i++)
            {
                Ball ball1 = new Ball(0);
                Ball ball2 = new Ball(0);
                Ball ball3 = new Ball(0);

                frames.Add(new Frame(i, ball1, ball2, ball3));
            }

            int score = ScoreCalculator.CalculateTotalScore(frames);
            Assert.AreEqual(60, score);
        }

        [TestMethod]
        public void should_calculate_50_when_spare_then_strike_then_strike_then_gutters()
        {
            List<Frame> frames = new List<Frame>();

            frames.Add(new Frame(1, new Ball(5), new Ball(5), new Ball(0)));
            frames.Add(new Frame(2, new Ball(10), new Ball(0), new Ball(0)));
            frames.Add(new Frame(3, new Ball(10), new Ball(0), new Ball(0)));

            for (int i = 4; i <= 10; i++)
            {
                Ball ball1 = new Ball(0);
                Ball ball2 = new Ball(0);
                Ball ball3 = new Ball(0);

                frames.Add(new Frame(i, ball1, ball2, ball3));
            }

            int score = ScoreCalculator.CalculateTotalScore(frames);
            Assert.AreEqual(50, score);
        }

    }
}
