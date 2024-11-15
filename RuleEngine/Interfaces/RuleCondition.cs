namespace Evaluation.Interfaces
{
    internal enum RuleName
    {
        ProductNameRule
    }
    internal enum WorkflowName
    {
        ProductWorkflow
    }

    internal record RuleCondition
    {
        public RuleName RuleName { get; init; }
        public string Property { get; init; }
        public string Operator{ get; init; }
        public string Criteria{ get; init; }

        public RuleCondition(RuleName rule, string property, string @operator, string criteria)
        {
            RuleName = rule;
            Property = property;
            Operator = @operator;
            Criteria = criteria;
        }
    }
}
