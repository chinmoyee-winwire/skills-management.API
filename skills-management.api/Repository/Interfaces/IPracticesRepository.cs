﻿using skills_management.api.Models;

namespace skills_management.api.Repository.Interfaces
{
    public interface IPracticesRepository
    {
        Task<IEnumerable<Practices>> GetAllPractices();
    }
}
