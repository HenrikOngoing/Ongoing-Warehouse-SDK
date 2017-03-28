using System.ServiceModel;
using System;
using System.Collections.Generic;
using OngoingWarehouse.Sdk.OngoingWarehouseAPI;

namespace OngoingWarehouse.Sdk
{
   internal class SoapService
   {
      private readonly ServiceSoapClient _soapClient;
      private readonly User _user;
      private readonly GoodsOwner _goodsOwner;

      public SoapService(ConnectionCredentials connectionCredentials)
      {
         if (connectionCredentials == null)
         {
            throw new ArgumentException("Credentials needed", nameof(connectionCredentials));
         }
         _soapClient = CreateClient(connectionCredentials.SystemName);
         _user = connectionCredentials.User;
         _goodsOwner = connectionCredentials.GoodsOwner;
      }

      public void UpdateOrCreateOrder(CustomerOrder order)
      {
         var response = _soapClient.ProcessOrder(_goodsOwner.Name, _user.Name, _user.Password, order);
         if (!response.Success)
         {
            throw CreateSdkException(response);
         }
      }

      public void UpdateOrCreateArticle(ArticleDefinition articleDefinition)
      {
         var response = _soapClient.ProcessArticle(_goodsOwner.Name, _user.Name, _user.Password, articleDefinition);
         if (!response.Success)
         {
            throw CreateSdkException(response);
         }
      }

      public IEnumerable<InventoryLine> GetStock(DateTime fromDate)
      {
         var getInventoryQuery = new GetInventoryQuery()
         {
            StockInfoChangedFromSpecified = true,
            StockInfoChangedFrom = fromDate
         };
         var response = _soapClient.GetInventoryByQuery(_goodsOwner.Name, _user.Name, _user.Password, getInventoryQuery);
         return response.InventoryLines;
      }

      public IEnumerable<Order> GetOrders(DateTime fromDate, int? minimumOrderStatus = null, int? maximumOrderStatus = null)
      {
         var query = new OrderFilters
         {
            OrderStatusFrom = minimumOrderStatus,
            OrderStatusTo = maximumOrderStatus,
            LastUpdatedFrom = fromDate
         };
         var response = _soapClient.GetOrdersByQuery(_goodsOwner.Name, _user.Name, _user.Password, query);
         return response.Orders;
      }

      private static ServiceSoapClient CreateClient(string systemName)
      {
         var apiUrl = $"https://api.ongoingsystems.se/{systemName}/service.asmx";
         BasicHttpBinding binding = CreateBinding();
         var soapClient = new ServiceSoapClient(binding, new EndpointAddress(apiUrl));
         return soapClient;
      }

      private static BasicHttpBinding CreateBinding()
      {
         var binding = new BasicHttpBinding
         {
            MaxReceivedMessageSize = int.MaxValue,
            MaxBufferSize = int.MaxValue,
            SendTimeout = new TimeSpan(0, 5, 0),
         };
         binding.ReaderQuotas.MaxArrayLength = 50000000;
         binding.ReaderQuotas.MaxStringContentLength = 50000000;
         binding.ReaderQuotas.MaxNameTableCharCount = 50000000;
         return binding;
      }

      private static SdkException CreateSdkException(FileResultClass response) =>
         new SdkException($"Remote host responded with and error. {nameof(response.Message)}: {response.Message}. {nameof(response.ErrorMessage)}: {response.ErrorMessage}.");
   }
}
