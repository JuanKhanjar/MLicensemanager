using MLicensemanager.BusinessCore.Entities;

namespace MLicensemanager.UseCases.GroupsUC.GroupUCIntefaces
{
    public interface IGetGroupWithProductsByCustomerIdAndGroupIdUC
    {
        Task<Group> ExecuteAsync(int customerId, int groupId);
    }
}