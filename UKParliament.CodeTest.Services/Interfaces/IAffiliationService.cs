﻿using UKParliament.CodeTest.Data.Models;

namespace UKParliament.CodeTest.Services.Interfaces
{
    public interface IAffiliationService
    {
        List<Affiliation> GetAll();
        Affiliation Get(int id);
    }
}
