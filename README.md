# Shopify to Acumatica Integration

This repository contains an Acumatica Customization Project that allows Acumatica to read the Properties array(Line Items) on a Sales Order. By default it only reads one value.

## Overview

The primary goal of this project is to facilitate seamless line item data transfer between Shopify and Acumatica, ensuring that sales orders created in Shopify are accurately reflected in Acumatica. 


## Components

### `SPSalesOrderProcessor_Extension`

The main component of this project is the `SPSalesOrderProcessor_Extension` class, which extends the base `SPSalesOrderProcessor` class from the Acumatica Commerce interface. This class overrides the `MapBucketImport` method to include additional logic for processing Shopify orders.

#### Key Methods

- **`MapBucketImport`**: This method handles the synchronization of Shopify orders to Acumatica. It processes each line item, maps Shopify properties to Acumatica fields, and updates the Acumatica sales order.

