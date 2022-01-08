using FreshMvvm;
using Imi.Project.Mobile.Core.Extensions;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.PageModels
{
    public class ProductsPageModel: FreshBasePageModel
    {
        private IProductService _productService;

        private ObservableCollection<Product> products;

        public ProductsPageModel(IProductService productService)
        {
            _productService = productService;
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                RaisePropertyChanged();
            }
        }

        private void OnProductTapped(Product selectedProduct)
        {
            CoreMethods.PushPageModel<ProductDetailPageModel>(selectedProduct, false, true);
        }

        public override async void Init(object data)
        {
            Products = (await _productService.GetAll()).ToObservableCollection();
        }
    }
}
