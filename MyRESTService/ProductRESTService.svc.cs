using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RabbitMQ.Client;
using GemStone.GemFire.Cache.Generic;

namespace MyRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductRESTService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductRESTService.svc or ProductRESTService.svc.cs at the Solution Explorer and start debugging.
    public class ProductRESTService : IProductRESTService
    {
        public List<Product> GetProductList()
        {
            this.getChannel();
            List<Product> products = null;
            IRegion<int, string> productRegion = this.getProductRegion();

            if (productRegion.Count == 0)
            {
                products = Products.Instance.ProductList;
                for (int p = 0; p < products.Count; p++)
                {
                    productRegion.Add(products[p].ProductId, products[p].Name);
                }
            } else
            {
                products = (List<Product>)productRegion.Values;
            }

            return products;
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

        public Cache getCache()
        {
            CacheFactory cacheFactory = CacheFactory.CreateCacheFactory();
            cacheFactory.AddLocator("192.168.0.100", 10334);
            Cache cache = cacheFactory.SetSubscriptionEnabled(true).Create();

            return cache;
        }

        public IRegion<int,string> getProductRegion()
        {
            Cache cache = this.getCache();
            RegionFactory regionFactory = cache.CreateRegionFactory(RegionShortcut.CACHING_PROXY);
            IRegion<int, string> r = regionFactory.Create<int, string>("products");
            return r;
        }
    }
}
