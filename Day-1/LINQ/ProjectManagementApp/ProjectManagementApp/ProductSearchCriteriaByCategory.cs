namespace ProjectManagementApp
{
    public class ProductSearchCriteriaByCategory : ISearchCriteria<Product>
    {
        private readonly int _category;

        public ProductSearchCriteriaByCategory(int category)
        {
            _category = category;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Category == _category;
        }
    }
}