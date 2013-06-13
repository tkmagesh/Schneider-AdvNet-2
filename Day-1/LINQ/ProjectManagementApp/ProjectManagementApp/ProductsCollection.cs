using System.Collections;

namespace ProjectManagementApp
{
    public class ProductsCollection : IEnumerable, IEnumerator
    {
        private ArrayList _list = new ArrayList();

        public int Count { get { return _list.Count; } }

        public void Add(Product product)
        {
            _list.Add(product);
        }

        public Product this[int index]
        {
            get { return (Product) _list[index]; }
        }

        public Product GetByIndex(int index)
        {
            return (Product) _list[index];
        }

        private int _index = -1;
        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _list.Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current { get { return (Product) _list[_index]; } }

        public ProductsCollection Search(IProductSearchCriteria criteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product) item;
                if (criteria.IsSatisfiedBy(product))
                    result.Add(product);
            }
            return result;
        }
        public ProductsCollection Search(ProductCriteriaDelegate criteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = (Product)item;
                if (criteria(product))
                    result.Add(product);
            }
            return result;
        }
    }

    public interface IProductSearchCriteria
    {
        bool IsSatisfiedBy(Product product);
    }
}