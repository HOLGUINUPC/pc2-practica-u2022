using Microsoft.AspNetCore.Mvc.ApplicationModels;
using pc2_practica_u2022.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

namespace pc2_practica_u2022.Shared.Infrastructure.Interfaces.ASP.Configuration;

public class KebabCaseRouteNamingConvention: IControllerModelConvention
{
    /// <summary>
    ///     This method applies the kebab-case naming convention to the controller.
    /// </summary>
    /// <param name="controller">The <see cref="ControllerModel" /></param>
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
    }

    /// <summary>
    ///     This method replaces the default controller template with a kebab-case template.
    /// </summary>
    /// <param name="selector">The <see cref="SelectorModel" /></param>
    /// <param name="name">string containing the name</param>
    /// <returns></returns>
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            }
            : null;
    }
}