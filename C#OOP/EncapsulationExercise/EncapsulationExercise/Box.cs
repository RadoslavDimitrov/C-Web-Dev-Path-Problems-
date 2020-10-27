using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationExercise
{
    public class Box
    {
		private double length;

		private double width;

		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}
		public double Height
		{
			get { return height; }
			private set 
			{ 
				if(value <= 0)
				{
					//throw new ArgumentException("Height cannot be zero or negative.");
					Console.WriteLine("Height cannot be zero or negative.");
				}
				else
				{
					height = value;
				}
				
			}
		}

		public double Width
		{
			get { return width; }
			private set 
			{
				if (value <= 0)
				{
					//throw new ArgumentException("Width cannot be zero or negative.");
					Console.WriteLine("Width cannot be zero or negative.");
				}
				else
				{
					width = value;
				}

			}
		}


		public double Length
		{
			get { return length; }
			private set 
			{
				if (value <= 0)
				{
					//throw new ArgumentException("Length cannot be zero or negative.");
					Console.WriteLine("Length cannot be zero or negative.");
				}
				else
				{
					length = value;
				}

			}
		}

		public double SurfaceArea()
		{
			//2lw + 2lh + 2wh
			return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;
		}

		public double LateralSurfaceArea()
		{
			// 2lh + 2wh
			return 2 * this.length * this.height + 2 * this.width * this.height;
		}

		public double Volume()
		{
			//lwh
			return this.length * this.width * this.height;
		}
	}
}
