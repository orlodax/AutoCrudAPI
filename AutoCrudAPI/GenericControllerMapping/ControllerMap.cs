using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;

namespace AutoCrudAPI.GenericControllerMapping;

public class ControllerMap : IApplicationFeatureProvider<ControllerFeature>
{
    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        DirectoryInfo baseDirectory = new(AppContext.BaseDirectory);
        IEnumerable<FileInfo>? dlls = baseDirectory.GetFiles().Where(file => file.Extension == ".dll"
                                                                    && file.Name.Contains("Library"));
        foreach (FileInfo file in dlls)
        {
            Assembly assembly = Assembly.Load(new AssemblyName() { Name = Path.GetFileNameWithoutExtension(file.Name) });

            foreach (Type type in assembly.GetExportedTypes().Where(t => t.IsSubclassOf(typeof(SampleLibrary.BaseModel))))
                feature.Controllers.Add(typeof(Controllers.GenericController<>).MakeGenericType(type).GetTypeInfo());
        }
    }
}
