using Evaluation.Interfaces;
using ModelInterface.Interface.Elements;
using RulesEngine.Models;

namespace Evaluation.CustomRules
{
    internal class ProductRule : ICustomRule<IProduct>
    {

        private static Lazy<List<RuleCondition>> ruleProperties = new Lazy<List<RuleCondition>>(() =>
                {
                    return new List<RuleCondition>() {
                    new(RuleName.ProductNameRule, "Name", "==", "\"india\"")
                };});


        private static Lazy<RulesEngine.RulesEngine> productRulesEngine = new Lazy<RulesEngine.RulesEngine>(() =>
        {
            List<Rule> rules = new List<Rule>();
            foreach (var rule in ruleProperties.Value)
            {
                rules.Add(new Rule()
                {
                    RuleName = rule.RuleName.ToString(),
                    RuleExpressionType = RuleExpressionType.LambdaExpression,
                    Expression = $"{rule.Property} {rule.Operator} {rule.Criteria}"
                });
            }
            return new RulesEngine.RulesEngine([new Workflow() { WorkflowName = WorkflowName.ProductWorkflow.ToString(), Rules = rules }]);

        });

        public async Task<bool> Evaluate(IProduct obj)
        {
            var nameResult = await productRulesEngine.Value.ExecuteAllRulesAsync(WorkflowName.ProductWorkflow.ToString(), obj);
            if (nameResult is null)
                return false;

            if (nameResult.Where(r => !r.IsSuccess).Any()) return false;
            return true;
        }
    }
}
