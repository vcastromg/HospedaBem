﻿using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Implementations;

public class HotelRepositoryImp : BaseRepositoryImp<Hotel>, HotelRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public HotelRepositoryImp(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public ICollection<string> GetLastRegisteredHotelNames()
    {
        return Query()
            .AsNoTracking()
            .OrderByDescending(q => q.CreatedAt)
            .Select(q => q.Name)
            .ToList();
    }

    public ICollection<Hotel> GetHotelsByRate(double rate)
    {
        return Query()
            .AsNoTracking()
            .OrderByDescending(q => q.Rate)
            .Select(q => q)
            .ToList();
    }
}