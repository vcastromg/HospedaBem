﻿namespace Domain.Entities;

public class Room: BaseEntity
{
    public ushort Number { get; set; }
    public ushort GuestsCapacity { get; set; }
    public bool IsAvailable { get; set; }
    public double Price { get; set; }
    
    public virtual Hotel Hotel { get; set; }
}