using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

using MathLibrary;

namespace GameFramework
{
    /// <summary>
    /// Base type for all objects that exist in the game
    /// </summary>
    public class GameObject
    {
        public Vector3 LocalPosition { get; set; }
        public float LocalRotation { get; set; }
        public Vector3 LocalScale { get; set; }

        public Matrix3 LocalTransform
        {
            get
            {
                return Matrix3.CreateTranslation(LocalPosition) *
                       Matrix3.CreateRotateZ(LocalRotation) *
                       Matrix3.CreateScale(LocalScale.x, LocalScale.y);
            }
        }

        public void Translate(float x, float y)
        {
            LocalPosition += new Vector3(x, y, 0);
        }

        public void Rotate(float rot)
        {
            LocalRotation += rot;
        }

        public void Scale(float xScaler, float yScaler)
        {
            LocalScale += new Vector3(xScaler, yScaler, 0);
        }

        // 
        // Gameplay Systems
        // 

        // FOR ENGINE USE - infrastructure etc. etc.
        public void Update(float deltaTime)
        {
            // TODO: if we had more stuff to do on Update, we'd do it here ...
            OnUpdate(deltaTime);
        }

        // FOR GAMEPLAY USE - gameplay mechanics
        protected virtual void OnUpdate(float deltaTime)
        {
            // TODO - override this in your types
        }

        public void Draw()
        {
            // TODO: if we had more stuff to do on Draw, we'd do it here ...
            OnDraw();
        }

        protected virtual void OnDraw()
        {
            // TODO - override this in your types
        }
    }
}
