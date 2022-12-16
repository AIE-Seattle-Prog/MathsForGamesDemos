using System;
using System.Collections.Generic;

using Raylib_cs;

using MathLibrary;
using GameFramework;

using Random = MathLibrary.Random;

namespace Matrix
{
    /// <summary>
    /// 
    /// </summary>
    public class Monster : SpriteObject
    {
        /// <summary>
        /// 
        /// </summary>
        public Vector3 velocity;

        /// <summary>
        /// Linear drag models the loss of energy due to other forces, such as air resistance.
        /// <para>The greater this value, the harder it will be to move this object and the faster
        /// it will slow down, if moving.</para>
        /// </summary>
        public float drag = 1;

        protected override void OnUpdate(float deltaTime)
        {
            //
            // MOVEMENT INPUT
            // 

            // check for key input and move when detected
            float xMove = 0.0f;
            float yMove = 0.0f;

            // A-D for LEFT-RIGHT movement
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                xMove -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                xMove += 1;
            }

            // W-S for UP-DOWN movement
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                yMove -= 1;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                yMove += 1;
            }

            // build user input vector
            Vector3 moveInput = new Vector3(xMove, yMove, 0);
            moveInput = Vector3.ClampMagnitude(moveInput, 1);

            // create acceleration - the amount by which we are changing our velocity
            const float ACCEL_SPEED = 75.0f;
            Vector3 acceleration = moveInput * ACCEL_SPEED;

            // integrating acceleration into velocity
            velocity += acceleration * deltaTime;

            // apply drag - integrate drag into the equation (modelling air resistances)
            velocity *= 1.0f - deltaTime * drag;

            // apply the move! - integrate velocity into position
            LocalPosition = LocalPosition + velocity * deltaTime;

            //
            // GAMEPLAY INPUTS
            //

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

            // F for Spawn Minion
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
            {
                GameObject minion = GameObjectFactory.MakeSprite("res/chort.png");
                minion.LocalPosition = new Vector3( Random.Range(-40,40) , Random.Range(-40, 40), 1);
                minion.Parent = this;
            }
        }
    }
}
