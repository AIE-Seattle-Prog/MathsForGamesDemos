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

        public Vector3 origin = new Vector3(0.5f, 0.5f, 0.5f);

        protected override void OnDraw()
        {
            // calculate the local transform matrix
            Matrix3 myTransform = GlobalTransform;

            // extract the position
            Vector3 pos = myTransform.GetTranslation();
            float   rot = MathF.Atan2(myTransform.m2, myTransform.m1) * MathUtils.Rad2Deg;
            Vector3 scl = new Vector3(new Vector3(myTransform.m1, myTransform.m2, myTransform.m3).Magnitude,
                                      new Vector3(myTransform.m4, myTransform.m5, myTransform.m6).Magnitude,
                                      1);

            // draw the monster sprite
            Raylib.DrawTexturePro(sprite,
                                  new Rectangle(0, 0, sprite.width, sprite.height),
                                  new Rectangle(pos.x, pos.y, sprite.width * scl.x, sprite.height * scl.y),
                                  new System.Numerics.Vector2(
                                      sprite.width * scl.x * origin.x,
                                      sprite.height * scl.y * origin.y
                                  ),
                                  rot,
                                  Color.WHITE);

            //Raylib.DrawCircle((int)pos.x, (int)pos.y, 5.0f, Color.RED);
        }
    }
}
