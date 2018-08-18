﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterCrabPots.Framework
{
    class Weighted
    {
        public static T Choose<T>(T[] list) where T : IWeighted
        {
            if (!list.Any())
                return default(T);

            int totalweight = list.Sum(c => c.Weight);
            int choice = ModEntry.Twister.Next(totalweight);
            int sum = 0;

            foreach (var obj in list)
            {
                for (float i = sum; i < obj.Weight + sum; i++)
                {
                    if (i >= choice)
                        return obj;
                }
                sum += obj.Weight;
            }

            return list.First();
        }
        public static T ChooseRange<T>(T[] list, int min, int max) where T : IWeighted
        {
            //Grab a random value right quick, make sure the list is working and all
            T choice = Weighted.Choose(list);

            //4096 changes to pick a number from the range.
            //If it takes longer than that something isn't right.
            for (int i = 0; i < 4096; i++)
            {
                choice = Weighted.Choose(list);
                if (choice.Value is int)
                {
                    int x = (int)choice.Value;
                    if (x >= min && x <= max)
                        return choice;
                }
            }

            if (choice is WeightedGeneric<int>)
            {
                int w = choice.Weight;
                choice = Activator.CreateInstance<T>();
                choice.Value = min < max ? ModEntry.Twister.Next(min, max) : ModEntry.Twister.Next(Math.Max(min, max));
                choice.Weight = w;
                return choice;
            }

            throw new ArgumentOutOfRangeException(nameof(min) + nameof(max), "The requested value was not in the Min/Max range supplied.");
        }

    }
}
