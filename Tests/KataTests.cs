using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void ToWorldCoords_1()
    {
        Camera camera = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        Vector2 pixel_pos = new (0, 0);
        Vector2 resolution = new(100, 100);

        Vector2 actual = camera.toWorldCoords(pixel_pos, resolution);

        Vector2 expected = new(0,0);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToWorldCoords_2()
    {
        Camera camera = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        Vector2 pixel_pos = new (100, 100);
        Vector2 resolution = new(100, 100);

        Vector2 actual = camera.toWorldCoords(pixel_pos, resolution);

        Vector2 expected = new(1,1);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToPixelCoords_1()
    {
        Camera camera = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        Vector2 world_pos = new (0, 0);
        Vector2 resolution = new(100, 100);

        Vector2 actual = camera.toPixelCoords(world_pos, resolution);

        Vector2 expected = new(0,0);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ToPixelCoords_2()
    {
        Camera camera = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        Vector2 world_pos = new (1, 1);
        Vector2 resolution = new(100, 100);

        Vector2 actual = camera.toPixelCoords(world_pos, resolution);

        Vector2 expected = new(100,100);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FromProjection_1()
    {
        Vector2 world_pos = new (0, 0);
        Vector2 world_size = new (1, 1);

        Vector2 pixel_pos = new (0, 0);
        Vector2 pixel_size = new (100, 100);
        Vector2 resolution = new(100, 100);

        Camera actual = Camera.fromProjection(
            new Bounds2(world_pos, world_size),
            new Bounds2(pixel_pos, pixel_size),
            resolution
        );

        Camera expected = new(new Bounds2(new Vector2(0, 0), new Vector2(1, 1)));
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FromProjection_2()
    {
        Vector2 world_pos = new (0, 0);
        Vector2 world_size = new (1, 1);

        Vector2 pixel_pos = new (0, 0);
        Vector2 pixel_size = new (100, 100);
        Vector2 resolution = new(200, 100);

        Camera actual = Camera.fromProjection(
            new Bounds2(world_pos, world_size),
            new Bounds2(pixel_pos, pixel_size),
            resolution
        );

        Camera expected = new(new Bounds2(new Vector2(0, 0), new Vector2(2, 1)));
        Assert.That(actual, Is.EqualTo(expected));
    }
}
