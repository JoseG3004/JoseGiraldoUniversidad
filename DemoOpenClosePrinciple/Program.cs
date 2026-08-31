

using DemoOpenClosePrinciple;

AreaCalculator calculator = new AreaCalculator();

Circle circle1 = new Circle();
circle1.Radius = 2;

Circle circle2 = new Circle();
circle2.Radius = 3;

Circle circle3 = new Circle();
circle3.Radius = 4;


Square square1 = new Square();
square1.Size = 5;

Square square2 = new Square();
square2.Size = 4;

Square square3 = new Square();
square3.Size = 7;

Triangulo triangulo1 = new Triangulo();
triangulo1.Base = 5;
triangulo1.Altura = 2;

Triangulo triangulo2 = new Triangulo();
triangulo2.Base = 4;
triangulo2.Altura = 3;

Triangulo triangulo3= new Triangulo();
triangulo3.Base = 8;
triangulo3.Altura = 8;

Trapecio trapecio1 = new Trapecio(10,5,6);
Trapecio trapecio2 = new Trapecio(20, 10, 5);
Trapecio trapecio3 = new Trapecio(40, 3, 1);

Paralelogramo paralelogramo1 = new Paralelogramo(10,8);
Paralelogramo paralelogramo2 = new Paralelogramo(20, 2);
Paralelogramo paralelogramo3 = new Paralelogramo(40, 3);

List<Shape> shapes = new List<Shape>();
shapes.Add(circle1);
shapes.Add(circle2);
shapes.Add(circle3);
shapes.Add(square1);
shapes.Add(square2);
shapes.Add(square3);
shapes.Add(triangulo1);
shapes.Add(triangulo2);
shapes.Add(triangulo3);
shapes.Add(trapecio1);
shapes.Add(trapecio2);
shapes.Add(trapecio3);
shapes.Add(paralelogramo1);
shapes.Add(paralelogramo2);
shapes.Add(paralelogramo3);

var resultTotalArea = calculator.TotalArea(shapes);

Console.WriteLine($"El área total es {resultTotalArea}");