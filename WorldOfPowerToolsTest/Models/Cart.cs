namespace WorldOfPowerToolsTest.Models
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new();

        public virtual void AddItem(Product product, int quantity)
        {
            var cartLine = _lineCollection.Where(l => l.Product.Id == product.Id).FirstOrDefault();
            if (cartLine == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) => _lineCollection.RemoveAll(l => l.Product.Id == product.Id);

        public decimal ComputeTotalValue() => _lineCollection.Sum(l => l.Product.Price * l.Quantity);

        public virtual void Clear() => _lineCollection.Clear();

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}