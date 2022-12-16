using System;
using System.Collections.Generic;

using MathLibrary;

namespace GameFramework
{
    /// <summary>
    /// Base type for all objects that exist in the game.
    /// </summary>
    public class GameObject
    {
        public Vector3 LocalPosition { get; set; } = new Vector3(0, 0, 1);
        public float LocalRotation { get; set; }
        public Vector3 LocalScale { get; set; } = new Vector3(1, 1, 1);

        /// <summary>
        /// Read-only access to the World-space position of this object
        /// </summary>
        public Vector3 WorldPosition
        {
            get
            {
                return GlobalTransform.GetTranslation();
            }
        }
        
        /// <summary>
        /// Read-only access to the World-space rotation of this object
        /// </summary>
        public float WorldRotation
        {
            get
            {
                Matrix3 transform = GlobalTransform;
                return MathF.Atan2(transform.m2, transform.m1);
            }
        }
        
        /// <summary>
        /// Read-only access to the World-space scale of this object
        /// </summary>
        public Vector3 WorldScale
        {
            get
            {
                Matrix3 transform = GlobalTransform;
                return new Vector3(new Vector3(transform.m1, transform.m2, transform.m3).Magnitude,
                                  new Vector3(transform.m4, transform.m5, transform.m6).Magnitude,
                                  1);
            }
        }

        protected GameObject parent = null;
        /// <summary>
        /// Get/set the parent object for this game object.
        /// </summary>
        public GameObject Parent
        {
            get => parent;
            set
            {
                // remove from existing parent if applicable
                if(parent != null)
                {
                    parent.children.Remove(this);
                }

                // add to our new parent if applicable
                if(value != null)
                {
                    value.children.Add(this);
                }

                parent = value;
            }
        }

        protected List<GameObject> children = new List<GameObject>();
        /// <summary>
        /// The number of children who have this object as its parent.
        /// </summary>
        public int ChildCount
        {
            get
            {
                return children.Count;
            }
        }
        /// <summary>
        /// Retrieves a specific child object.
        /// </summary>
        /// <param name="index">The index of the child</param>
        /// <returns></returns>
        public GameObject GetChild(int index)
        {
            return children[index];
        }

        /// <summary>
        /// The transformation matrix representing its position, rotation, and scale
        /// in local-space.
        /// </summary>
        public Matrix3 LocalTransform
        {
            get
            {
                return Matrix3.CreateTranslation(LocalPosition) *
                       Matrix3.CreateRotateZ(LocalRotation) *
                       Matrix3.CreateScale(LocalScale.x, LocalScale.y);
            }
        }

        /// <summary>
        /// The transformation matrix representing its position, rotation, and scale
        /// in world-space.
        /// <para>
        /// This is affected by parent objects and their parents, if any.
        /// </para>
        /// </summary>
        public Matrix3 GlobalTransform
        {
            get
            {
                // if we have a parent...
                if(parent != null)
                {
                    return parent.GlobalTransform * LocalTransform;
                }
                else
                {
                    return LocalTransform;
                }
            }
        }

        /// <summary>
        /// Moves the object by the given amount, in addition
        /// to its existing position.
        /// </summary>
        /// <param name="x">Movement on the X-axis.</param>
        /// <param name="y">Movement on the Y-axis.</param>
        public void Translate(float x, float y)
        {
            LocalPosition += new Vector3(x, y, 0);
        }

        /// <summary>
        /// Rotates the object by the given amount, in addition to
        /// its existing rotation.
        /// </summary>
        /// <param name="rotRadians">The amount to rotate by, given in radians.</param>
        public void Rotate(float rotRadians)
        {
            LocalRotation += rotRadians;
        }

        /// <summary>
        /// Scales the object additively, adding to the scalar value on each axis.
        /// </summary>
        /// <param name="xScaler">Additional scaling on the X-axis.</param>
        /// <param name="yScaler">Additional scaling on the Y-axis.</param>
        public void Scale(float xScaler, float yScaler)
        {
            LocalScale += new Vector3(xScaler, yScaler, 0);
        }

        // 
        // Gameplay Systems
        // 

        /// <summary>
        /// Updates this GameObject and recursively updates all of its children.
        /// </summary>
        /// <param name="deltaTime">The amount of time passed since the last update.</param>
        public void Update(float deltaTime)
        {
            // TODO: if we had more stuff to do on Update, we'd do it here ...
            OnUpdate(deltaTime);

            foreach(var child in children)
            {
                child.Update(deltaTime);
            }
        }

        /// <summary>
        /// To be overridden by child classes of GameObject to implement class-specific update behavior.
        /// </summary>
        /// <param name="deltaTime">The amount of time passed since the last update.</param>
        protected virtual void OnUpdate(float deltaTime)
        {
            // left intentionally blank - override this to add your own gameplay logic
        }

        /// <summary>
        /// Draws this GameObject and recursively draws all of its children.
        /// </summary>
        public void Draw()
        {
            // TODO: if we had more stuff to do on Draw, we'd do it here ...
            OnDraw();

            foreach(var child in children)
            {
                child.Draw();
            }
        }

        /// <summary>
        /// To be overridden by child classes of GameObject to implement class-specific draw behavior.
        /// </summary>
        protected virtual void OnDraw()
        {
            // left intentionally blank - override this to add your own drawing logic
        }

        // TODO: Implement hooks for startup and destruction
        //       (i.e. analogous to Unity's Start() and OnDestroy())
    }
}
