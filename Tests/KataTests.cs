using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void ExampleTestDoBoundsContainPoint()
    {
        var bounds = new Bounds2(Vector2.Zero, new Vector2(1, 1));
        var point = new Vector2(0.5f, 0.5f);
        var result = Game.DoBoundsContainPoint(bounds, point);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IdealGoal()
    {
        Vector2 red_thing_center = new(0, 0);
        Vector2 red_thing_size = new(1, 1);
        Bounds2 red_thing = new(red_thing_center, red_thing_size);
        Bounds2 expected_red_thing = new(new Vector2(0.2f, 0.5f), new Vector2(0.1f, 0.1f));
        Camera camera = Camera.fromProjected(red_thing, expected_red_thing);
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(expected_red_thing));
        Vector2 cursor = new(-1, 0);
        Assert.That(camera.toScreenCoords(cursor), Is.EqualTo(new Vector2(0.1f, 0.5f)));
        // zoom in
        expected_red_thing = new(new Vector2(0.5f, 0.5f), new Vector2(0.8f, 0.8f));
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(expected_red_thing));
    }

    [Test]
    public void IdealGoal2()
    {
        Vector2 red_thing_center = new(0, 0);
        Vector2 red_thing_size = new(1, 1);
        Bounds2 red_thing = new(red_thing_center, red_thing_size);
        Bounds2 expected_red_thing = new(new Vector2(0.5f, 0.5f), new Vector2(0.8f, 0.8f));
        Camera camera = Camera.fromProjected(red_thing, expected_red_thing);
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(expected_red_thing));
        Vector2 cursor = new(1, 0);
        Assert.That(camera.toScreenCoords(cursor), Is.EqualTo(new Vector2(0.9f, 0.5f)));
        // zoom out
        expected_red_thing = new(new Vector2(0.2f, 0.5f), new Vector2(0.1f, 0.1f));
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(expected_red_thing));
    }

    [Test]
    public void CreateCameraFromProjected()
    {
        Vector2 red_thing_center = new(0, 0);
        Vector2 red_thing_size = new(1, 1);
        Bounds2 red_thing = new(red_thing_center, red_thing_size);
        Bounds2 expected_red_thing = new(new Vector2(0.2f, 0.5f), new Vector2(0.1f, 0.1f));
        Camera camera = Camera.fromProjected(red_thing, expected_red_thing);
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(expected_red_thing));
    }

    [Test]
    public void CreateCameraFromProjectedIntoFullscreen()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 fullscreen = new(new Vector2(0, 0), new Vector2(1, 1));
        Camera camera = Camera.fromProjected(red_thing, fullscreen);
        Assert.That(camera.toScreenCoords(red_thing), Is.EqualTo(fullscreen));
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(1,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoFullscreenAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 fullscreen = new(new Vector2(0, 0), new Vector2(1, 1));
        Camera camera = Camera.fromProjected(red_thing, fullscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(1,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoHalfscreenAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 halfscreen = new(new Vector2(0, 0), new Vector2(0.5f, 1));
        Camera camera = Camera.fromProjected(red_thing, halfscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(0.5f,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoRightHalfscreenAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 halfscreen = new(new Vector2(0.5f, 0), new Vector2(0.5f, 1));
        Camera camera = Camera.fromProjected(red_thing, halfscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0.5f,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(1,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoMiddleHalfscreenAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 halfscreen = new(new Vector2(0.25f, 0), new Vector2(0.5f, 1));
        Camera camera = Camera.fromProjected(red_thing, halfscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0.25f,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(0.75f,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoSmallsreenAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 fullscreen = new(new Vector2(0, 0), new Vector2(0.8f, 1));
        Camera camera = Camera.fromProjected(red_thing, fullscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(0.8f,1)));
    }

    [Test]
    public void CreateCameraFromProjectedIntoSmallsreenRightAndCheckOnlyPos()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 fullscreen = new(new Vector2(0.1f, 0), new Vector2(0.8f, 1));
        Camera camera = Camera.fromProjected(red_thing, fullscreen);
        Assert.That(camera.toScreenCoords(red_thing.Position), Is.EqualTo(new Vector2(0.1f,0)));
        Assert.That(camera.toScreenCoords(red_thing.Position + red_thing.Size), Is.EqualTo(new Vector2(0.9f,1)));
    }
}

internal class Camera
{
    Bounds2 world_seen;

    public Camera(Bounds2 world_seen)
    {
        this.world_seen = world_seen;
    }

    internal static Camera fromProjected(Bounds2 thing_in_world_coords, Bounds2 thing_in_camera_coords)
    {
        if (thing_in_camera_coords.Equals(new Bounds2(new Vector2(0,0), new Vector2(1,1))))
        {
            return new Camera(thing_in_world_coords);
        }
        // if (thing_in_camera_coords.Equals(new Bounds2(new Vector2( <x>, 0), new Vector2(0.5f,1))))  <-- my ideal code
        if (thing_in_camera_coords.Size.Equals(new Vector2(0.5f,1)) && thing_in_camera_coords.Position.Y == 0)
        {
            float x = thing_in_camera_coords.Position.X;
            return new Camera(new Bounds2(
                thing_in_world_coords.Position - new Vector2(thing_in_world_coords.Size.X * (x / 0.5f), 0), 
                new Vector2(thing_in_world_coords.Size.X / 0.5f, thing_in_world_coords.Size.Y)
            ));
        }
        if (thing_in_camera_coords.Size.Equals(new Vector2(0.8f,1)) && thing_in_camera_coords.Position.Y == 0)
        {
            float x = thing_in_camera_coords.Position.X;
            return new Camera(new Bounds2(
                thing_in_world_coords.Position - new Vector2(thing_in_world_coords.Size.X * (x / 0.8f), 0), 
                new Vector2(thing_in_world_coords.Size.X / 0.8f, thing_in_world_coords.Size.Y)
            ));
        }
        throw new NotImplementedException();
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
}