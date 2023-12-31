﻿using LearningCenter.API.Security.Domain.Models;

namespace LearningCenter.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public int RoleId { get; set; }
}