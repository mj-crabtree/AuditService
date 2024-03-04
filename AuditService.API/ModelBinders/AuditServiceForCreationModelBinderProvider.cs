using AuditService.Entities.Models.IncomingDtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuditService.ModelBinders;

public class AuditServiceForCreationModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(AuditEventCreationDto))
        {
            return new AuditServiceForCreationModelBinder();
        }

        return null;
    }
}