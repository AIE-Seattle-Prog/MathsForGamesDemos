using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;

namespace Vectors
{
    /// <summary>
    /// Base type for all objects that exist in the game
    /// </summary>
    public class GameObject
    {
        public Vector3 position;

        public Vector3 direction = new Vector3(1, 0, 0);

        /// <summary>
        /// Called once per frame to update gameplay logic
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Called once per frame during the draw loop
        /// </summary>
        public virtual void Draw()
        {
            Raylib.DrawCircle((int)position.x, (int)position.y, 5, Color.MAGENTA);

            Vector3 endDirection = position + direction * 15.0f;
            Raylib.DrawLine((int)position.x, (int)position.y, (int)endDirection.x, (int)endDirection.y, Color.RED);
        }
    }
}
