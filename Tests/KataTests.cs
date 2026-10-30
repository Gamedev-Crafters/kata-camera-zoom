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
        Bounds2 cuadrado_metros = new Bounds2( position: new Vector2(0, 0), size: new Vector2(1, 1) );
        // Viewport viewport = ...?;

        // checkeamos por si acaso, no es estrictamente el test
        Bounds2 cuadrado_pixeles = viewport.pixelesFromMetros(cuadrado_metros);
        Assert.That(cuadrado_pixeles.Size, Is.EqualTo(new Vector2(100, 100)));
        Assert.That(cuadrado_pixeles.Position, Is.EqualTo(new Vector2(0, 0)));

        Vector2 raton_pixeles = new Vector2(0, 0);
        // nos acercamos en un 200%;
        Bounds2 cuadrado_nuevos_pixeles = viewport.pixelesFromMetros(cuadrado_metros);
        Assert.That(cuadrado_nuevos_pixeles.Size, Is.EqualTo(new Vector2(200, 200)));
    }

    [Test]
    public void SeModificaRenderDelCuadradoEnOtraPosicion()
    {
        Bounds2 cuadrado_metros = new Bounds2( position: new Vector2(1, 1), size: new Vector2(1, 1) );
        // se ve como 100x100px y se ve en la pantalla arriba a la izquierda;
        Vector2 raton_pixeles = new Vector2(0, 0);
        // nos acercamos en un 200%;
        // se ve el doble de grande;
        //  para comprobarlo: mirar el color de las 4 esquinas
        // el cuadrado se ve como 200x200px;
    }

    [Test]
    public void SeModificaViewport()
    {
        // nuestro viewport incluye ..., no incluye ...
        // Viewport viewport = new Viewport ( 1m=100px, posicion (0m,0m) = arriba a la izquierda  )
        // el raton esta en 0, 0;
        // nos acercamos en un 200%;
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
    }

    [Test]
    public void SeModificaViewportDependiendoDelRaton()
    {
        // nuestro viewport incluye ..., no incluye ...
        // Viewport viewport = new Viewport ( 1m=100px, posicion (0m,0m) = arriba a la izquierda  )
        // el raton esta en 123, 321;
        // nos acercamos en un 200%;
        // nuestro viewport incluye ..., no incluye ...
        // nuestro viewport es igual a ...;
    }
}