using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScoringEngine
{
    public class Frame
    {
        private Ball ball2 = null;
        private Ball ball3 = null;

        public int FrameNumber {get; set;}
        public Ball Ball_1 { get; set; }
        public Ball Ball_2 { 
            get{
                return this.ball2;
            } 
            set{
                if (this.Ball_1.Result == 10 && this.FrameNumber != 10){
                    this.ball2 = new Ball(0);
                } else {
                    this.ball2 = value;
                }
            } 
        }
        public Ball Ball_3 { 
            get{
                return this.ball3;   
            }        
            set{
                if (this.FrameNumber != 10 || this.Ball_1.Result + this.Ball_2.Result < 10){
                    this.ball3 = new Ball(0);
                } else {
                    this.ball3 = value;
                }
            }
        }

        public Frame(int frameNumber, Ball ball1, Ball ball2, Ball ball3)
        {
            this.FrameNumber = frameNumber;
            this.Ball_1 = ball1;
            this.Ball_2 = ball2;
            this.Ball_3 = ball3;
        }
    }
}
