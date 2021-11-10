using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IPurchaseService
    {
        Task<int> GetAllMoviesByUserId(int userId);
        Task<PurchaseRequestModel> Purchase(PurchaseRequestModel purchaseRequestModel);
        Task<IEnumerable<PurchaseResponseModel>> GetPurchaseByUserId(int userId);
        Task<PurchaseRequestModel> UpdatePurchase(int purchaseId, PurchaseRequestModel purchaseRequestModel);
    }
}
