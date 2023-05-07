using StockCentral.Domain.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCentral.Domain.Repository
{
    public interface IExcelPayloadRepository
    {
        public int Load(List<ExcelRowInputModel> model);
    }
}
