using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Entities
{
    public class SuperUser : User
    {
        private readonly double _percentage = 0.20;
        private readonly decimal _minMoneyNeeded = 100;
        private readonly string _userType = "SuperUser";

        protected override double GetGiftPercentage()
        {
            return Money > _minMoneyNeeded ? _percentage : 0;
        }
    }
}
