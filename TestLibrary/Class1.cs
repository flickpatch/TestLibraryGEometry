namespace TestLibrary
{
    public class Geometry
    {
        // Абстрактный базовый класс для всех фигур
        public abstract class Shape
        {
            public abstract double GetArea();
        }

        // Класс, представляющий круг
        public class Circle : Shape
        {
            public double Radius { get; }

            public Circle(double radius)
            {
                if (radius <= 0)
                {
                    throw new ArgumentException("Радиус должен быть положительным числом.");
                }
                Radius = radius;
            }

            public override double GetArea()
            {
                return Math.PI * Radius * Radius;
            }
        }

        // Класс, представляющий треугольник
        public class Triangle : Shape
        {
            public double SideA { get; }
            public double SideB { get; }
            public double SideC { get; }

            public Triangle(double sideA, double sideB, double sideC)
            {
                if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                {
                    throw new ArgumentException("Стороны должны быть положительными числами.");
                }
                if (!IsTrianglePossible(sideA, sideB, sideC))
                {
                    throw new ArgumentException("Сумма любых двух сторон треугольника должна быть больше третьей.");
                }

                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }

            private bool IsTrianglePossible(double a, double b, double c)
            {
                return (a + b > c) && (a + c > b) && (b + c > a);
            }

            public override double GetArea()
            {
                double s = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC)); // Формула Герона
            }

            public bool IsRightAngled()
            {
                return TriangleChecker.IsRightAngled(this);
            }
        }

        // Класс для проверки прямоугольности треугольника
        public static class TriangleChecker
        {
            public static bool IsRightAngled(Triangle triangle)
            {
                double[] sides = { triangle.SideA, triangle.SideB, triangle.SideC };
                Array.Sort(sides);
                return Math.Abs(sides[0] * sides[0] + sides[1] * sides[1] - sides[2] * sides[2]) < 0.000001;
            }
        }
    }
}
