using Raylib_cs;

using GameFramework;

using Matrix;

public class Program
{
    private static List<GameObject> gameObjects = new List<GameObject>();
    private static List<GameObject> pendingObjects = new List<GameObject>();
    private static List<GameObject> killObjects = new List<GameObject>();

    public static void Instantiate(GameObject newGameObject)
    {
        pendingObjects.Add(newGameObject);
    }

    public static void Destroy(GameObject toDestroy)
    {
        killObjects.Remove(toDestroy);
    }

    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Raylib");
        Raylib.SetTargetFPS(60);

        // INITIALIZE GAMEPLAY
        gameObjects.Add(GameObjectFactory.MakeMonster());

        bool isPaused = false;

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update GAMEPLAY
            if(Raylib.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
            {
                isPaused = !isPaused;
            }

            // Update all current objects
            if (!isPaused)
            {
                foreach (var go in gameObjects)
                {
                    go.Update(Raylib.GetFrameTime());
                }
            }

            // Draw GAMEPLAY
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            // Draw all current objects
            foreach (var go in gameObjects)
            {
                go.Draw();
            }

            Raylib.EndDrawing();

            // Process PENDING OBJECTS

            // Remove all objects that are marked for destroy
            foreach(var kill in killObjects)
            {
                gameObjects.Remove(kill);
            }
            killObjects.Clear();

            // Add all objects that are waiting to be alive
            foreach(var pending in pendingObjects)
            {
                gameObjects.Add(pending);
            }
            pendingObjects.Clear();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}
