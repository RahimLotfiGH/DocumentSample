using AUA.Mapping.Mapping.Contract;
using AUA.ProjectName.Common.Enums;
using AutoMapper;

namespace AUA.ProjectName.Models.GeneralModels.AccessTokenModels
{
    public class UserRoleAccessVm : IHaveCustomMappings
    {
        public IEnumerable<int> UserRoleIds { get; set; }

        public IEnumerable<EUserAccess> UserAccessIds => AccessIds.Distinct();

        public IEnumerable<EUserAccess> AccessIds { get; set; }

        public void ConfigureMapping(Profile configuration)
        {
            

        }

    }
}
