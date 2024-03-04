using System.Text.Json;
using AuditService.Entities.Models.IncomingDtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuditService.ModelBinders;

public class AuditServiceForCreationModelBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var request = bindingContext.HttpContext.Request;
        var requestBody = request.Body;

        using (var reader = new StreamReader(requestBody))
        {
            var json = await reader.ReadToEndAsync();
            var jsonObject = JsonDocument.Parse(json);
            var eventType = jsonObject.RootElement.GetProperty("EventType").GetString() ?? string.Empty;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            AuditEventCreationDto eventToReturn;

            switch (eventType.ToLower())
            {
                case "filecreated":
                    eventToReturn = JsonSerializer.Deserialize<FileCreatedEventCreationDto>(json, options)!;
                    break;
                case "fileclassified":
                    eventToReturn = JsonSerializer.Deserialize<FileClassifiedEventCreationDto>(json, options)!;
                    break;
                default:
                    throw new JsonException($"Error when deserialising to derived event: {eventType} not recognised.");
            }

            bindingContext.Result = ModelBindingResult.Success(eventToReturn);
        }
    }
}