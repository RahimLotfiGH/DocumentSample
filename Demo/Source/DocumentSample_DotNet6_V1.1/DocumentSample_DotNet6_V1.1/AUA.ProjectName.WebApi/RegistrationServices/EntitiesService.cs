using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.Services.EntitiesService.Documents.Contracts;
using AUA.ProjectName.Services.EntitiesService.Documents.Services;

namespace AUA.ProjectName.WebApi.RegistrationServices
{
    public static class EntitiesService
    {

        public static void RegistrationEntitiesService(this IServiceCollection services)
        {
            services.RegistrationBaseService();
         
            services.RegistrationBaseInformationService();

            services.RegistrationDocumentService();
        }

        private static void RegistrationBaseService(this IServiceCollection services)
        {
            services.AddDbContext<IUnitOfWork, ApplicationEfContext>();
        }
    
        private static void RegistrationBaseInformationService(this IServiceCollection services)
        {
           
        }

        private static void RegistrationDocumentService(this IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();

        }




    }
}
