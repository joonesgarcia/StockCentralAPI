﻿namespace StockCentralAPI.Models;

public interface IUser
{
    Guid Id { get; set; }   
    string Name { get; set; }
}
