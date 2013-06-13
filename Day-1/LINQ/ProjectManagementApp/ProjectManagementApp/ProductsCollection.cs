using System.Collections;

namespace ProjectManagementApp
{
    public class ProductsCollection
    {
        private ArrayList _list = new ArrayList();

        public int Count { get { return _list.Count; } }

        public void Add(Product product)
        {
            _list.Add(product);
        }

        public Product GetByIndex(int index)
        {
            return (Product) _list[index];
        }
    }
}