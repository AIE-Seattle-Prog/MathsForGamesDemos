using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace Vectors
{
    public class Player : GameObject
    {
        public override void Update()
        {
            base.Update();

            // test for key input and move if down
            if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.y -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.y += 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                position.x -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                position.x += 1;
            }

            // wrapping the position of the player around the screen
            if(position.x < 0)
            {
                position.x = Raylib.GetScreenWidth();
            }
            if (position.x > Raylib.GetScreenWidth())
            {
                position.x = 0;
            }
            if (position.y < 0)
            {
                position.y = Raylib.GetScreenHeight();
            }
            if (position.y > Raylib.GetScreenHeight())
            {
                position.y = 0;
            }

            // attempt backstab
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                float dotted = direction.Dot(Program.enemy.direction);

                if(dotted > 0)
                {
                    Program.enemy.isAlive = false;
                }

                Console.WriteLine(dotted);
            }
        }
    }
}
