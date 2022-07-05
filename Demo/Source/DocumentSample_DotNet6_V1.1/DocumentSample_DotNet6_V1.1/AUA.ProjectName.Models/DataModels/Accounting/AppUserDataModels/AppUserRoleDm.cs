using AUA.Mapping.Mapping.Contract;
using AutoMapper;

namespace AUA.ProjectName.Models.DataModels.Accounting.AppUserDataModels
{

    public class AppUserRoleNamesDm : IHaveCustomMappings
    {
        public long Id { get; set; }

        public ICollection<string> UserRolesNames { get; set; }


        public void ConfigureMapping(Profile configuration)
        {
           
        }

    }
}
