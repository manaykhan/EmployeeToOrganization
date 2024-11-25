
using AutoMapper;
using CrudAPI.AppDataContext;
using CrudAPI.Contracts;
using CrudAPI.Interface;
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudAPI.Services
{

    public class EmployeeServices : IEmployeeServices
    {
        private readonly EmployeeDbContext _context;
        private readonly ILogger<EmployeeServices> _logger;
        private readonly IMapper _mapper;
        
        public EmployeeServices(EmployeeDbContext context, ILogger<EmployeeServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // CREATE
        public async Task CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            try
            {
                var emp = _mapper.Map<Employee>(request);
                emp.CreatedAt = DateTime.UtcNow;
                _context.Employees.Add(emp);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the Emp item.");
                throw new Exception("An error occurred while creating the Emp item.");
            }
        }

        // DELETE
        public Task DeleteEmployeeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        // READ
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var emp = await _context.Employees.ToListAsync();
            if (emp == null || emp.Count == 0)
            {
                throw new Exception(" No Employee record.");
            }
            return emp;
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        // UPDATE
        public Task UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}