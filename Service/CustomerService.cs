using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitHub.Libary.DataBase.Context;
using FitHub.Libary.DataBase.Entities;
using FitHub.Libary.View.Dto;
using LinqToDB;

namespace FitHub.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly FitHubContext _dbContext;
        public CustomerService(FitHubContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Result<string?> AddCustomer(string name, string address, string city, string status, string country, string zip)
        {
            var result = new Result<string?>();
            try
            {
                var goal = _dbContext.Customer.Where(x => x.Name == name).FirstOrDefault();
                if (goal != null)
                {
                    result.ErrorMessage = "data is exist";
                    return result;
                }
                var customer = new Customer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Address = address,
                    City = city,
                    Country = country,
                    State = status,
                    Zip = zip,
                    Status = 1,
                    Uid = Guid.NewGuid().ToString()
                };
                _dbContext.Customer.Add(customer);
                _dbContext.SaveChanges();
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;

        }
        public Result<string?> UpdateCustomer(string custometId, string name, string address, string city, string status, string country, string zip)
        {
            var result = new Result<string?>();
            try
            {
                var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == custometId);
                if (customer != null)
                {
                    customer.Name = name;
                    customer.Address = address;
                    customer.City = city;
                    customer.Country = country;
                    customer.State = status;
                    customer.Zip = zip;
                    _dbContext.Update(customer);
                    _dbContext.SaveChanges();
                    result.StatusCode = 200;
                }
                else
                {
                    result.StatusCode = 404;
                    result.ErrorMessage = "Customer not found";
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;

        }
        public Result<string?> DelCustomer(string custometId)
        {
            var result = new Result<string?>();
            try
            {
                var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == custometId);
                if (customer != null)
                {
                    _dbContext.Customer.Remove(customer);
                    _dbContext.SaveChanges();
                    result.StatusCode = 200;
                }
                else
                {
                    result.StatusCode = 404;
                    result.ErrorMessage = "Customer not found";
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;


        }
        public Result<CustomerDto> GetCustomer(string customerId)
        {
            var result = new Result<CustomerDto>();
            try
            {
                var customer = _dbContext.Customer.FirstOrDefault(x => x.Id == customerId);
                if (customer != null)
                {
                    var customerDto = new CustomerDto()
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Address = customer.Address,
                        City = customer.City,
                        Country = customer.Country,
                        State = customer.State,
                        Zip = customer.Zip
                    };
                    result.Items = customerDto;
                    result.StatusCode = 200;
                }
                else
                {
                    result.StatusCode = 404;
                    result.ErrorMessage = "Customer not found";
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;

        }
        public Result<CustomerPageDto> GetCustomerList(int pageNo, int pageSize)
        {
            var result = new Result<CustomerPageDto>();
            try
            {
                var customerList = _dbContext.Customer.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
                var customerPageDto = new CustomerPageDto()
                {
                    PageNo = pageNo,
                    PageSize = pageSize,
                    Total = _dbContext.Customer.Count(),
                    TotalPage = _dbContext.Customer.Count() / pageSize,
                    Items = new List<CustomerDto>()
                };
                foreach (var customer in customerList)
                {
                    var customerDto = new CustomerDto()
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Address = customer.Address,
                        City = customer.City,
                        Country = customer.Country,
                        State = customer.State,
                        Zip = customer.Zip
                    };
                    customerPageDto.Items.Add(customerDto);
                }
                result.Items = customerPageDto;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;

        }
        public Result<List<CustomerDto>> GetFilterCustomerList(string name, string address, string city, string status, string country, string zip)
        {
            var result = new Result<List<CustomerDto>>();
            try
            {
                var customerList = _dbContext.Customer.Where(x => x.Name.Contains(name) || x.Address.Contains(address) || x.City.Contains(city) || x.State.Contains(status) || x.Country.Contains(country) || x.Zip.Contains(zip)).ToList();
                var customerDtoList = new List<CustomerDto>();
                foreach (var customer in customerList)
                {
                    var customerDto = new CustomerDto()
                    {
                        CustomerId = customer.Id,
                        Name = customer.Name,
                        Address = customer.Address,
                        City = customer.City,
                        Country = customer.Country,
                        State = customer.State,
                        Zip = customer.Zip
                    };
                    customerDtoList.Add(customerDto);
                }
                result.Items = customerDtoList;
                result.StatusCode = 200;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.StatusCode = 500;
            }
            return result;

        }



    }
}