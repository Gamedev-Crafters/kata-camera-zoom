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
    public void SeModificaRenderDelCuadrado()
    {
        // tenemos un cuadrado de 1x1 en metros;
        // se ve como 100x100px;
        // el raton esta en 0, 0;
        // nos acercamos en un 200%;
        // se ve el doble de grande;
        //  para comprobarlo: mirar el color de las 4 esquinas
        // el cuadrado se ve como 200x200px;
    }

    [Test]
    public void SeModificaViewport()
    {
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
        // el raton esta en 0, 0;
        // nos acercamos en un 200%;
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
    }

    [Test]
    public void SeModificaViewportDependiendoDelRaton()
    {
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
        // el raton esta en 123, 321;
        // nos acercamos en un 200%;
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
    }
}