See the original [README.md](https://github.com/zachbarth/minimalist-game-framework.git) for the full documentation

# Camera Zoom Kata #

El objetivo de la kata es implementar "zoom donde apunte el cursor": ![kata goal](goal.gif)

Partimos de estos métodos y clases:

void **`DrawRectSolid`**(Bounds2 bounds, Color color)

* Draws a solid rectangle.

Vector2 **`MousePosition`**

* The current position of the mouse cursor (in pixels).

float **`MouseScroll`**

* The amount the mouse wheel has been scrolled this frame (in scroll units).

class **`Vector2`**

* A simple 2D vector class that supports basic vector math operations that is used in many API functions.

class **`Bounds2`**

* A simple axis-aligned 2D bounding rectangle that is used in a few API functions.

class **`Color`**

* A data structure representing a 32-bit RGBA color that is used in many API functions. 
* The class also contains static members for all of the built-in .NET colors, e.g. `Color.CornflowerBlue` and others.
