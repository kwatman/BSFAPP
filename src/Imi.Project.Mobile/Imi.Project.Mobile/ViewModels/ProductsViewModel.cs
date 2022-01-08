using FreshMvvm;
using Imi.Project.Mobile.Core.Extensions;
using Imi.Project.Mobile.Core.Interfaces.IServices;
using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class ProductsViewModel: FreshBasePageModel
    {
        private IProductService _productService;

        private ObservableCollection<Product> products;

        public ProductsViewModel(IProductService productService)
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
            CoreMethods.PushPageModel<ProductDetailViewModel>(selectedProduct, false, true);
        }

        public override async void Init(object data)
        {
            Products = (await _productService.GetAll()).ToObservableCollection();
        }
    }
}
