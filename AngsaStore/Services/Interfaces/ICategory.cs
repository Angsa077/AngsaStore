using AngsaStore.Models;
using AngsaStore.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngsaStore.Services.Interfaces
{
    public interface ICategory
    {
        MasterCategory GetCategoryDetail(int id);
        List<MasterCategory> GetCategoryData();
        DatabaseActionResultModel SaveData(MasterCategory model);
        DatabaseActionResultModel UpdateDate(MasterCategory model);
        
        IQueryable<MasterCategory> GetData(DataTableBindingModel args);
        bool Create(MasterCategory param);
        bool Update(MasterCategory model);
        bool UpSert(MasterCategory param);
        bool Delete(MasterCategory param);
        MasterCategory Detail(int id);

        bool CreateTransaction(MasterCategory param);
        bool SampleTransaction(MasterCategory param);
        bool CreateTransaction1(MasterCategory param);
        MasterCategory ProcessTransactionUpdate1(MasterCategory param);
        bool ProcessTransactionUpdate2(MasterCategory param);
        bool ProcessData(MasterCategory param);

    }
}
