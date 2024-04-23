﻿using Domain.Entities;

namespace Application.Repositories;

public interface HotelRepository: BaseRepository<Hotel>
{
    public ICollection<string> GetLastRegisteredHotelNames();
}