using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.GroupsUC.GroupUCIntefaces
{
    public interface IGetGroupsWithProductsByCustomerIdUC
    {
        Task<List<Group>> ExecuteAsync(int customerId);
    }
}