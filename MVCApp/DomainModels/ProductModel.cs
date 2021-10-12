using System;
using System.Web;

namespace DomainModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase File { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

