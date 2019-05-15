using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithmForTestingHeuristics.Utilities
{
    class Vector2
    {
        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        #region Static elements
        public static Vector2 Zero = new Vector2(0, 0);
        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
        }

        #endregion
    }
}
