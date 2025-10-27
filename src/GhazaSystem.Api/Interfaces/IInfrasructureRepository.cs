﻿using GhazaSystem.Api.DTOs;
using GhazaSystem.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace GhazaSystem.Api.Interfaces
{
    public interface IInfrasructureRepository<T> where T : class
    {
        Task<Response<List<T>>> GetAllAsync();
        Task<Response<T>> GetByIdAsync(Guid id);
        Task<Response<T>> AddAsync(T model);
        Task<Response<T>> UpdateAsync(T model);
        Task<Response<object>> DeleteAsync(Guid id);
    }
}
