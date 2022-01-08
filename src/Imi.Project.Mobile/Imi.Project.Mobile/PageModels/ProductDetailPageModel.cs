using FreshMvvm;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.PageModels
{
    public class ProductDetailPageModel: FreshBasePageModel
    {
        private Product selectedProduct;

        public ProductDetailPageModel()
        {

        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set 
            { 
                selectedProduct = value;
                RaisePropertyChanged();
            }
        }

        public override async void Init(object product)
        {
            SelectedProduct = (Product)product;
        }
    }
}
