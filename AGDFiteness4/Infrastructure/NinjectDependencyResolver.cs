using AGDFiteness4.Abstract;
using AGDFiteness4.Concrete;
using AGDFiteness4.Models;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace AGDFiteness4.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            ////--------------------------Mock Repository---------------------

            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product> {
            //    new Product { ProductName = "Football", ProductPrice = 25, CategoryID = 101},
            //    new Product { ProductName = "Surf board", ProductPrice = 179, CategoryID = 102 },
            //    new Product { ProductName = "Running Shoes", ProductPrice = 95, CategoryID = 103}
            //});

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            ////--------------------------EndEventHandler Mock Repository---------------------------------

            kernel.Bind<IProductRepository>().To<SpareProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}