using System.Text.Json;

namespace Entities.LogModel
{
    public class LogDetails
    {
        // defined as Object because of we'll use context
        public Object? ModelName { get; set; }
        public Object? Controller { get; set; }
        public Object? Action { get; set; }
        public Object? Id { get; set; }
        public Object? Created { get; set; }

        public LogDetails()
        {
            Created = DateTime.UtcNow;
        }

        public override string ToString() =>
            JsonSerializer.Serialize(this);

    }
}