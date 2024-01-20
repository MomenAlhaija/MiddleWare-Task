using APPReview;
List<Shape> Shapes = new List<Shape>()
{
    new Circle(2.22f),
    new Rectangle(2.25f,4.45f)

};
foreach (Shape shape in Shapes)
{
  Console.WriteLine(shape.PrintArea(shape));
}
