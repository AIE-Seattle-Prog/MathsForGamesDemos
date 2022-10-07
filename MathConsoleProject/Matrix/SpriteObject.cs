using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameFramework;
using MathLibrary;
using Raylib_cs;

namespace Matrix
{
    public class SpriteObject : GameObject
    {
        public Texture2D sprite;

        protected override void OnDraw()
        {
            // calculate the local transform matrix
            Matrix3 myTransform = LocalTransform;

            // extract the position
            Vector3 pos = myTransform.GetTranslation();

            // draw the monster sprite
            Raylib.DrawTexture(sprite, (int)pos.x, (int)pos.y, Color.WHITE);
        }
    }
}
