using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace Random_ClickTheCircles
{
    public class EndScreenState : GameState
    {
        private bool userWantsToPlayAgain = false;

        public override void Update()
        {
            base.Update();

            if(Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
            {
                userWantsToPlayAgain = true;
            }
        }

        public override void Draw()
        {
            base.Draw();

            Raylib.DrawText(GameLoopState.Score.ToString(),
                            Raylib.GetScreenWidth() / 2,
                            Raylib.GetScreenHeight() / 2,
                            36,
                            Color.BLACK);
        }

        public override bool StateShouldChange()
        {
            return userWantsToPlayAgain;
        }

        public override GameStates GetNextGameState()
        {
            return GameStates.GameLoop;
        }
    }
}
