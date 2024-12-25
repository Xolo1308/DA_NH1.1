namespace DA_NH.Models
{
    public class CartItemModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity {  get; set; }

        public int Price { get; set; }
        public string? Image { get; set; }
        public int Total {  
            get {  return Quantity*Price; }
         }
        public CartItemModel()
        {   

        }
        public CartItemModel(MenuItem menuitem)
        {
            ProductId = menuitem.MenuItemId;
            ProductName = menuitem.Name;
            Price = menuitem.Price;
            Quantity = 1;
            Image = menuitem.ImageUrl;


        }
        

       

     
    }
}
