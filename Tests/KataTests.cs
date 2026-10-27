using System.Runtime.Intrinsics.Arm;
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
    public void CreateCameraFromProjected()
    {
        Vector2 red_thing_topleft = new(0, 0);
        Vector2 red_thing_size = new(1, 1);
        Bounds2 red_thing = new(red_thing_topleft, red_thing_size);
        Bounds2 expected_red_thing = new(new Vector2(0.2f, 0.5f), new Vector2(0.1f, 0.1f));
        Camera camera = Camera.fromProjected(red_thing, expected_red_thing);
        AssertBoundsEqual(camera.toScreenCoords(red_thing), expected_red_thing);
    }

    [Test]
    public void CreateCameraFromProjectedIntoFullscreen()
    {
        // red_thing could be any random value
        Bounds2 red_thing = new(new Vector2(1, 2), new Vector2(3, 4));
        Bounds2 fullscreen = new(new Vector2(0, 0), new Vector2(1, 1));
        Camera camera = Camera.fromProjected(red_thing, fullscreen);
        AssertBoundsEqual(camera.toScreenCoords(red_thing), fullscreen);
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

    [Test]
    public void ZoomInSimplest()
    {
        Camera camera = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        camera = camera.zoomAtCursor(new Vector2(0, 0), 1, 0.5f);
        Assert.That(camera.toScreenCoords(new Vector2(0,0)), Is.EqualTo(new Vector2(0,0)));
        Assert.That(camera.toScreenCoords(new Vector2(1,1)), Is.EqualTo(new Vector2(0.5f,0.5f)));
    }

    [Test]
    public void ZoomGeneral()
    {
        // seen_world could be any random value
        Bounds2 seen_world = new(new Vector2(1, 2), new Vector2(3, 4));
        // cursor could be any random value
        Vector2 cursor = new(5, 6);
        Camera camera = new(seen_world);
        Vector2 old_relative_cursor = camera.toScreenCoords(cursor);
        // zoom values could be any random values
        camera = camera.zoomAtCursor(cursor, 7, 8);
        Vector2 new_relative_cursor = camera.toScreenCoords(cursor);
        Assert.That(old_relative_cursor, Is.EqualTo(new_relative_cursor));
    }

    private static void AssertBoundsEqual(Bounds2 actual, Bounds2 expected)
    {
        Assert.That(actual.Position.X, Is.EqualTo(expected.Position.X).Within(0.000001f));
        Assert.That(actual.Position.Y, Is.EqualTo(expected.Position.Y).Within(0.000001f));
        Assert.That(actual.Size.X, Is.EqualTo(expected.Size.X).Within(0.000001f));
        Assert.That(actual.Size.Y, Is.EqualTo(expected.Size.Y).Within(0.000001f));
    }
}
