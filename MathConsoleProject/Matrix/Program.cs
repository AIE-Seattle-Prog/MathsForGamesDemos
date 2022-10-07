using Raylib_cs;

using GameFramework;

using Matrix;

public class Program
{
    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        // INITIALIZE GAMEPLAY
        Monster testObject = new Monster();
        testObject.monsterSprite = Raylib.LoadTexture("res/monster.png");

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update GAMEPLAY
            testObject.Update(Raylib.GetFrameTime());

            // Draw GAMEPLAY
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            testObject.Draw();

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}
