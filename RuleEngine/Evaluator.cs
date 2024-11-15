using Evaluation.CustomRules;
using ModelInterface.Interface;

namespace Evaluation
{
    public class Evaluator<T> where T : class
    {
        public static async Task<bool> Evaluate(T item)
        {
            if (typeof(T) == typeof(IProduct))
            {
                var evaluatedItem = item as IProduct;
                if (evaluatedItem != null)
                    return await new ProductRule().Evaluate(evaluatedItem);
            }
            return false;
        }
    }
}
