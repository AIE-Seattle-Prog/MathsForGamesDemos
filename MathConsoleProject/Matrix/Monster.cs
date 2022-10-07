using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;
using GameFramework;

namespace Matrix
{
    public class Monster : GameObject
    {
        public Texture2D monsterSprite;

        protected override void OnUpdate(float deltaTime)
        {
            // check for key input and move when detected
            float xMove = 0.0f;
            float yMove = 0.0f;

            const float MOVESPEED = 20.0f;

            // A-D for LEFT-RIGHT movement
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                xMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                xMove += MOVESPEED * deltaTime;
            }

            // W-S for UP-DOWN movement
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                yMove -= MOVESPEED * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                yMove += MOVESPEED * deltaTime;
            }

            // apply the move!
            Translate(xMove, yMove);

            // F for Spawn Minion
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                GameObject minion = GameObjectFactory.MakeSprite("res/chort.png");
                minion.LocalPosition = LocalPosition;

                Program.Instantiate(minion);
            }
        }

        protected override void OnDraw()
        {
            // calculate the local transform matrix
            Matrix3 myTransform = LocalTransform;

            // extract the position
            Vector3 pos = myTransform.GetTranslation();

            // draw the monster sprite
            Raylib.DrawTexture(monsterSprite, (int)pos.x, (int)pos.y, Color.WHITE);
        }
    }
}
