using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Entities
{
    public class Premium : User
    {
        private readonly double _percentage = 2;
        private readonly decimal _minMoneyNeeded = 100;
        private readonly string _userType = "Premium";

        protected override double GetGiftPercentage()
        {
            return Money > _minMoneyNeeded ? _percentage : 0;
        }
    }
}
