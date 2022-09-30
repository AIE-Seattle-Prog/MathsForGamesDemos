using Raylib_cs;

using Random_ClickTheCircles;

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

        GameState currentGameState = new GameLoopState();

        currentGameState.Start();

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            // Update
            currentGameState.Update();

            // Draw
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            currentGameState.Draw();

            Raylib.EndDrawing();

            // Manage the Current Game State
            if(currentGameState.StateShouldChange())
            {
                GameStates nextGameState = currentGameState.GetNextGameState();

                // instantiating the next state
                switch(nextGameState)
                {
                    case GameStates.GameLoop:
                        currentGameState = new GameLoopState();
                        break;
                    case GameStates.EndScreen:
                        currentGameState = new EndScreenState();
                        break;
                }

                currentGameState.Start();
            }
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}
