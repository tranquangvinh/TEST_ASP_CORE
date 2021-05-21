using Business.Reponsitories.Interface;
using CoreAPI.Reponsitories.Interface;
using CoreAPI.Reponsitories.ModelsRepository;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreAPI.Reponsitories.Repository
{
    public class HouseHoldsRepository : IHouseHoldsRepository
    {
        protected readonly TestAPIContext Context;
        public HouseHoldsRepository(TestAPIContext context)
        {
            Context = context;
        }

        public List<HouseHoldsModel> Get(List<int> state)
        {
            List<HouseHoldsModel> lstHousehold = new List<HouseHoldsModel>();
            try
            {
                foreach (var item in state)
                {
                    var actuals = Context.Actuals.Where(x => x.State == item).FirstOrDefault();
                    if (actuals != null)
                    {
                        lstHousehold.Add(new HouseHoldsModel()
                        { State = item, HouseHolds = actuals.ActualHouseholds.ToString() });
                    }
                    else
                    {
                        var estimates = Context.Estimates.Where(x => x.State == item);
                        lstHousehold.Add(new HouseHoldsModel()
                        { State = item, HouseHolds = estimates.Sum(x => x.EstimatesHouseholds).ToString() });

                    }
                }
            }
            catch
            {
                return new List<HouseHoldsModel>();
            }
            return lstHousehold;
        }
    }
}
