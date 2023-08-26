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
    public class GetGroupWithProductsByCustomerIdAndGroupIdUC : IGetGroupWithProductsByCustomerIdAndGroupIdUC
    {
        private readonly IGroupRepository _groupRepository;

        public GetGroupWithProductsByCustomerIdAndGroupIdUC(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task<Group> ExecuteAsync(int customerId, int groupId)
        {
            return await _groupRepository.GetGroupWithProductsByCustomerIdAndGroupId(customerId, groupId);
        }
    }
}
