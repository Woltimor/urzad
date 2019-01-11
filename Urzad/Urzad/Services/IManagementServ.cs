using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Responses;

namespace Urzad.Services
{
    public interface IManagementServ
    {
        Task<int> Insert(ManagementResponse managementResponse);
        Task<int> Insert(KategoriaOferty kat);
        Task<int> Insert(Responses.Oferty oferty);
        Task<int> Insert(ProposalResponse proposal);
        Task<int> Insert(AchievementResponse achievement);
        Task<int> Insert(ExpextedAchievementsResponse expextedAchievementsResponse);
        Task<int> Insert(Responses.PosiadaneKwalifikacjes kwalifikacje);
        Task<int> UpdateType(int id, ManagementResponse types);
        Task<int> UpdateRoles(int id, RolesResponse roles);
        Task<int> UpdateCategory(int id, CategoryResponse categories);
        Task<int> UpdateAccess(int id, AccessResponse access);
        Task<int> UpdateOffer(int id, OfferResponse offers);
        Task<List<ManagementResponse>> GetTypeAsync();
        Task<List<CategoryResponse>> GetCategoryAsync();
        Task<List<OfferResponse>> GetOfferAsync();
        Task<List<TypeCategoryResponse>> GetTypeCategoryAsync();
        Task<List<CategoryOfferResponse>> GetCategoryOfferAsync();
        Task<List<QualificationResponse>> GetQualificationsAsync();
    }
}
