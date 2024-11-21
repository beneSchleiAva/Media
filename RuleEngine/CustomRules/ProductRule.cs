using Evaluation.Interfaces;
using ModelInterface.Interface.Elements;

namespace Evaluation.CustomRules
{
    public class ProductRule
    {
        public static Lazy<BaseCustomRule<IProduct>> rule = new Lazy<BaseCustomRule<IProduct>>(GetProductRule);
        private static BaseCustomRule<IProduct> GetProductRule()
        {
            return new BaseCustomRule<IProduct>(new List<RuleCondition>() { new(RuleName.ProductQuantityRule, "Price", ">", 0.ToString()) });
        }

        public static async Task<bool> Evaluate(IProduct product)
        {
            return await rule.Value.Evaluate(product);
        }
    }
}
