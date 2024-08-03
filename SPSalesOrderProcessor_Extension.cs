using PX.Api.ContractBased.Models;
using PX.Commerce.Core;
using PX.Commerce.Core.API;
using PX.Commerce.Objects;
using PX.Commerce.Shopify.API.REST;
using PX.Common;
using PX.Data;
using PX.Objects.Common;
using PX.Objects.CS;
using PX.Objects.GL;
using PX.Objects.IN;
using PX.Objects.SO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using PX.Commerce.Shopify.API.GraphQL.DataProviders;
using System.Threading.Tasks;
using PX.Commerce.Shopify.API.GraphQL;
using PX.Objects;
using PX.Commerce.Shopify;


namespace PX.Commerce.Shopify
{
    public class SPSalesOrderProcessor_Extension : PXGraphExtension<PX.Commerce.Shopify.SPSalesOrderProcessor>
    {
        public delegate Task MapBucketImportDelegate(SPSalesOrderBucket bucket, IMappedEntity existing, CancellationToken cancellationToken);

        [PXOverride]
        public async Task MapBucketImport(SPSalesOrderBucket bucket, IMappedEntity existing, CancellationToken cancellationToken, MapBucketImportDelegate baseMethod)
        {
            PXTrace.WriteInformation("MapBucketImport method started");

            await baseMethod(bucket, existing, cancellationToken);

            // Get Shopify order data model
            var shopifyOrder = bucket.Order.Extern;
            PXTrace.WriteInformation($"Shopify Order ID: {shopifyOrder.Id}");

            // Get ERP order data model
            var acumaticaOrder = bucket.Order.Local;
            PXTrace.WriteInformation($"Acumatica Order ID: {acumaticaOrder.OrderNbr?.Value}");

            // Loop through each line item in the Shopify order
            foreach (var shopifyLineItem in shopifyOrder.LineItems)
            {
                PXTrace.WriteInformation($"Processing Shopify Line Item ID: {shopifyLineItem.Id}");

                // Find the corresponding line item in Acumatica Sales Order
                var acumaticaLineItem = acumaticaOrder
                    .Details
                    .FirstOrDefault(line => string.Equals(line.ExternalRef?.Value, shopifyLineItem.Id.ToString()));

                if (acumaticaLineItem != null)
                {
                    PXTrace.WriteInformation("Matching Acumatica Line Item Found");
                    // Loop through properties of the Shopify line item
                    foreach (var property in shopifyLineItem.Properties)
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.Value;
                        PXTrace.WriteInformation($"Property: {propertyName} = {propertyValue}");

                        // Map the Shopify property to Acumatica line item note
                        acumaticaLineItem.Note += propertyValue;
                    }
                }
                else
                {
                    PXTrace.WriteInformation("No Matching Acumatica Line Item Found");
                    acumaticaOrder.Note = "No Line Item Object found";
                }
            }

            PXTrace.WriteInformation("Exiting MapBucketImport method");
        }
    }
}
