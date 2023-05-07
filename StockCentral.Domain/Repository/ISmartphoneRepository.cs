using StockCentral.Domain.Models.InputModel;
using StockCentral.Domain.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockCentral.Domain.Repository
{
    public interface ISmartphoneRepository
    {
        public IEnumerable<SmartphoneViewModel> GetAll();
        public SmartphoneViewModel GetById(Guid id);
        public HttpStatusCode Add(SmartphoneInputModel model);
        public HttpStatusCode Update(SmartphoneUpdateModel model);
        public HttpStatusCode Delete(Guid id);
    }
}
