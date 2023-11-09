using System;
using System.Collections.Generic;
// найти точку, сумма расстояний от которой до остальных точек множества максимальна
namespace Pr_14_I
{
    struct SPoint
    {
        public int x, y;
        public SPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double Distance(SPoint otherPoint)
        {
            int deltaX = otherPoint.x - x;
            int deltaY = otherPoint.y - y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
    internal class Program14
    {
        static void Main()
        {
            List<SPoint> points = new List<SPoint>
            {
                new SPoint(1, 2),
                new SPoint(3, 4),
                new SPoint(5, 6),
                new SPoint(7, 8)
            };
            List<SPoint> maxSumDistancePoint = FindPointWithMaxSumDistance(points);
            Console.WriteLine("Точки, сумма расстояний от которых до остальных максимальна:");
            foreach (SPoint point in maxSumDistancePoint) Console.WriteLine("({0}, {1})", point.x, point.y);
        }
        static List<SPoint>FindPointWithMaxSumDistance(List<SPoint> points)
        {
            double maxSumDistance = 0; // текущая максимальная сумма расстояний
            List<SPoint> maxSumDistPoints = new List<SPoint>();

            for (int i = 0; i < points.Count; i++)
            {
                double sumDistance = 0; // сумма расстояний от текущей точки до остальных точек
                for (int j = 0; j < points.Count; j++)
                {
                    if (i != j)
                    {
                        double distance = points[i].Distance(points[j]);
                        sumDistance += distance;
                    }
                }
                if (sumDistance > maxSumDistance)
                {
                    maxSumDistance = sumDistance;
                    maxSumDistPoints.Clear();
                    maxSumDistPoints.Add(points[i]);
                }
                else if (sumDistance == maxSumDistance)
                {
                    maxSumDistPoints.Add(points[i]);
                }
            }
            return maxSumDistPoints;
        }
    }
}
