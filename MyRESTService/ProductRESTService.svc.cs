using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RabbitMQ.Client;

namespace MyRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductRESTService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductRESTService.svc or ProductRESTService.svc.cs at the Solution Explorer and start debugging.
    public class ProductRESTService : IProductRESTService
    {
        public List<Product> GetProductList()
        {
            this.getChannel();
            return Products.Instance.ProductList;
        }

        public void SendMessage(String msg)
        {
            var channel = this.getChannel();
        }

        public RabbitMQ.Client.IModel getChannel()
        {
            var rmqConnect = PCFHelper.Bind("p-rabbitmq", "java-dotnet-messaging");
            System.Diagnostics.Debug.WriteLine("Using " + rmqConnect);
            var factory = new ConnectionFactory();
            factory.Uri = rmqConnect;
            var connection = factory.CreateConnection();
            return connection.CreateModel();
        }
    }
}
