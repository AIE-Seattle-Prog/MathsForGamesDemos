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
    public class CircleTarget : GameObject
    {
        public float radius = 15.0f;
        public Colour color;

        public override void Update()
        {
            base.Update();

            // detect the click
            if(Raylib.IsMouseButtonPressed(0))
            {
                // did the user click on the circle?
                int mouseX = Raylib.GetMouseX();
                int mouseY = Raylib.GetMouseY();

                Vector3 mouseVec = new Vector3(mouseX, mouseY);
                Vector3 offset = mouseVec - position;

                // was the click in the circle
                if(offset.Magnitude < radius)
                {
                    ++GameLoopState.Score;

                    // relocate to another position
                    position.x = MathLibrary.Random.Range(0, Raylib.GetScreenWidth());
                    position.y = MathLibrary.Random.Range(0, Raylib.GetScreenHeight());
                }
            }

            
        }

        public override void Draw()
        {
            base.Draw();

            Raylib.DrawCircle((int)position.x, (int)position.y, radius, RaylibHelper.FromColour(color));
        }
    }
}
