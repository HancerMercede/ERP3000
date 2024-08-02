﻿using ERP3000.Entities;
using ERP3000.Repository.Conctracts;
using ERP3000.Service.Contracts;

namespace ERP3000.Service;

public class OrderService : IOrderService
{
    private readonly IRepositoryManager _repositoryManager;

    public OrderService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public Task<Order> CreateCompany(Order order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCompany(Guid Id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetAll(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public async Task<Order> GetByCondiction(Guid Id, bool trackChanges)
    {
        var order = await _repositoryManager.Order.GetByCondiction(Id, trackChanges);
        return order;
    }

    public Task<IEnumerable<Order>> GetByIds(IEnumerable<Guid> Ids, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}
