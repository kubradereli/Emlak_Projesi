﻿using Emlak_Projesi.Dtos.ProductDtos;

namespace Emlak_Projesi.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id);

        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

        void ProductDealOfTheDayStatusChangeToTrue(int id);

        void ProductDealOfTheDayStatusChangeToFalse(int id);

        Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync();

        Task CreateProduct(CreateProductDto createProductDto);
    }
}
