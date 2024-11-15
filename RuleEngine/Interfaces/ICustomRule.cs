namespace Evaluation.Interfaces
{
    public interface ICustomRule<T>
    {
        public Task<bool> Evaluate(T obj);
    }
}
