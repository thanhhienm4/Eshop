using eShopSolution.Application.Common;
using eShopSolution.ViewModels.Catalog.ProductImages;
using EshopSolution.Data.EF;
using EshopSolution.Data.Entities;
using EshopSolution.Utilities.Constants;
using EshopSolution.Utilities.Exceptions;
using EshopSolution.ViewModel.Catalog.Products;
using EshopSolution.ViewModel.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EshopSolution.Application.Cacalog.Products
{
    public class ProductService : IProductService
    {
        private readonly EshopDbContext _context;
        private readonly IStorageService _storageService;
        private readonly ICategoryService _categoryService;

        public ProductService(EshopDbContext context, IStorageService storageService,
                              ICategoryService categoryService)
        {
            _context = context;
            _storageService = storageService;
            _categoryService = categoryService;
        }

        public async Task<ApiResult<bool>> Create(ProductCreateRequest request)
        {
            List <Language> languages =await _context.Languages.ToListAsync();
            List<ProductTranslation> productTranslations = new List<ProductTranslation>();
            foreach(var language in languages)
            {
                if(request.LanguageId == language.Id)
                {
                    productTranslations.Add(new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoTitle = request.SeoTitle,
                        SeoAlias = request.SeoAlias,
                        LanguageId = request.LanguageId
                    });
                }else
                {
                    productTranslations.Add(new ProductTranslation()
                    {
                        Name = "",
                        Description = "",
                        Details = "",
                        SeoDescription = "",
                        SeoTitle = "",
                        SeoAlias = "",
                        LanguageId = language.Id
                    });
                }
            }

            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.Price,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                IsFeatured = request.isFeatured,
                ProductTranslations = productTranslations
                
            };
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption =  "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath =  await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }

            _context.Products.Add(product);
            if (_context.SaveChanges() == 0)
            {
                return new ApiErrorResult<bool>("Đăng kí không thành công");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(ProductUpdateRequest request)
        {
            //1.find product and producttranslation
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);
            if (product == null && productTranslation == null)
                throw new EshopException($"Không thể thìm thấy sản phẩm có id {request.Id}");

            //2.Update producttranslation
            if (productTranslation == null)              
            {
                productTranslation = new ProductTranslation() {
                ProductId = request.Id,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
                SeoAlias = request.SeoAlias,
                SeoTitle = request.SeoTitle,
                SeoDescription = request.SeoDescription,
                LanguageId = request.LanguageId
                };
                await _context.ProductTranslations.AddAsync(productTranslation);
               
            }else
            {
                productTranslation.Name = request.Name;
                productTranslation.Description = request.Description;
                productTranslation.Details = request.Details;
                productTranslation.SeoAlias = request.SeoAlias;
                productTranslation.SeoTitle = request.SeoTitle;
                productTranslation.SeoDescription = request.SeoDescription;
                _context.ProductTranslations.Update(productTranslation);

            }
            product.IsFeatured = request.isFeatured;

            //3.Save
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(x => x.ProductId == product.Id && x.IsDefault == true);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            _context.Products.Update(product);
            
            if (_context.SaveChanges() == 0)
            {
                return new ApiErrorResult<bool>();
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int ProductId)
        {
            var product = await _context.Products.FindAsync(ProductId);
            var images = _context.ProductImages.Where(x => x.ProductId == product.Id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
            _context.Products.Remove(product);
            if (_context.SaveChanges() == 0)
            {
                return new ApiErrorResult<bool>("Can't not delete product");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EshopException($"Can't find product with id {productId}");
            product.Price = newPrice;
            if (_context.SaveChanges() == 0)
            {
                return new ApiErrorResult<bool>();
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EshopException($"Can't find product with id {productId}");
            product.Stock += addedQuantity;
            if (_context.SaveChanges() == 0)
            {
                return new ApiErrorResult<bool>();
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1.Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId into ppt
                        from pt in ppt.DefaultIfEmpty()
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId into ppic
                        from pic in ppic.DefaultIfEmpty()

                        select new { p, pt, pic };

            //2.Filter
            //find whit category
            if (request.CategoryId != 0)
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);

            //find whit languageId
            query = query.Where(x => x.pt.LanguageId == request.LanguageId || x.pt == null);

            //find whit keyword
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword)).
                              Where(x => x.pt.Details.Contains(request.Keyword)).
                              Where(x => x.pt.Description.Contains(request.Keyword)).
                              Where(x => x.pt.SeoAlias.Contains(request.Keyword)).
                              Where(x => x.pt.SeoDescription.Contains(request.Keyword)).
                              Where(x => x.pt.SeoTitle.Contains(request.Keyword));

            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.Id,
                    Name = string.IsNullOrEmpty(x.pt.Name) ? SystemConstants.NotAvailable : x.pt.Name,
                    Description = string.IsNullOrEmpty(x.pt.Description) ? SystemConstants.NotAvailable : x.pt.Description,
                    Details = string.IsNullOrEmpty(x.pt.Details) ? SystemConstants.NotAvailable : x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.Price,
                    Price = x.p.Price,
                    SeoAlias = string.IsNullOrEmpty(x.pt.SeoAlias) ? SystemConstants.NotAvailable : x.pt.SeoAlias,
                    SeoDescription = string.IsNullOrEmpty(x.pt.SeoDescription) ? SystemConstants.NotAvailable : x.pt.SeoDescription,
                    SeoTitle = string.IsNullOrEmpty(x.pt.SeoTitle) ? SystemConstants.NotAvailable : x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated,
                }).Distinct().ToListAsync();

            //4.Select and Projection
            var pageResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Item = await data,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            return new ApiSuccessResult<PageResult<ProductViewModel>>(pageResult);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            string originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ApiResult<bool>> AddImages(int productId, ProductImageCreateRequest request)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EshopException($"Can't find Product with Id {productId}");
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                ProductId = productId,
                IsDefault = request.IsDefault,
                SortOrder = request.SortOrder,
                DateCreated = DateTime.Now
            };
            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            if (_context.SaveChanges() == 0)
                return new ApiErrorResult<bool>();
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> DeleteImages(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new EshopException($"Can't find ProductImage with Id {imageId}");
            else
            {
                _context.ProductImages.Remove(image);
                if (_context.SaveChanges() == 0)
                    return new ApiErrorResult<bool>();
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<bool>> UpdateImages(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EshopException($"Can't find ProductImage with Id {imageId}");
            else
            {
                productImage.Caption = request.Caption;
                productImage.IsDefault = request.IsDefault;
                productImage.SortOrder = request.SortOrder;
                productImage.FileSize = request.ImageFile.Length;
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                if (_context.SaveChanges() == 0)
                    return new ApiErrorResult<bool>();
                return new ApiSuccessResult<bool>();
            }
        }

        public async Task<ApiResult<ProductViewModel>> GetById(int productId, string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            var proudctTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(pt => pt.ProductId == productId && pt.LanguageId == languageId);
            if (product == null)
                throw new EshopException($"Can't find product with id {productId}");
            var productViewModel = new ProductViewModel()
            {
                ProductId = product.Id,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
                DateCreated = product.DateCreated,
                IsFeatured = product.IsFeatured,
                Name = proudctTranslation == null ? "" :proudctTranslation.Name,
                Description = proudctTranslation == null ? "" : proudctTranslation.Description,
                Details = proudctTranslation == null ? "" : proudctTranslation.Details,
                SeoDescription = proudctTranslation == null ? "" : proudctTranslation.SeoDescription,
                SeoTitle = proudctTranslation == null ? "" : proudctTranslation.SeoDescription,
                SeoAlias = proudctTranslation == null ? "" : proudctTranslation.SeoAlias,
                LanguageId = proudctTranslation == null ? "" : proudctTranslation.LanguageId,
                Categories = await GetCategoryOfProductId(productId, languageId)
            };
            return new ApiSuccessResult<ProductViewModel>(productViewModel);
        }

        public async Task<ApiResult<ProductImageViewModel>> GetImageById(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new EshopException($"Can't find Image with ImageId {imageId}");
            var pIVM = new ProductImageViewModel()
            {
                Id = productImage.Id,
                ProductId = productImage.ProductId,
                ImagePath = productImage.ImagePath,
                Caption = productImage.Caption,
                IsDefault = productImage.IsDefault,
                DateCreated = productImage.DateCreated,
                SortOrder = productImage.SortOrder,
                FileSize = productImage.FileSize
            };
            return new ApiSuccessResult<ProductImageViewModel>(pIVM);
        }

        public async Task<ApiResult<List<ProductImageViewModel>>> GetListImages(int productId)
        {
            var listPIVM = await _context.ProductImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
            return new ApiSuccessResult<List<ProductImageViewModel>>(listPIVM);
        }

        public async Task<ApiResult<PageResult<ProductViewModel>>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId into ppt
                        from pt in ppt.DefaultIfEmpty()
                        where (pt.LanguageId == languageId || pt == null)
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                       
                        select new { p, pt, pic };

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryId);
            }
            int totalRow = await query.CountAsync();
            var data = query.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Price = x.p.Price,
                    OriginalPrice = x.p.OriginalPrice,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated,
                    ProductId = x.p.Id,
                    Name = x.pt.Name == null ? SystemConstants.NotAvailable : x.pt.Name,
                    Description = x.pt.Description== null ? SystemConstants.NotAvailable : x.pt.Description,
                    Details = x.pt.Details== null ? SystemConstants.NotAvailable : x.pt.Details,
                    SeoDescription = x.pt.SeoDescription== null ? SystemConstants.NotAvailable : x.pt.SeoDescription,
                    SeoTitle =x.pt.SeoTitle== null ? SystemConstants.NotAvailable : x.pt.SeoTitle,
                    SeoAlias = x.pt.SeoAlias== null ? SystemConstants.NotAvailable : x.pt.SeoAlias
                });
            var pageResult = new PageResult<ProductViewModel>()
            {
                Item = (List<ProductViewModel>)data,
                TotalRecord = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

            return new ApiSuccessResult<PageResult<ProductViewModel>>(pageResult);
        }

        public async Task<ApiResult<bool>> CategoryAssign(CategoryAssignRequest request)
        {
            if (!(await _context.Products.AnyAsync(x => x.Id == request.Id)))
            {
                return new ApiErrorResult<bool>("Id sản phẩm không tồn tại ");
            }

            foreach (SelectedItem category in request.Categories)
            {
                var productInCategory = _context.ProductInCategories.SingleOrDefault(x =>
                   x.ProductId == request.Id && x.CategoryId == Int32.Parse(category.Id));

                if (category.Selected == false)
                {
                    if (productInCategory != null)
                    {
                        _context.ProductInCategories.Remove(productInCategory);
                    }
                }
                else
                {
                    if (productInCategory == null)
                    {
                        await _context.ProductInCategories.AddAsync(new ProductInCategory()
                        {
                            ProductId = request.Id,
                            CategoryId = Int32.Parse(category.Id)
                        });
                    }
                }
            }
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }

        public async Task<List<string>> GetCategoryOfProductId(int id, String languageId)
        {
            var query = from pic in _context.ProductInCategories
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where id == pic.ProductId && ct.LanguageId == languageId
                        select ct.Name;

            List<string> categoriesName = await query.Select(x => new string(x.ToString())).ToListAsync();
            return categoriesName;
        }
        public async Task<ApiResult<List<ProductViewModel>>> GetFeaturedProducts(string languageId,int number)
        {
            //1.Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where p.IsFeatured == true && pt.LanguageId == languageId && (pi.IsDefault == true || pi == null)
                        select new { p, pt, pi };

            var data = await query.OrderBy(x => x.p.ViewCount)
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.Price,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated,
                    ThumbnailImage = $"{SystemConstants.ServerSettings.ServerBackEnd}/" +
                    $"{FileStorageService.USER_CONTENT_FOLDER_NAME}/{x.pi.ImagePath}"

                }).Distinct().Take(number).ToListAsync();

            return new ApiSuccessResult<List<ProductViewModel>>(data);
        }
        public async Task<ApiResult<List<ProductViewModel>>> GetLatestProducts(string languageId, int number)
        {
            //1.Select
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where pt.LanguageId == languageId && (pi.IsDefault == true || pi == null)
                        select new { p, pt, pi };

            var data = await query.OrderBy(x => x.p.DateCreated)
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.p.Id,
                    Name = x.pt.Name,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.Price,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    DateCreated = x.p.DateCreated,
                    ThumbnailImage = $"{SystemConstants.ServerSettings.ServerBackEnd}/" +
                    $"{FileStorageService.USER_CONTENT_FOLDER_NAME}/{x.pi.ImagePath}"

                }).Distinct().Take(number).ToListAsync();

            return new ApiSuccessResult<List<ProductViewModel>>(data);
        }


    }
}