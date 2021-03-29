namespace Sat.Recruitment.Entities
{
    public class Premium : User
    {
        private readonly double _percentage = 2;
        private readonly decimal _minMoneyNeeded = 100;

        protected override double GetGiftPercentage()
        {
            return Money > _minMoneyNeeded ? _percentage : 0;
        }
    }
}
