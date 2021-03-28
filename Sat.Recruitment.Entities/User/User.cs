using System;

namespace Sat.Recruitment.Entities
{
    public abstract class User
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string Phone { get; set; }
        
        public string UserType { get; set; }
        
        public decimal Money { get; set; }

        public void ApplyGift()
        {
            var percentageToApply = GetGiftPercentage();
            var gift = Money * Convert.ToDecimal(percentageToApply);
            Money += gift;
        }

        protected abstract double GetGiftPercentage();
    }
}
