using MLicensemanager.BusinessCore.Entities;
using MLicensemanager.UseCases.GroupsUC.GroupUCIntefaces;
using MLicensemanager.UseCases.PluginsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLicensemanager.UseCases.GroupsUC
{
    public class GetGroupsWithProductsByCustomerIdUC : IGetGroupsWithProductsByCustomerIdUC
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupsWithProductsByCustomerIdUC(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<List<Group>> ExecuteAsync(int customerId)
        {
            return await _groupRepository.GetGroupsWithProductsByCustomerId(customerId);
        }
    }
}
