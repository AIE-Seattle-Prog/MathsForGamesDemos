using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;

namespace Vectors
{
    public class Ball : GameObject
    {
        /// <summary>
        /// Movement expressed in units per second
        /// </summary>
        public Vector3 velocity;

        public override void Update()
        {
            base.Update();

            position += velocity * Raylib.GetFrameTime();
        }
    }
}
