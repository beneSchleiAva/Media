using Evaluation.Interfaces;
using ModelInterface.Interface.Aggregates;

namespace Evaluation.CustomRules
{
    public class OrderPositonRule
    {
        public static Lazy<BaseCustomRule<IOrderPosition>> rule = new Lazy<BaseCustomRule<IOrderPosition>>(GetRule);
        private static BaseCustomRule<IOrderPosition> GetRule()
        {
            return new BaseCustomRule<IOrderPosition>(new List<RuleCondition>() { new(RuleName.OrderPositionQuantityRule, "Quantity", "!=", 0.ToString()) });
        }

        public async Task<bool> Evaluate(IOrderPosition item)
        {
            return await rule.Value.Evaluate(item);
        }
    }
}
