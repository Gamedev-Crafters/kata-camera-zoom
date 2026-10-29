using System;
using System.Collections.Generic;
using System.Drawing;

class Game
{
    public static readonly string Title = "Camera Zoom Kata";
    public static readonly Vector2 InitialResolution = new Vector2(500, 500);

    Bounds2 red_thing = new(new Vector2(0, 0), new Vector2(1, 1));
    Camera camera = new (new Bounds2(-1, -1, 2, 2));

    public Game()
    {
    }

    public void Update()
    {
        // clear the screen
        Engine.DrawRectSolid(new Bounds2(Vector2.Zero, Engine.Resolution), Color.Gray);

        camera = camera.zoomAtCursor(Engine.MousePosition, (float)Math.Pow(1.1f, Engine.MouseScroll), Engine.Resolution);

        Bounds2 red_thing_in_pixels = camera.toPixelCoords(this.red_thing, Engine.Resolution);
        Engine.DrawRectSolid(red_thing_in_pixels, Color.Red);
    }
}

class Camera
{
    public Bounds2 world_seen;

    public Camera(Bounds2 world_seen)
    {
        this.world_seen = world_seen;
    }

    internal static Camera fromProjection(Bounds2 thing_in_world_coords, Bounds2 thing_in_pixels_coords, Vector2 resolution)
    {
        throw new NotImplementedException();
    }

    internal Bounds2 toPixelCoords(Bounds2 world_rect, Vector2 resolution)
    {
        Vector2 top_left = this.toPixelCoords(world_rect.Position, resolution);
        Vector2 bottom_right = this.toPixelCoords(world_rect.Position + world_rect.Size, resolution);
        return Bounds2.FromCorners(top_left, bottom_right); 
    }

    internal Vector2 toPixelCoords(Vector2 world_pos, Vector2 resolution)
    {
        throw new NotImplementedException();
    }

    internal Vector2 toWorldCoords(Vector2 pixel_pos, Vector2 resolution)
    {
        throw new NotImplementedException();
    }


    internal Camera zoomAtCursor(Vector2 cursor_pixel_pos, float zoom_amount, Vector2 resolution)
    {
        throw new NotImplementedException();
    }
}
