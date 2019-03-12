using Autofac;
using restlessmedia.Module.Category.Data;

namespace restlessmedia.Module.Category
{
  internal class Module : IModule
  {
    public void RegisterComponents(ContainerBuilder containerBuilder)
    {
      containerBuilder.RegisterType<CategoryDataProvider>().As<ICategoryDataProvider>().SingleInstance();
      containerBuilder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
    }
  }
}