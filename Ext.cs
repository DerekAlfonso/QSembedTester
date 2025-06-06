using Amazon.QuickSight.Model;
using System.Reflection;
using System.Text.RegularExpressions;

namespace QSembedTester
{
    public interface IVisualIdProvider
    {
        string VisualId { get; }
        string Title { get; }
    }
    public static class Ext
    {
        //static Regex rxRemoveFormatting = new Regex("<.*?>(.*?)<\\/.*?>.*", RegexOptions.Compiled | RegexOptions.Singleline);
        static Regex rxRemoveFormatting = new Regex(@"<[^>]+>", RegexOptions.Compiled | RegexOptions.Singleline);
        public static object? GetConcreteVisual(this Visual visual)
        {
            if (visual == null) return null;

            var visualProps = visual.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name.EndsWith("Visual") && p.PropertyType != typeof(Visual));

            foreach (var prop in visualProps)
            {
                var value = prop.GetValue(visual);
                if (value != null)
                    return value;
            }
            return null;
        }

        public static string GetVisualTypeName(this Visual visual)
        {
            if (visual == null) return "Unknown Visual Type";
            var concreteVisual = visual.GetConcreteVisual();
            if (concreteVisual != null)
            {
                return concreteVisual.GetType().Name;
            }
            return visual.GetType().Name;
        }

        public static string? VisualId(this Visual visual)
        {
            if (visual == null) return "Unknown Visual ID";
            var concreteVisual = visual.GetConcreteVisual();
            if (concreteVisual != null)
            {
                // Try direct interface
                if (concreteVisual is IVisualIdProvider idProvider)
                {
                    return idProvider.VisualId;
                }
                // Fallback: try to get VisualId property via reflection
                var prop = concreteVisual.GetType().GetProperty("VisualId", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.PropertyType == typeof(string))
                {
                    var value = prop.GetValue(concreteVisual) as string;
                    if (!string.IsNullOrEmpty(value))
                        return value;
                }
            }
            return null;
        }
        public static string? GetVisualTitle(this Visual visual)
        {
            if (visual == null) return "Unknown Visual Title";
            var concreteVisual = visual.GetConcreteVisual();
            if (concreteVisual != null)
            {
                // Try direct interface
                if (concreteVisual is IVisualIdProvider idProvider)
                {
                    return idProvider.Title;
                }
                // Fallback: try to get Title property via reflection
                var prop = concreteVisual.GetType().GetProperty("Title", BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.PropertyType == typeof(VisualTitleLabelOptions))
                {
                    var value = prop.GetValue(concreteVisual) as VisualTitleLabelOptions;
                    if(value != null)
                    {
                        if(value.FormatText == null)
                            return null;
                        if (value.FormatText.PlainText != null)
                            return value.FormatText.PlainText;
                        else
                        {
                            if(rxRemoveFormatting.IsMatch(value.FormatText.RichText))
                                return rxRemoveFormatting.Replace(value.FormatText.RichText, "").Trim();
                            else
                                return value.FormatText.RichText.Trim();
                        }
                    }
                        
                }
            }
            return null;
        }
    }
}
