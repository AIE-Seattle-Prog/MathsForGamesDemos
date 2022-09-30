using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using MathLibrary;
using GameFramework;

namespace Random_ClickTheCircles
{
    public class ScoreDisplay : GameObject
    {
        public int fontSize = 14;

        public override void Draw()
        {
            base.Draw();

            Raylib.DrawText(GameLoopState.Score.ToString(), (int)position.x, (int)position.y, fontSize, Color.BLACK);
        }
    }
}
