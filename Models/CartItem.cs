namespace ShoppingCart.Models
{
    public class CartItem
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total
        {

            get { return Quantity * Price; }

        }
        public string image {  get; set; }

       // public string CartItem() { }
       

        public string CartItems(Product  product)
        {
            ProductId= (int)product.Id;
            ProductName=product.Name;
            Price = product.Price;
            Quantity = 1;
            image=product.Image;
            return image;

        }

    }

}
