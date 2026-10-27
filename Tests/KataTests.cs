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
        // red thing's center is at (0, 0)
        // seen from the camera, it is rect(size=0.1, pos=(0.2, 0.5))
        // put cursor in (-1, 0)
        // seen from the camera, the cursor is pos=(0.1, 0.5)
        // zoom in
        // red thing should now be rect(size=0.8, pos=(0.5, 0.5))

        // red thing's center is at (0, 0)
        // seen from the camera, it is rect(size=0.8, pos=(0.5, 0.5))
        // put cursor in (1, 0)
        // seen from the camera, the cursor in pos=(0.9, 0.5)
        // zoom out
        // red thing should now be rect(size=0.1, pos=(0.2, 0.5))
    }
}