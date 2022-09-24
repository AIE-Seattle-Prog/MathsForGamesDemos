using Raylib_cs;

using System.Numerics;

public class Program
{
    public static void DrawCircle(int centerX, int centerY, int radius, Color color, int lineSegments = 24)
    {
        // angle between each corner of the circle
        float stepSize = (MathF.PI *2 ) / lineSegments;

        // generate the "circle"
        for(int i = 0; i < lineSegments; i++)
        {
            // first point
            int startX = (int)(radius * MathF.Cos(stepSize * i));
            int startY = (int)(radius * MathF.Sin(stepSize * i));

            // second point
            int endX = (int)(radius * MathF.Cos(stepSize * (i+1)));
            int endY = (int)(radius * MathF.Sin(stepSize * (i+1)));

            Raylib.DrawLine(startX + centerX, startY + centerY,
                            endX + centerX, endY + centerY,
                            color);
        }
    }

    public static Vector2[] GetCirclePoints(Vector2 center, int radius, int lineSegments, float offset = 0.0f)
    {
        Vector2[] points = new Vector2[lineSegments];

        // angle between each corner of the circle
        float stepSize = (MathF.PI * 2) / lineSegments;

        // generate the "circle"
        for (int i = 0; i < lineSegments; i++)
        {
            // first point
            int startX = (int)(radius * MathF.Cos(stepSize * i + offset));
            int startY = (int)(radius * MathF.Sin(stepSize * i + offset));

            points[i].X = startX + center.X;
            points[i].Y = startY + center.Y;
        }

        return points;
    }

    public static int[] GetCirclePoints(int centerX, int centerY, int radius, int lineSegments, float offset = 0.0f)
    {
        int[] points = new int[lineSegments * 2];

        // angle between each corner of the circle
        float stepSize = (MathF.PI * 2) / lineSegments;

        // generate the "circle"
        for (int i = 0; i < lineSegments; i++)
        {
            // first point
            int startX = (int)(radius * MathF.Cos(stepSize * i + offset));
            int startY = (int)(radius * MathF.Sin(stepSize * i + offset));

            points[i * 2] = startX + centerX;
            points[i * 2 + 1] = startY + centerY;

            // 0 1
            // 2 3
            // 4 5
        }

        return points;
    }

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

            Vector2[] points = GetCirclePoints(new Vector2(200, 200), 60, 8, (float)Raylib.GetTime());

            // Draw
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.RAYWHITE);

            

            //Raylib.DrawTexture(texKoala, 100, 100, Color.WHITE);

            //Raylib.DrawRectangle((int)(rectXpos + offsetX), (int)(rectYpos + offsetY), 25, 25, Color.ORANGE);

            //Raylib.DrawCircleLines(screenW / 2, screenH / 2, 100.0f, Color.ORANGE);

            DrawCircle(200, 200, 60, Color.ORANGE);

            for (int i = 0; i < points.Length; ++i)
            {
                Raylib.DrawCircle((int)points[i].X,        // x-pos
                                  (int)points[i].Y,    // y-pos
                                  8,                    // radius
                                  Color.BLUE);          // color/tint
            }

            Raylib.EndDrawing();
        }

        // Deinitializing - UNLOAD THE THINGS
        Raylib.CloseWindow();

        return 0;
    }
}