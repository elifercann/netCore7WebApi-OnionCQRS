using Application.Bases;
using Application.Features.Products.Exception;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Rules
{
    public class ProductRules:BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products,string requestTitle)
        {
            if (products.Any(x => x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}
