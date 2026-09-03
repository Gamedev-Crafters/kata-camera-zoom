using System;
using System.Collections.Generic;
using System.Drawing;

class Game
{
    public static readonly string Title = "Camera Zoom Kata";
    public static readonly Vector2 InitialResolution = new Vector2(500, 500);

    public Game()
    {
    }

    public void Update()
    {
        // clear the screen
        Engine.DrawRectSolid(new Bounds2(Vector2.Zero, Engine.Resolution), Color.Gray);

        Bounds2 rect = new Bounds2(new Vector2(100, 100), new Vector2(200, 200));

        Color color = DoBoundsContainPoint(rect, Engine.MousePosition) ? Color.Orange : Color.Red;

        Engine.DrawRectSolid(rect, color);
    }

    internal static bool DoBoundsContainPoint(Bounds2 rect, Vector2 point)
    {
        Vector2 local_point = point - rect.Position;
        return local_point.X >= 0 && local_point.X <= rect.Size.X &&
            local_point.Y >= 0 && local_point.Y <= rect.Size.Y ;
    }
}
