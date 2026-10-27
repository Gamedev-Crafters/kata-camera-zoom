using System;
using System.Collections.Generic;
using System.Drawing;

class Game
{
    public static readonly string Title = "Camera Zoom Kata";
    public static readonly Vector2 InitialResolution = new Vector2(500, 500);

    Bounds2 red_thing = new(new Vector2(0, 0), new Vector2(1, 1));
    Camera camera = Camera.fromProjected(
        new(new Vector2(0, 0), new Vector2(1, 1)),
        new(new Vector2(0.25f, 0.25f), new Vector2(0.5f, 0.5f))
    );

    public Game()
    {
    }

    public void Update()
    {
        // clear the screen
        Engine.DrawRectSolid(new Bounds2(Vector2.Zero, Engine.Resolution), Color.Gray);

        Vector2 cursor = this.camera.toWorldCoords(new Vector2(
            Engine.MousePosition.X / Engine.Resolution.X,
            Engine.MousePosition.Y / Engine.Resolution.Y
        ));

        Color color = DoBoundsContainPoint(this.red_thing, cursor) ? Color.Orange : Color.Red;

        camera = camera.zoomAtCursor(cursor, 1, (float)Math.Pow(1.1f, Engine.MouseScroll));

        drawRectSolid(this.camera, this.red_thing, color);
    }

    private static void drawRectSolid(Camera camera, Bounds2 rect, Color color)
    {
        Bounds2 relative = camera.toScreenCoords(rect);
        
        Engine.DrawRectSolid(new Bounds2(
            new Vector2(
                Engine.Resolution.X * relative.Position.X, 
                Engine.Resolution.Y * relative.Position.Y
            ),
            new Vector2(
                Engine.Resolution.X * relative.Size.X, 
                Engine.Resolution.Y * relative.Size.Y
            )
        ), color);
    }

    internal static bool DoBoundsContainPoint(Bounds2 rect, Vector2 point)
    {
        Vector2 local_point = point - rect.Position;
        return local_point.X >= 0 && local_point.X <= rect.Size.X &&
            local_point.Y >= 0 && local_point.Y <= rect.Size.Y ;
    }
}

class Camera
{
    Bounds2 world_seen;

    public Camera(Bounds2 world_seen)
    {
        this.world_seen = world_seen;
    }

    internal static Camera fromProjected(Bounds2 thing_in_world_coords, Bounds2 thing_in_camera_coords)
    {
        float x_size = thing_in_camera_coords.Size.X;
        float x_pos = thing_in_camera_coords.Position.X;
        float y_size = thing_in_camera_coords.Size.Y;
        float y_pos = thing_in_camera_coords.Position.Y;
        return new Camera(new Bounds2(
            thing_in_world_coords.Position - new Vector2(thing_in_world_coords.Size.X * (x_pos / x_size), thing_in_world_coords.Size.Y * (y_pos / y_size)), 
            new Vector2(thing_in_world_coords.Size.X / x_size, thing_in_world_coords.Size.Y / y_size)
        ));
    }

    internal Bounds2 toScreenCoords(Bounds2 rect)
    {
        Vector2 top_left = this.toScreenCoords(rect.Position);
        Vector2 bottom_right = this.toScreenCoords(rect.Position + rect.Size);
        return Bounds2.fromCorners(top_left, bottom_right); 
    }

    internal Vector2 toScreenCoords(Vector2 pos)
    {
        Vector2 centered = pos - this.world_seen.Position;
        return new(
            centered.X / this.world_seen.Size.X,
            centered.Y / this.world_seen.Size.Y
        );
    }

    internal Vector2 toWorldCoords(Vector2 screen_pos)
    {
        return this.world_seen.Position + new Vector2(
            screen_pos.X * this.world_seen.Size.X,
            screen_pos.Y * this.world_seen.Size.Y
        );
    }


    internal Camera zoomAtCursor(Vector2 cursor_world_pos, float old_relative_size, float new_relative_size)
    {
        Vector2 old_relative_cursor = this.toScreenCoords(cursor_world_pos);
        Bounds2 cursor = Bounds2.fromCorners(cursor_world_pos, this.toWorldCoords(old_relative_cursor + new Vector2(old_relative_size, old_relative_size)));
        return fromProjected(
            cursor,
            new Bounds2(old_relative_cursor, new Vector2(new_relative_size, new_relative_size))
        );
    }
}