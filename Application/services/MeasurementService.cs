using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        public Task<IEnumerable<MeasurementDto>> GetAllAsync() =>
            Task.FromResult<IEnumerable<MeasurementDto>>(new List<MeasurementDto>());

        public Task<MeasurementDto?> GetByIdAsync(int id) =>
            Task.FromResult<MeasurementDto?>(null);

        public Task<MeasurementDto> CreateAsync(MeasurementDto dto) =>
            Task.FromResult(dto);

        public Task<MeasurementDto> UpdateAsync(int id, MeasurementDto dto) =>
            Task.FromResult(dto);

        public Task<bool> DeleteAsync(int id) =>
            Task.FromResult(true);
    }
}
