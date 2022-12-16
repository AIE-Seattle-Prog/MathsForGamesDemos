# Matrix Demo

The Matrix project is a sample that demonstrates the applicability of the work
we've done in the Maths for Games subject. Thus far, we've completed the
following work:

1. **Math Library** - providing support for Vectors and Matrices
2. **Unit Tests** - validating the proper operation of the types exposed in the math library

Using our math library, we can create a `GameObject` type that uses matrices to
store transform information that about the position, rotation, and scale of each
object in the game. These `GameObject` objects can be "parented" to each other,
allowing a "child" object to inherit the transform information of its parent
as well as its own transform information on top of that.

## Gameplay Framework

The Gameplay Framework exposes a set of common types that can be inherited from
or directly used to implement certain behaviors in a game.

- **GameObject** (base type for all game objects)
    - **SpriteObject** (a simple game object that draws a 2D sprite)

These classes are intended to be portable and able to be used in other projects
using the AIE Math Library to create new games, such as a Tank simulation.

### Program

In addition, the `Program` object contains some basic static methods,
`Program.AddRootGameObject` and `Program.Destroy` that allow for the addition
and removal of GameObjects from the list of root `GameObject` instances that
will be iterated upon when updating and drawing the game.

## Extending the Gameplay Framework

This demo project builds on the Gameplay Framework, contributing two additional
classes to the program:

- **HoverCircle** (a circle that changes colors)
    - inherits from `GameObject`
- **Monster** (a user-controllable character)
    - inherits from `SpriteObject`

As objects that directly or indirectly inherit from `GameObject`, these types
are able to be added to the list of root GameObjects stored in `Program` and
can be updated and drawn in the game loop.

## Potential Improvements

1. Refactor `Program.DestroyRootGameObject` to allow destroying any game object, root or not
2. Simplify API for creating new objects, root or not
3. Add APIs to GameObject that allow programmers to react to object startup/destruction
