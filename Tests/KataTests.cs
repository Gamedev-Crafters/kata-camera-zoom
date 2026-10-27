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
        // red thing is small and to the left
        // put cursor in left side
        // zoom in
        // red thing should now be big and in the center

        // red thing is big and in the center
        // put cursor in right side
        // zoom out
        // red thing should now be small and on the right
    }
}