
using eShopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EshopSolution.Application
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int ProductId);
       
        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int addedQuantity);

        Task<int> AddImages(ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageId);
        Task<int> UpdateImages(ProductImageCreateRequest request);

        Task AddViewCount(int productId);
        Task<ProductViewModel> GetById(int productId, string languageId);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PageResult<ProductViewModel>> GetAllByCategoryId( GetPublicProductPagingRequest request);



    }
}
