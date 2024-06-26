﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaGame.TakePizzasStrategies
{
    public class CpuTakePizzasStrategy : ITakePizzasStrategy
    {
        public int TakePizzas(IEnumerable<int> validMoves)
        {
            return validMoves.ElementAt(new Random().Next(validMoves.Count()));
        }
    }
}
