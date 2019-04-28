using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OtherPerspectivesWebApp.Data;
using SQLitePCL;

namespace OtherPerspectivesWebApp.Models
{
    public class Cart
    {
        private readonly OtherPerspectivesContext _dbContext;

        public Cart(OtherPerspectivesContext context)
        {
            _dbContext = context;
        }
        
        public string CartId { get; set; }
        public IEnumerable<Item> Items { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<OtherPerspectivesContext>();
            string cartId = session.GetString("CartId") ?? new Guid().ToString();
            
            session.SetString("CartId", cartId);

            return new Cart(context) {CartId = cartId};
        }

        public void AddItem(Product product, int amount)
        {
            var cartItem = _dbContext.Items.SingleOrDefault(x => x.Product.Id == product.Id && x.CartId == CartId);

            if (cartItem == null)
            {
                cartItem = new Item
                {
                    CartId = CartId,
                    Product = product,
                    Quantity = 1
                };
                _dbContext.Items.Add(cartItem);
            }

            else
            {
                cartItem.Quantity++;
            }

            _dbContext.SaveChanges();
        }

        public int RemoveItem(Product product)
        {
            var cartItem = _dbContext.Items.SingleOrDefault(x => x.Product.Id == product.Id && x.CartId == CartId);

            var amountInCart = 0;
            
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    
                    amountInCart = cartItem.Quantity;
                }
                else
                {
                    _dbContext.Items.Remove(cartItem);
                }

                _dbContext.SaveChanges();
            }
            
            return amountInCart;
        }

        public IEnumerable<Item> GetCartItems()
        {
            return Items ?? (Items = _dbContext.Items.Where(x => x.CartId == CartId).Include(y => y.Product).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _dbContext.Items.Where(x => x.CartId == CartId);
            
            _dbContext.Items.RemoveRange(cartItems);

            _dbContext.SaveChanges();
        }

        public double GetCartTotal()
        {
            return _dbContext.Items.Where(x => x.CartId == CartId).Select(y => y.Product.Price * y.Quantity).Sum();
        }
    }
}