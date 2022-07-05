using Microsoft.AspNetCore.Http;

namespace AUA.ProjectName.Models.DataModels.Documents
{
    public class UploadValidationResult
    {

        public IFormFile File { get; set; }

        public int DocumentTypeId { get; set; }


    }
}
