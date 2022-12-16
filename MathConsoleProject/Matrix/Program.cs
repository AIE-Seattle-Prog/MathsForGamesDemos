using System;
using System.Collections.Generic;

using Raylib_cs;

using Matrix;
using GameFramework;

public class Program
{
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static List<GameObject> pendingObjects = new List<GameObject>();
    private static List<GameObject> killObjects = new List<GameObject>();

    /// <summary>
    /// Adds a GameObject as a root object in the Update-Draw loop.
    /// </summary>
    /// <param name="newGameObject">The object to add to list of all game objects in the game.</param>
    public static void AddRootGameObject(GameObject newGameObject)
    {
        pendingObjects.Add(newGameObject);
    }

    /// <summary>
    /// Queues a GameObject for removal from the Update-Draw loop.
    /// </summary>
    /// <param name="toDestroy"></param>
    public static void DestroyRootGameObject(GameObject toDestroy)
    {
        killObjects.Add(toDestroy);
    }

    public static int Main()
    {
        //
        // INITIALIZE Engine
        //
        const int screenW = 800;
        const int screenH = 450;

        bool isPaused = false;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        //
        // INITIALIZE Gameplay
        //
        GameObject monster = GameObjectFactory.MakeMonster();
        monster.LocalPosition = new MathLibrary.Vector3(screenW / 2, screenH / 2, 1);
        gameObjects.Add(monster);

        // PLAY THE GAME (Game Loop)
        while (!Raylib.WindowShouldClose())
        {
            //
            // UPDATE Gameplay
            //
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
            {
                isPaused = !isPaused;
            }

            // Add all objects that are waiting to be alive
            foreach (var pending in pendingObjects)
            {
                gameObjects.Add(pending);
            }
            pendingObjects.Clear();

            // Update all current objects - only if the game isn't paused
            if (!isPaused)
            {
                foreach (var go in gameObjects)
                {
                    go.Update(Raylib.GetFrameTime());
                }
            }

            // Remove all objects that are marked for destroy
            foreach (var kill in killObjects)
            {
                gameObjects.Remove(kill);
            }
            killObjects.Clear();

            //
            // DRAW Gameplay
            //
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            // Draw all current objects
            foreach (var go in gameObjects)
            {
                go.Draw();
            }

            Raylib.DrawText("WASD for Movement", 20, 10, 20, Color.BLACK);
            Raylib.DrawText("Q and E for Rotation", 20, 35, 20, Color.BLACK);
            Raylib.DrawText("1 and 3 for Scaling", 20, 60, 20, Color.BLACK);
            Raylib.DrawText("F to Spawn Child Minion", 20, 95, 20, Color.BLACK);

            Raylib.EndDrawing();
        }

        //
        // TERMINATE Engine
        //
        Raylib.CloseWindow();

        return 0;
    }
}
