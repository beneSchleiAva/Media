using Evaluation.CustomRules;
using ModelInterface.Factories;
using ModelInterface.Interface.Aggregates;

namespace Test.Evaluation
{
    public class OrderPositionRule_Test
    {
        OrderPositonRule? rule;
        IOrderPosition? validPosition;
        IOrderPosition? inValidPosition;
        IOrderPosition? zeroPosition;

        [SetUp]
        public void Setup()
        {
            rule = new OrderPositonRule();
            validPosition = OrderPositionFactory.Create(Guid.NewGuid(), "TestName", 12m, 12, 14);
            inValidPosition = OrderPositionFactory.Create(Guid.NewGuid(), "TestName", 12m, 12, -1);
            zeroPosition = OrderPositionFactory.Create(Guid.NewGuid(), "TestName", 12m, 2,0);
        }

        [Test]
        public async Task Valid_Should_Pass()
        {
            if (rule == null || validPosition == null)
                Assert.Fail();
            else
            {
                var result = await rule.Evaluate(validPosition);
                Assert.IsTrue(result);
            }
        }

        [Test]
        public async Task InValid_Should_Fail()
        {
            if (rule == null || inValidPosition == null)
                Assert.Fail();
            else
            {
                var result = await rule.Evaluate(inValidPosition);
                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task Zero_Should_Fail()
        {
            if (rule == null || zeroPosition == null)
                Assert.Fail();
            else
            {
                var result = await rule.Evaluate(zeroPosition);
                Assert.IsFalse(result);
            }
        }
    }
}