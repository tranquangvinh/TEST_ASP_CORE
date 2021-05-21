using Business.Reponsitories.Interface;
using CoreAPI.Reponsitories.ModelsRepository;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreAPI.Reponsitories.Repository
{
    public class PopulationRepository : IPopulationRepository
    {
        protected readonly TestAPIContext Context;

        public PopulationRepository(TestAPIContext context)
        {
            Context = context;
        }
        public List<PopulationModel> Get(List<int> state)
        {
            List<PopulationModel> lstPopulation = new List<PopulationModel>();
            try
            {
                foreach (var item in state)
                {
                    var actuals = Context.Actuals.Where(x => x.State == item).FirstOrDefault();
                    if (actuals != null)
                    {
                        lstPopulation.Add(new PopulationModel()
                        { State = item, Population = actuals.ActualPopulation.ToString() });
                    }
                    else
                    {
                        var estimates = Context.Estimates.Where(x => x.State == item);
                        lstPopulation.Add(new PopulationModel()
                        { State = item, Population = estimates.Sum(x => x.EstimatesPopulation).ToString() });
                    }
                }
                return lstPopulation;
            }
            catch
            {
                return new List<PopulationModel>();
            }

        }

    }
}
