using System;
using System.Collections.Generic;

namespace Rectangles
{
	public class Point
    {
		public int x;
		public int y;
    }
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			bool OX = ((r2.Left >= r1.Left && r2.Left <= r1.Right) || (r2.Right >= r1.Left && r2.Right <= r1.Right)) || ((r1.Left >= r2.Left && r1.Left <= r2.Right) || (r1.Right >= r2.Left && r1.Right <= r2.Right));
			bool OY = ((r2.Top >= r1.Top && r2.Top <= r1.Bottom) || (r2.Bottom >= r1.Top && r2.Bottom <= r1.Bottom)) || ((r1.Top >= r2.Top && r1.Top <= r2.Bottom) || (r1.Bottom >= r2.Top && r1.Bottom <= r2.Bottom));

			return OX && OY;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
			int oxLength = 0;
			int oyLength = 0;
			if (r1.Left <= r2.Left && r1.Right >= r2.Right)
            {
				oxLength = r2.Right - r2.Left;
			}
			else if (r2.Left <= r1.Left && r2.Right >= r1.Right)
			{
				oxLength = r1.Right - r1.Left;
			}
			else if ((r2.Left >= r1.Left && r2.Left <= r1.Right) || (r1.Right >= r2.Left && r1.Right <= r2.Right))
            {
				oxLength = (r2.Right - r1.Left) - ((r2.Left - r1.Left)+(r2.Right - r1.Right));
            }
			else if ((r2.Right >= r1.Left && r2.Right <= r1.Right) || (r1.Left >= r2.Left && r1.Left <= r2.Right))
            {
				oxLength = (r1.Right - r2.Left) - ((r1.Left - r2.Left) + (r1.Right - r2.Right));
			}

			if (r1.Top <= r2.Top && r1.Bottom >= r2.Bottom)
			{
				oyLength = r2.Bottom - r2.Top;
			}
			else if (r2.Top <= r1.Top && r2.Bottom >= r1.Bottom)
			{
				oyLength = r1.Bottom - r1.Top;
			}
			else if ((r2.Top >= r1.Top && r2.Top <= r1.Bottom) || (r1.Bottom >= r2.Top && r1.Bottom <= r2.Bottom))
			{
				oyLength = (r2.Bottom - r1.Top) - ((r2.Top - r1.Top) + (r2.Bottom - r1.Bottom));
			}
			else if ((r2.Bottom >= r1.Top && r2.Bottom <= r1.Bottom) || (r1.Top >= r2.Top && r1.Top <= r2.Bottom))
			{
				oyLength = (r1.Bottom - r2.Top) - ((r1.Top - r2.Top) + (r1.Bottom - r2.Bottom));
			}

			return Math.Abs(oxLength) * Math.Abs(oyLength);
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			if (r1.Left <= r2.Left && r1.Right >= r2.Right && r1.Top <= r2.Top && r1.Bottom >= r2.Bottom)
				return 1;
			else if (r2.Left <= r1.Left && r2.Right >= r1.Right && r2.Top <= r1.Top && r2.Bottom >= r1.Bottom)
				return 0;
			else
				return -1;
		}
	}
}