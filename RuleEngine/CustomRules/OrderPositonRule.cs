using Evaluation.Interfaces;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace Evaluation.CustomRules
{
    public class OrderPositonRule
    {
        public static Lazy<BaseCustomRule<IOrderPosition>> rule = new Lazy<BaseCustomRule<IOrderPosition>>(GetRule);
        private static BaseCustomRule<IOrderPosition> GetRule()
        {
            return new BaseCustomRule<IOrderPosition>(new List<RuleCondition>() { new(RuleName.OrderPositionQuantityRule, $"{nameof(IOrderPosition.OrderDescription)}.{nameof(IOrderPosition.OrderDescription.Quantity)}", ">", 0.ToString()) });
        }

        public static async Task<bool> Evaluate(IOrderPosition item)
        {
            return await rule.Value.Evaluate(item);
        }
    }
}
