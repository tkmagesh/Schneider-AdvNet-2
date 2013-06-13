namespace ProjectManagementApp
{
    public interface ISearchCriteria<T>
    {
        bool IsSatisfiedBy(T item);
    }
}