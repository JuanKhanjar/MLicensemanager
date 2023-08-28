using MLicensemanager.BusinessCore.Entities;
using System.Globalization;

namespace MLicensemanager.BlazorUI.HttpServicesServices
{
    public interface IGroupService
    {
        Task<Group> UpdateGroupNameAsync(Group UpdatedgroupName);
    }
}
