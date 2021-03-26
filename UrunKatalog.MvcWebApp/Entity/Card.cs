using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunKatalog.MvcWebApp.Entity
{
    public class Card
    {
        private List<CardLine> _cardLines = new List<CardLine>();

        public List<CardLine> CardLines
        {
            get { return _cardLines;  }
        }

        public void AddProduct(Product product , int quantity )
        {
            var line = _cardLines.FirstOrDefault(i => i.Product.Id == product.Id);

            if (line == null)
            {
                _cardLines.Add(new CardLine()
                                {
                                    Product = product,
                                    Quantity = quantity
                                }
                                );
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cardLines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public void ClearCard()
        {
            _cardLines.Clear();
        }

        public double Total()
        {
            return _cardLines.Sum(i => i.Product.Price * i.Quantity);
        }

    }

    public class CardLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}