using System;
using Raylib_cs;

using GameFramework;
using MathLibrary;

public class Program
{
    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        Button testButton = new Button();
        testButton.position = new Vector3(200, 200);
        testButton.size = new Vector3(150, 50);

        System.Random random = new System.Random();

        int rngMin = 0;
        int rngMax = 100;

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update
            testButton.Update();

            int randomNumber = random.Next() % rngMax;

            Console.WriteLine(randomNumber);

            //if(testButton.IsClicked)
            //{
            //    Console.WriteLine("CLICK!!");
            //}
            //else
            //{
            //    Console.WriteLine("NOT CLICK!!");
            //}

            // Draw
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.GRAY);

            testButton.Draw();

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}
