using CoreAPI.Reponsitories.Interface;
using CoreAPI.Reponsitories.ModelsRepository;
using CoreAPI.Reponsitories.Repository;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.UnitOfWorks
{
    public class UnitOfWork
    {
        private readonly TestAPIContext _context;
        public UnitOfWork(TestAPIContext context)
        {
            _context = context;
            HouseHold = new HouseHoldsRepository(_context);
            Population = new PopulationRepository(_context);
        }
        public HouseHoldsRepository HouseHold { get; private set; }
        public PopulationRepository Population { get; private set; }
    }
}
