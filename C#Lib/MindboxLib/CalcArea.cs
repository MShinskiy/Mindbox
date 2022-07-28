/*
 * Author: Максим Шинский
 * Date: 28.07.2022
 * IDE: Rider
 */

namespace MindboxLib;

public static class CalcArea
{

    //Площадь окружности
    public static double CircleArea(double radius)
    {
        //Проверка радиуса
        if (!IsValidCircle(radius)) 
            throw new ArgumentException("Такая окружность не существует");
        return Math.PI * Math.Pow(radius, 2);
    }

    //Площадь треугольника
    public static double TriangleArea(double a, double b, double c)
    {
        //Проверка аргументов
        if (!IsValidTriangle(a, b, c)) 
            throw new ArgumentException("Такой треугольник не существует");
        
        //Найти площадь если треугольник прямоугольный
        if (IsRightAngleTriangle(a, b, c))
            return RightAngleTriangleArea(a, b, c);

        //Полупериметр
        double s = (a + b + c) / 2;
        //Формула Герона
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    /*
     * Вопрос: Вычисление площади фигуры без знания типа фигуры в compile-time
     * Предположение: Как я понял подразумевается полиморфизм и нет требования
     * описывать методы для вычисления типов фигур не описанных в вопросах.
     *
     * Два метода ниже предоставляют этому ввозможность
     */
    public static double ShapeArea(double radius)
    {
        return CircleArea(radius);
    }

    //Валидация радиуса окружности
    public static double ShapeArea(double a, double b, double c)
    {
        return TriangleArea(a, b, c);
    }

    //Валидация аргументов для треугольника
    public static bool IsValidTriangle(double a, double b, double c)
    {
        if (a < 0 || b < 0 || c < 0) return false;
        return a + b > c && a + c > b && b + c > a;
    }

    public static bool IsValidCircle(double r)
    {
        return r > 0;
    }
    
    //Проверка на прямоуглольный треугольник с точностью до tolerance
    public static bool IsRightAngleTriangle(double a, double b, double c)
    {
        double[] sides = {a, b, c};
        Array.Sort(sides);
        const double tolerance = 0.0001;
        return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < tolerance;
    }

    //Найти площадь прямоугольного треугольника
    public static double RightAngleTriangleArea(double a, double b, double c)
    {
        double[] sides = {a, b, c};
        Array.Sort(sides);
        return sides[0] * sides[1] / 2;
    }
}