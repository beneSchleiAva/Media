using Evaluation.Interfaces;
using RulesEngine.Models;

namespace Evaluation.CustomRules
{
    public class BaseCustomRule<T> : ICustomRule<T> where T : class
    {
        RulesEngine.RulesEngine RulesEngine;
        public BaseCustomRule(List<RuleCondition> ruleConditions)
        {
            List<Rule> rules = new List<Rule>();
            foreach (var rule in ruleConditions)
            {
                rules.Add(new Rule()
                {
                    RuleName = rule.RuleName.ToString(),
                    RuleExpressionType = RuleExpressionType.LambdaExpression,
                    Expression = $"{rule.Property} {rule.Operator} {rule.Criteria}"
                });
            }
            RulesEngine = new RulesEngine.RulesEngine([new Workflow() { WorkflowName = WorkflowName.ProductWorkflow.ToString(), Rules = rules }]);
        }

        public async Task<bool> Evaluate(T obj)
        {
            var result = await RulesEngine.ExecuteAllRulesAsync(WorkflowName.ProductWorkflow.ToString(), obj);
            if (result is null)
                return false;

            if (result.Where(r => !r.IsSuccess).Any()) return false;
            return true;
        }
    }
}