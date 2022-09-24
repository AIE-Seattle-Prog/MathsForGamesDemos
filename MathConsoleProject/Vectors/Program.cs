using Vectors;

using Raylib_cs;

using MathLibrary;


public class Program
{
    public static Enemy enemy = new Enemy();

    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        // initialize objects in the game
        List<GameObject> gameObjects = new List<GameObject>();
        gameObjects.Add(new GameObject());
        gameObjects.Add(new Player());
        gameObjects.Add(enemy);

        enemy.position = new Vector3(200, 50, 0);
        enemy.direction = new Vector3(1, 1, 0).Normalized;

        Ball ball = new Ball();
        ball.velocity = new Vector3(15, 30, 0);

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update
            foreach(GameObject gObj in gameObjects)
            {
                gObj.Update();
            }
            ball.Update();

            // Draw
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            foreach (GameObject gObj in gameObjects)
            {
                gObj.Draw();
            }
            ball.Draw();

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}