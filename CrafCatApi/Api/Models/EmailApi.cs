using System.ComponentModel.DataAnnotations;

namespace CrafCatApi.Api.Models
{
    public class EmailApi : IValidatableObject
    {
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string EmailContent { get; set; }

        public EmailApi(string receiverEmail, string subject, string emailContent)
        {
            ReceiverEmail = receiverEmail;
            Subject = subject;
            EmailContent = emailContent;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ReceiverEmail)) 
                yield return new ValidationResult("ReceiverEmail is required", [nameof(ReceiverEmail)]);
            
            if (string.IsNullOrWhiteSpace(Subject)) 
                yield return new ValidationResult("Subject is required", [nameof(Subject)]);

            if (string.IsNullOrWhiteSpace(EmailContent)) 
                yield return new ValidationResult("EmailContent is required", [nameof(EmailContent)]);
        }
    }
}
