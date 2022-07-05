using AUA.ProjectName.ValidationServices.Accounting.AppUserValidations.Services;
using AUA.ProjectName.ValidationServices.Accounting.Documents.Contracts;

namespace AUA.ProjectName.WebApi.RegistrationServices
{
    public static class ValidationService
    {
        public static void RegistrationValidationService(this IServiceCollection services)
        {
            services.AccountingValidationService();
            services.DocumentValidationService();
        }

        private static void AccountingValidationService(this IServiceCollection services)
        {
            
        }

        private static void DocumentValidationService(this IServiceCollection services)
        {
            services.AddScoped<IUploadValidationService, UploadValidationService>();
        }

    }

}
