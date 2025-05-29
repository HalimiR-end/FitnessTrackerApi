using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

public interface IMeasurementService
{
    Task<IEnumerable<MeasurementDto>> GetAllAsync();
    Task<MeasurementDto> GetByIdAsync(int id);
    Task<MeasurementDto> CreateAsync(MeasurementDto measurement);
    Task<MeasurementDto> UpdateAsync(int id, MeasurementDto measurement);
    Task<bool> DeleteAsync(int id);
}