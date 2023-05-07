using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StockCentral.Domain.Models;
using StockCentral.Domain.Models.InputModel;
using StockCentral.Domain.Models.ViewModel;
using StockCentral.Domain.Repository;

namespace StockCentral.Infrastructure.EF.EFCoreRepository
{
    class EFCoreSmartphoneRepository : ISmartphoneRepository
    {
        private readonly AppDbContext _context;
        public EFCoreSmartphoneRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public HttpStatusCode Add(SmartphoneInputModel model)
        {
            _context.Stock.Add(new Smartphone(model));
            _context.SaveChanges();
            return HttpStatusCode.Created;
        }

        public HttpStatusCode Delete(Guid id)
        {
            var smartphone = _context.Smartphones.SingleOrDefault(s => s.Id == id);
            if (smartphone == null)
                return HttpStatusCode.NotFound;
            else
                _context.Smartphones.Remove(smartphone);
            _context.SaveChanges();
            return HttpStatusCode.OK;
        }

        public IEnumerable<SmartphoneViewModel> GetAll()
        {
            return _context.Smartphones.Select(s =>
                new SmartphoneViewModel(
                    s.Name,
                    s.Memory,
                    s.Acessories,
                    s.Status.ToString(),
                    s.CostPrice,
                    s.SoldPrice
                )
            ).ToList();
        }

        public SmartphoneViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode Update(SmartphoneUpdateModel model)
        {
            var smartphone = _context.Smartphones.SingleOrDefault(s => s.Id == model.id);

            if (smartphone == null)
                return HttpStatusCode.NotFound;
            else
                smartphone.UpdateSmartphone(model);

            _context.SaveChanges();
            return HttpStatusCode.NoContent;
        }
    }
}
