﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    internal class WeightedGeneric<T> : IWeighted
    {
        public object Value { get; set; }
        public int Weight { get; set; }

        public T TValue => (T)this.Value;

        public WeightedGeneric()
        {
            //Nothing
        }
        public WeightedGeneric(int weight, T value)
        {
            this.Weight = weight;
            this.Value = value;
        }
        public static WeightedGeneric<Ty> Create<Ty>(int weight, Ty value)
        {
            return new WeightedGeneric<Ty>(weight, value);
        }
    }
}
