using Raylib_cs;

public class Program
{
    public static int Main()
    {
        // Initializing - LOAD THE THINGS
        const int screenW = 800;
        const int screenH = 450;

        Raylib.InitWindow(screenW, screenH, "Trigoraylib");
        Raylib.SetTargetFPS(60);

        Texture2D texKoala = Raylib.LoadTexture(@"res/koala.png");

        float rectXpos = screenW / 2;
        float rectYpos = screenH / 2;

        float angle = 0.0f;

        // Game Loop - PLAY THE GAME
        while (!Raylib.WindowShouldClose())
        {
            angle += Raylib.GetFrameTime() * 4;

            float offsetX = 90 * MathF.Sin(angle);
            //offsetX = 0;
            float offsetY = 90 * MathF.Cos(angle);
            //offsetY = 0;

            // Draw
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            Raylib.DrawTexture(texKoala, 100, 100, Color.WHITE);

            Raylib.DrawRectangle((int)(rectXpos + offsetX), (int)(rectYpos + offsetY), 25, 25, Color.ORANGE);

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}