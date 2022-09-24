using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace Vectors
{
    public class Enemy : GameObject
    {
        public bool isAlive = true;

        public override void Update()
        {
            base.Update();

            direction.x = MathF.Cos((float)Raylib.GetTime());
            direction.y = MathF.Sin((float)Raylib.GetTime());
        }

        public override void Draw()
        {
            if(!isAlive) { return; }
            base.Draw();
        }
    }
}
