using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicle_OOP
{
    public abstract class Shape
    {
        abstract public double GetArea();

        abstract public double GetPerimeter();
    }

    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double GetArea()
        {
            return width * height;
        }
        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
}
