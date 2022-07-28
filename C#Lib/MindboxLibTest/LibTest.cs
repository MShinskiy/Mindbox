/*
 * Author: Максим Шинский
 * Date: 28.07.2022
 * IDE: Rider
 * Unit test framework: MSTest
 */

namespace MindboxLibTest;

[TestClass]
public class LibTest
{
    //Точность сравнения double переменных
    private double delta = 1e6d;
    
    [TestMethod]
    public void TestIsValidTriangle()
    {
        Assert.IsTrue(IsValidTriangle(2, 4, 5));
        Assert.IsTrue(IsValidTriangle(9.72, 4.5, 5.7));
        Assert.IsFalse(IsValidTriangle(1, 1, 5));
        Assert.IsFalse(IsValidTriangle(-1, 5, 5));
    }

    [TestMethod]
    public void TestIsValidCircle()
    {
        Assert.IsTrue(IsValidCircle(3.9));
        Assert.IsFalse(IsValidCircle(-7));
    }

    [TestMethod]
    public void TestIsRightAngleTriangle()
    {
        Assert.IsTrue(IsRightAngleTriangle(4, 3, 5));
        Assert.IsTrue(IsRightAngleTriangle(4.44879, 6.544, 7.913));
        Assert.IsFalse(IsRightAngleTriangle(4.448, 6.544, 7.913));
    }

    [TestMethod]
    public void TestRightAngleTriangleArea()
    {
        Assert.AreEqual(RightAngleTriangleArea(4, 3, 5), 6, delta);
        Assert.AreEqual(RightAngleTriangleArea(40.553, 77.55, 87.51), 1572.442575, delta);
    }

    [TestMethod]
    public void TestShape()
    {
        //Окружность
        Assert.AreEqual(ShapeArea(4), 50.265482, delta);
        //Треугольник
        Assert.AreEqual(ShapeArea(8, 15, 17), 60, delta);
    }

    [TestMethod]
    public void TestCircleArea()
    {
        Assert.AreEqual(CircleArea(1.548), 7.528211, delta);
        Assert.AreEqual(CircleArea(1565848), 7702808067005.169, delta);
        Assert.ThrowsException<ArgumentException>(() => CircleArea(-2));
    }

    [TestMethod]
    public void TestTriangleArea()
    {
        Assert.AreEqual(TriangleArea(4.66, 1.54, 4.99955577), 3.581007, delta );
        Assert.AreEqual(TriangleArea(38, 178, 182), 3382, delta);
        Assert.ThrowsException<ArgumentException>(() => TriangleArea(1, 6, 789));
    }
}