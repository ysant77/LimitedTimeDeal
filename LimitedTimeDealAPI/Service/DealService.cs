using LimitedTimeDealAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitedTimeDealAPI.Service
{
    public class DealService
    {
        private readonly LimitedTimeDealDbContext _context;
        public DealService(LimitedTimeDealDbContext context)
        {
            _context = context;
        }

        public List<Deal> GetDeals()
        {
            return _context.Deals.ToList();
        }
        public object ClaimDeal(int dealId)
        {
            var existingDeal = _context.Deals.ToList().Find(d => d.Id == dealId);
            if (existingDeal == null)
                return null;
            if(existingDeal.ExpirationDate < DateTime.Now || existingDeal.IsActive == false
                || existingDeal.Items == 0)
            {

                return null;
                
            }
            _context.Deals.Remove(existingDeal);
            _context.SaveChanges();
            existingDeal.Items -= 1;
            _context.Deals.Add(existingDeal);
            return existingDeal;

        }

        

        public Deal UpdateDeal(int dealId, Deal deal)
        {
            try
            {
                var existingDeal = _context.Deals.ToList().Find(d => d.Id == dealId);
                _context.Deals.Remove(existingDeal);
                _context.Deals.Add(deal);
                _context.SaveChanges();
                return deal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Deal> EndDeal(int dealId)
        {
            var deal = _context.Deals.ToList().Find(d => d.Id == dealId);
            deal.IsActive = false;
            return UpdateDeal(dealId, deal);
        }

        public async Task<int> CreateDeal(Deal deal)
        {
            try
            {
                var result = await _context.Deals.AddAsync(deal);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {

                return -1;
            }
            
        }
    }
}
