using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathLibrary;

using Raylib_cs;

namespace GameFramework
{
    public class Button : GameObject
    {
        public Colour normalColour = new Colour(250, 250, 250, 255);
        public Colour clickColour = new Colour(128, 128, 128, 255);
        // hover, disabled, focused

        public Vector3 size;

        public bool IsClicked { get; private set; }

        public override void Update()
        {
            base.Update();
            
            // are we even clickign?
            if(Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                // where is the cursor?
                int mouseX = Raylib.GetMouseX();
                int mouseY = Raylib.GetMouseY();

                // is the cursor within the confines of the button?
                if(mouseX > position.x &&           // left bound
                   mouseX < position.x + size.x &&  // right bound
                   mouseY > position.y &&           // top bound
                   mouseY < position.y + size.y)    // bottom bound
                {
                    IsClicked = true;
                }
            }
            else
            {
                IsClicked = false;
            }


        }

        public override void Draw()
        {
            base.Draw();

            Color currentColor = IsClicked ? new Color(clickColour.Red, clickColour.Green, clickColour.Blue, clickColour.Alpha) :
                                             new Color(normalColour.Red, normalColour.Green, normalColour.Blue, normalColour.Alpha);
                                             

            Raylib.DrawRectangle((int)position.x, (int)position.y,
                                 (int)size.x, (int)size.y,
                                 currentColor);
        }
    }
}
