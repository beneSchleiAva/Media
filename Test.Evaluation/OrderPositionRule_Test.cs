using Evaluation.CustomRules;
using ModelInterface.Factories;
using ModelInterface.Interface.Aggregates;
using ModelInterface.Interface.Elements;

namespace Test.Evaluation
{
    public class OrderPositionRule_Test
    {
        OrderPositonRule? rule;
        IOrderPosition? validPosition;
        IOrderPosition? inValidPosition;
        IOrderPosition? zeroPosition;

        IProduct? product;

        [SetUp]
        public void Setup()
        {
            product = ProductFactory.Create("TestName", "TestDescription", 122.20m);
            validPosition = OrderPositionFactory.Create(product, 12, 14);
            inValidPosition = OrderPositionFactory.Create(product, 12, -1);
            zeroPosition = OrderPositionFactory.Create(product, 2, 0);
        }

        [Test]
        public async Task Valid_Should_Pass()
        {
            if (rule == null || validPosition == null)
                Assert.Fail();
            else
            {
                var result = await OrderPositonRule.Evaluate(validPosition);
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
                var result = await OrderPositonRule.Evaluate(inValidPosition);
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
                var result = await OrderPositonRule.Evaluate(zeroPosition);
                Assert.IsFalse(result);
            }
        }
    }
}