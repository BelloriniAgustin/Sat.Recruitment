using System;

namespace Sat.Recruitment.Entities
{
    public abstract class User : UserDTO
    {
        public void ApplyGift()
        {
            var percentageToApply = GetGiftPercentage();
            var gift = Money * Convert.ToDecimal(percentageToApply);
            Money += gift;
        }

        protected abstract double GetGiftPercentage();
    }
}
