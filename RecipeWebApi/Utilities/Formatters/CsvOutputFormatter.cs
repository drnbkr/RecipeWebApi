
using System.Text;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace RecipeWebApi.Utilities.Formatters
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(RecipeDto).IsAssignableFrom(type) || typeof(IEnumerable<RecipeDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        private static void FormatCsv(StringBuilder buffer, RecipeDto recipe)
        {
            buffer.AppendLine($"{recipe.Id}, {recipe.Title}, {recipe.Calorie}");
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<RecipeDto>)
            {
                foreach (var recipe in (IEnumerable<RecipeDto>)context.Object)
                {
                    FormatCsv(buffer, recipe);
                }
            }
            else
            {
                FormatCsv(buffer, (RecipeDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }
    }
}
