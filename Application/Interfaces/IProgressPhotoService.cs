using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

public interface IProgressPhotoService
{
    Task<IEnumerable<ProgressPhotoDto>> GetAllAsync();
    Task<ProgressPhotoDto> GetByIdAsync(int id);
    Task<ProgressPhotoDto> CreateAsync(ProgressPhotoDto photo);
    Task<ProgressPhotoDto> UpdateAsync(int id, ProgressPhotoDto photo);
    Task<bool> DeleteAsync(int id);
}
