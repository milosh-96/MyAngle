using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;

namespace MyAngle.Mvc.Conventions
{
    public class FeatureConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var featureName = GetFeatureName(controller.ControllerType);
            controller.Properties.Add("feature", featureName);
        }

        private string GetFeatureName(TypeInfo controllerType)
        {
            if (controllerType != null && controllerType.FullName != null)
            {
                string[] tokens = controllerType.FullName.Split('.');
                if (!tokens.Any(t => t == "Features")) return "";
                string featureName = "";
                if(tokens != null)
                {
                  string? feature =  tokens
                    .SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
                    .Skip(1)
                    .Take(1)
                    .FirstOrDefault();

                    if(feature != null)
                    {
                        featureName = feature.ToString();
                    }
                }

                return featureName;
            }
            return "Home";
        }
    }
}
