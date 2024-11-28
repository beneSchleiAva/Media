using Evaluation.Interfaces;
using ModelInterface.Interface.Elements;
using ModelInterface.Interface.ValueObjects;

namespace Evaluation.CustomRules
{
    public class ProductRule
    {
        public static Lazy<BaseCustomRule<IProduct>> rule = new Lazy<BaseCustomRule<IProduct>>(GetProductRule);
        private static BaseCustomRule<IProduct> GetProductRule()
        {
            return new BaseCustomRule<IProduct>(new List<RuleCondition>() { new(RuleName.ProductQuantityRule, $"{nameof(IProduct.Price)}.{nameof(IProduct.Price.Value)}", ">", 0.ToString()) });
        }

        public static async Task<bool> Evaluate(IProduct product)
        {
            return await rule.Value.Evaluate(product);
        }
    }
}
