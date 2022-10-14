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
    class HoverCircle : GameObject
    {
        public float radius = 25.0f;

        public Color normalColor = Color.GRAY;
        public Color hoverColor = Color.RED;

        private bool isHovering;

        protected override void OnUpdate(float deltaTime)
        {
            base.OnUpdate(deltaTime);

            Matrix3 global = GlobalTransform;
            Vector3 worldPos = global.GetTranslation();

            isHovering = CollisionTests.CirclePointTest(worldPos, radius, new Vector3(Raylib.GetMouseX(), Raylib.GetMouseY(), worldPos.z));
        }

        protected override void OnDraw()
        {
            base.OnDraw();

            Matrix3 global = GlobalTransform;

            Vector3 worldPos = global.GetTranslation();

            // TODO: radius does not currently consider scale
            Raylib.DrawCircle((int)worldPos.x, (int)worldPos.y, radius, isHovering ? hoverColor : normalColor);
        }
    }
}
