﻿namespace Domain.Entities;

public class Room
{
    public string Name { get; set; }
    public ushort GuestsCapacity { get; set; }
    public bool IsAvailable { get; set; }
    
    public virtual Hotel Hotel { get; set; }
}