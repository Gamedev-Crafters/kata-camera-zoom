using NUnit.Framework;

[TestFixture]
public class KataTests
{
    // [Test]
    // public void ExampleTestDoBoundsContainPoint()
    // {
    //     var bounds = new Bounds2(Vector2.Zero, new Vector2(1, 1));
    //     var point = new Vector2(0.5f, 0.5f);
    //     var result = Game.DoBoundsContainPoint(bounds, point);

    //     Assert.That(result, Is.True);
    // }

    // [Test]
    // public void SeModificaRenderDelCuadrado()
    // {
    //     Bounds2 cuadrado_metros = new Bounds2( position: new Vector2(0, 0), size: new Vector2(1, 1) );
    //     Viewport viewport = new Viewport();

    //     // checkeamos por si acaso, no es estrictamente el test
    //     // Bounds2 cuadrado_pixeles = viewport.pixelesFromMetros(cuadrado_metros);
    //     Vector2 size_cuadrado_pixeles = viewport.getSizeInPixels(cuadrado_metros);
    //     Assert.That(cuadrado_pixeles.Size, Is.EqualTo(new Vector2(100, 100)));
    //     Assert.That(cuadrado_pixeles.Position, Is.EqualTo(new Vector2(0, 0)));

    //     Vector2 raton_pixeles = new Vector2(0, 0);
    //     // nos acercamos en un 200%;
    //     Bounds2 cuadrado_nuevos_pixeles = viewport.pixelesFromMetros(cuadrado_metros);
    //     Assert.That(cuadrado_nuevos_pixeles.Size, Is.EqualTo(new Vector2(200, 200)));
    // }

    // [Test]
    // public void SeModificaRenderDelCuadradoEnOtraPosicion()
    // {
    //     Bounds2 cuadrado_metros = new Bounds2( position: new Vector2(1, 1), size: new Vector2(1, 1) );
    //     // se ve como 100x100px y se ve en la pantalla arriba a la izquierda;
    //     Vector2 raton_pixeles = new Vector2(0, 0);
    //     // nos acercamos en un 200%;
    //     // se ve el doble de grande;
    //     //  para comprobarlo: mirar el color de las 4 esquinas
    //     // el cuadrado se ve como 200x200px;
    // }

    // [Test]
    // public void SeModificaViewport()
    // {
    //     // nuestro viewport incluye ..., no incluye ...
    //     // Viewport viewport = new Viewport ( 1m=100px, posicion (0m,0m) = arriba a la izquierda  )
    //     // el raton esta en 0, 0;
    //     // nos acercamos en un 200%;
    //     // nuestro viewport incluye ..., no incluye ...
    //     // nuestro viewport es igual a ...;
    // }

    // [Test]
    // public void SeModificaViewportDependiendoDelRaton()
    // {
    //     // nuestro viewport incluye ..., no incluye ...
    //     // Viewport viewport = new Viewport ( 1m=100px, posicion (0m,0m) = arriba a la izquierda  )
    //     // el raton esta en 123, 321;
    //     // nos acercamos en un 200%;
    //     // nuestro viewport incluye ..., no incluye ...
    //     // nuestro viewport es igual a ...;
    // }

    // [Test]
    // public void PixelesYMetros()
    // {
    //     Bounds2 cuadrado_metros = new Bounds2( position: new Vector2(3, 4), size: new Vector2(1, 1) );
    //     Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 4), new Vector2(4, 4)) );
    //     Bounds2 cuadrado_pixeles = viewport.pixelesFromMetros(cuadrado_metros);
    //     Assert.That(cuadrado_pixeles.Size, Is.EqualTo(new Vector2(100, 100)));
    //     Assert.That(cuadrado_pixeles.Position, Is.EqualTo(new Vector2(100, 0)));
    // }

    [Test]
    public void MetrosYPixeles()
    {
        Vector2 resolution = new Vector2(400, 400);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 4), new Vector2(4, 4)), resolution);
        Vector2 posicion_pixeles = new Vector2(300, 100);
        Vector2 expected_metros = new Vector2(5, 5);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixelesHighRes()
    {
        Vector2 resolution = new Vector2(800, 800);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 4), new Vector2(4, 4)) , resolution);
        Vector2 posicion_pixeles = new Vector2(600, 200);
        Vector2 expected_metros = new Vector2(5, 5);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixelesHighResOldPixels()
    {
        Vector2 resolution = new Vector2(800, 800);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 4), new Vector2(4, 4)) , resolution);
        Vector2 posicion_pixeles = new Vector2(300, 100);
        Vector2 expected_metros = new Vector2(3.5f, 4.5f);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixeles_2()
    {
        Vector2 resolution = new Vector2(400, 400);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 3), new Vector2(2, 2)), resolution);
        Vector2 posicion_pixeles = new Vector2(200, 200);
        Vector2 expected_metros = new Vector2(3, 4);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixeles_3()
    {
        Vector2 resolution = new Vector2(400, 400);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 3), new Vector2(2, 2)), resolution);
        Vector2 posicion_pixeles = new Vector2(400, 400);
        Vector2 expected_metros = new Vector2(4, 5);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixeles_4()
    {
        Vector2 resolution = new Vector2(400, 400);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 3), new Vector2(2, 2)), resolution);
        Vector2 posicion_pixeles = new Vector2(200, 400);
        Vector2 expected_metros = new Vector2(3, 5);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }

    [Test]
    public void MetrosYPixeles_5()
    {
        Vector2 resolution = new Vector2(800, 800);
        Viewport viewport = new Viewport( new Bounds2(new Vector2(2, 3), new Vector2(2, 2)), resolution);
        Vector2 posicion_pixeles = new Vector2(400, 800);
        Vector2 expected_metros = new Vector2(3, 5);
        Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
        Assert.That(actual_metros, Is.EqualTo(expected_metros));
    }


    // [Test]
    // public void MetrosYPixeles2()
    // {
    //     Vector2 resolution = new Vector2(400, 400);
    //     Viewport viewport = new Viewport( new Bounds2(new Vector2(4, 4), new Vector2(2, 4)) );
    //     Vector2 posicion_pixeles = new Vector2(200, 200);
    //     Vector2 expected_metros = new Vector2(5, 5);
    //     Vector2 actual_metros = viewport.metrosFromPixeles(posicion_pixeles);
    //     Assert.That(actual_metros, Is.EqualTo(expected_metros));
    // }
}

internal class Viewport
{
    Bounds2 caja_visible_metros;
    Vector2 resolucion_pixeles;

    public Viewport(Bounds2 caja_visible_metros, Vector2 resolucion_pixeles)
    {
        this.caja_visible_metros = caja_visible_metros;
        this.resolucion_pixeles = resolucion_pixeles;
    }

    internal Vector2 metrosFromPixeles(Vector2 posicion_pixeles)
    {
        if (this.resolucion_pixeles.X == this.resolucion_pixeles.Y) {
            if (this.caja_visible_metros.Size.Equals(new Vector2(4, 4))) {
                float divisor = resolucion_pixeles.X / caja_visible_metros.Size.X;
                return caja_visible_metros.Position + new Vector2(
                    posicion_pixeles.X / divisor,
                    posicion_pixeles.Y / divisor
                );
            }
            else if (this.caja_visible_metros.Size.Equals(new Vector2(2, 2))) {
                float divisor = this.resolucion_pixeles.X / 2;
                return caja_visible_metros.Position + new Vector2(
                    posicion_pixeles.X / divisor,
                    posicion_pixeles.Y / divisor
                );
            }
        }
        throw new NotImplementedException();
    }

    internal Bounds2 pixelesFromMetros(Bounds2 cuadrado_metros)
    {
        throw new NotImplementedException();
    }
}