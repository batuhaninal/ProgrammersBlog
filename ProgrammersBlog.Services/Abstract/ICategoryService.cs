﻿using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<CategoryDto>> GetAsync(int categoryId);

        /// <summary>
        /// Verilen ID parametresine ait kategorinin CategoryUpdateDto temsilini geriye doner.
        /// </summary>
        /// <param name="categoryId">0'dan buyuk integer bir ID degeri</param>
        /// <returns>Asenkron bir operasyon ile Task olarak islem sonucu DataResult tipinde geriye doner.</returns>
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CategoryListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<CategoryListDto>> GetAllByDeletedAsync();

        /// <summary>
        /// Verilen categoryAddDto ve createdByName parametrelerine ait bilgiler ile yeni bir Category ekler.
        /// </summary>
        /// <param name="categoryAddDto">categoryAddDto tipinde eklenecek Category bilgileri.</param>
        /// <param name="createdByName">String tipinde kullanicinin kullanici adi.</param>
        /// <returns>Asenkron bir operasyon ile Task olarak isleminin sonucunu DataResult tipinde doner.</returns>
        Task<IDataResult<CategoryDto>> AddAsync(CategoryAddDto categoryAddDto, string createdByName);
        Task<IDataResult<CategoryDto>> UpdateAsync(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IDataResult<CategoryDto>> DeleteAsync(int categoryId, string modifiedByName);
        Task<IDataResult<CategoryDto>> UndoDeleteAsync(int categoryId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int categoryId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
