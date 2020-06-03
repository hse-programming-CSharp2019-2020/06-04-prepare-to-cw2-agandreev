using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
    [DataContract]
    public class Box : Item
    {
        private double a, b, c;

        public Box(double a, double b, double c, double weight) : base(weight)
        {
            A = a;
            B = b;
            C = c;
        }

        [DataMember]
        public double A
        {
            get => a;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                a = value;
            }
        }

        [DataMember]
        public double B
        {
            get => b;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                b = value;
            }
        }

        [DataMember]
        public double C
        {
            get => c;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                c = value;
            }
        }

        public double GetLongestSideSize()
        {
            if (A > B && A > C)
            {
                return A;
            }
            if (B > A && B > C)
            {
                return B;
            }
            return C;
        }

        public override string ToString()
        {
            return $"A: {A}, B: {B}, C: {C}, " + base.ToString();
        }
    }
}
