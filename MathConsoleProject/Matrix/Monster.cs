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
    public class Monster : SpriteObject
    {
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

            // Q-E for CCW and CW (the rotation)
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                LocalRotation += 5.0f * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                LocalRotation -= 5.0f * deltaTime;
            }

            // 1-3 for SHRINK and GROW (the scale)
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
            {
                LocalScale -= new Vector3(2.0f, 2.0f, 2.0f) * deltaTime;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_THREE))
            {
                LocalScale += new Vector3(2.0f, 2.0f, 2.0f) * deltaTime;
            }

            // apply the move!
            Translate(xMove, yMove);

            // F for Spawn Minion
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                GameObject minion = GameObjectFactory.MakeSprite("res/chort.png");
                minion.LocalPosition = LocalPosition;

                Program.AddRootGameObject(minion);
            }
        }
    }
}
