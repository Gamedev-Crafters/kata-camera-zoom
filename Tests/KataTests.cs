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
    }
}

internal class Camera
{
    internal static Camera fromProjected(Bounds2 red_thing, Bounds2 expected_red_thing)
    {
        throw new NotImplementedException();
    }

    internal Bounds2 toScreenCoords(Bounds2 red_thing)
    {
        throw new NotImplementedException();
    }

    internal Vector2 toScreenCoords(Vector2 red_thing)
    {
        throw new NotImplementedException();
    }
}