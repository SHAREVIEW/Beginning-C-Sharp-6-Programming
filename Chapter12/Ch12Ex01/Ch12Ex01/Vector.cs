using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Ch12Ex01
{
    public class Vector
    {
        public double? R = null;
        public double? Theta = null;
        public double? ThetaRadians
        {
            get { return (Theta * Math.PI / 180.0); }
        }
        public Vector(double? r, double? theta)
        {
            if(r<0)
            {
                r = -r;
                theta += 180;
            }
            theta = theta % 360;
            R = r;
            Theta = theta;
        }
        public static Vector operator +(Vector op1, Vector op2)
        {
            try
            {
                double newY = op1.R.Value * Sin(op1.ThetaRadians.Value)
                    + op2.R.Value * Sin(op2.ThetaRadians.Value);
                double newX = op1.R.Value * Cos(op1.ThetaRadians.Value)
                    + op2.R.Value * Cos(op2.ThetaRadians.Value);
                double newR = Sqrt(newX * newX + newY * newY);
                double newTheta = Atan2(newY, newX) * 180.0 / PI;
                return new Vector(newR, newTheta);
            }
            catch
            {
                return new Vector(null, null);
            }
        }
        public static Vector operator -(Vector op1)=>new Vector(-op1.R,op1.Theta);
        public static Vector operator -(Vector op1,Vector op2) => op1+(-op2);
        public static double? operator *(Vector op1,Vector op2) 
            => op1.R*op2.R* Cos((double)(op2.ThetaRadians - op1.ThetaRadians));
        public override string ToString()
        {
            string rString = R.HasValue ? R.ToString() : "null";
            string thetaString = Theta.HasValue ? Theta.ToString() : "null";
            return string.Format($"({rString}, {thetaString})");
        }
    }
}
