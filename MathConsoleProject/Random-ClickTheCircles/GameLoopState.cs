using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;

namespace Random_ClickTheCircles
{
    public class GameLoopState : GameState
    {
        CircleTarget circleTarget;
        ScoreDisplay scoreDisplay;

        public static int Score = 0;
        public static float TimeRemaining = 5.0f;

        public override void Start()
        {
            base.Start();

            circleTarget = new CircleTarget();
            circleTarget.position = new Vector3(500, 200);
            circleTarget.radius = 50.0f;
            circleTarget.color = new Colour(150, 0, 150, 255);

            scoreDisplay = new ScoreDisplay();
            scoreDisplay.position = new Vector3(700, 20);
            scoreDisplay.fontSize = 50;

            Score = 0;
            TimeRemaining = 5.0f;
        }

        public override void Update()
        {
            base.Update();

            TimeRemaining -= Raylib.GetFrameTime();

            circleTarget.Update();
            scoreDisplay.Update();
        }

        public override void Draw()
        {
            base.Draw();

            circleTarget.Draw();
            scoreDisplay.Draw();
        }

        public override bool StateShouldChange()
        {
            return TimeRemaining <= 0.0f;
        }

        public override GameStates GetNextGameState()
        {
            return GameStates.EndScreen;
        }
    }
}
