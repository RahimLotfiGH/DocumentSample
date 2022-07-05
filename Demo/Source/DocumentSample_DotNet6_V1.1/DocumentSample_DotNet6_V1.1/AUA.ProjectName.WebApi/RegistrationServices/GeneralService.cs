using AUA.ProjectName.Services.GeneralService.UploadFile.Contents;
using AUA.ProjectName.Services.GeneralService.UploadFile.Services;

namespace AUA.ProjectName.WebApi.RegistrationServices
{
    public static class GeneralService
    {
        public static void RegistrationGeneralServices(this IServiceCollection services)
        {

            services.RegistrationAccessServices();

            services.RegistrationDocumentServices();
        }

        private static void RegistrationAccessServices(this IServiceCollection services)
        {
          
            
        }

        private static void RegistrationDocumentServices(this IServiceCollection services)
        {
            services.AddScoped<IUploadFileService, UploadFileService>();
        }

        }
}
