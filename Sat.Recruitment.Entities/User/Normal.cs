﻿namespace Sat.Recruitment.Entities
{
    public class Normal : User
    {
        private readonly double _maxPercentage = 0.8;
        private readonly decimal _minMoneyNeeded = 10;
        private readonly double _minPercentage = 0.12;
        private readonly decimal _maxMoneyNeeded = 100;

        protected override double GetGiftPercentage()
        {
            return Money > _maxMoneyNeeded ? _minPercentage : Money > _minMoneyNeeded ? _maxPercentage : 0;
        }
    }
}
