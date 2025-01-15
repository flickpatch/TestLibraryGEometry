using System;
using static TestLibrary.Geometry;

public class Program
{
    public static void Main(string[] args)
    {
        // Создаем круг
        Circle circle = new Circle(5);
        Console.WriteLine($"Площадь круга: {circle.GetArea()}");

        // Создаем треугольник
        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine($"Площадь треугольника: {triangle.GetArea()}");
        Console.WriteLine($"Треугольник прямоугольный: {triangle.IsRightAngled()}");

        // Работа с фигурами без знания типа в compile-time
        Shape shape1 = new Circle(7);
        Shape shape2 = new Triangle(5, 12, 13);
        Console.WriteLine($"Площадь фигуры 1: {shape1.GetArea()}");
        Console.WriteLine($"Площадь фигуры 2: {shape2.GetArea()}");

        // Проверка на исключение
        try
        {
            Triangle triangleInvalid = new Triangle(1, 2, 5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}