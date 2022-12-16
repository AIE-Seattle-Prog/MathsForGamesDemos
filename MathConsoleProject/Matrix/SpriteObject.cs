using System;
using System.Collections.Generic;

using Raylib_cs;

using MathLibrary;

namespace GameFramework
{
    /// <summary>
    /// A simple type of GameObject capable of rendering a single sprite at its position with rotation and scaling.
    /// </summary>
    public class SpriteObject : GameObject
    {
        /// <summary>
        /// The sprite that will be drawn by this SpriteObject
        /// </summary>
        public Texture2D sprite;

        /// <summary>
        /// The tint applied to the sprite during rendering.
        /// 
        /// Defaults to "Color.WHITE" to render the sprite as-is.
        /// </summary>
        public Color tint = Color.WHITE;

        /// <summary>
        /// The point at which the sprite will be drawn and rotated around.
        /// 
        /// Given in normalized (0-1) space, where 0.5 is the middle of an axis.
        /// </summary>
        public Vector3 origin = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void OnDraw()
        {
            // calculate the global transform matrix
            Matrix3 myTransform = GlobalTransform;

            // cache each transform property so we only have to retrieve it once
            Vector3 pos = WorldPosition;
            float   rot = WorldRotation;
            Vector3 scl = WorldScale;

            // draw the monster sprite
            Raylib.DrawTexturePro(sprite,
                                  new Rectangle(0, 0, sprite.width, sprite.height),
                                  new Rectangle(pos.x, pos.y, sprite.width * scl.x, sprite.height * scl.y),
                                  new System.Numerics.Vector2(
                                      sprite.width * scl.x * origin.x,
                                      sprite.height * scl.y * origin.y
                                  ),
                                  rot * MathUtils.Rad2Deg,
                                  tint);

            // uncomment to show debug position
            //Raylib.DrawCircle((int)pos.x, (int)pos.y, 5.0f, Color.RED);
        }
    }
}
