using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EKRLib
{
    [DataContract, KnownType(typeof(Box))]
    public class Item : IComparable<Item>
    {
        private double weight;

        public Item(double weight)
        {
            Weight = weight;
        }

        [DataMember]
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                weight = value;
            }
        }

        public static implicit operator double(Item item)
        {
            return item.Weight;
        }

        public override string ToString()
        {
            return $"Weight: {Weight}";
        }

        public int CompareTo(Item other)
        {
            if (Weight > other.Weight)
            {
                return 1;
            }
            return -1;
        }
    }
}
