using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Interfaces;
public interface ILoadRepository<T> where T : class
{
    Task <IReadOnlyList<T>> GetAllAsync();
    Task GetByIdAsync(int id);
}

public interface ISaveRepository<T> where T : class
{
    Task<int> AddAsync(T entity);
    Task<int> UpdateAsync(T entity);
}

