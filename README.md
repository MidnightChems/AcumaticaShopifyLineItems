# Shopify to Acumatica Integration

This repository contains an integration solution for syncing sales orders from Shopify to Acumatica ERP. The integration processes Shopify orders, mapping relevant data to Acumatica sales orders, and handles special considerations such as line item properties.

## Overview

The primary goal of this project is to facilitate seamless data transfer between Shopify and Acumatica, ensuring that sales orders created in Shopify are accurately reflected in Acumatica. The solution focuses on mapping Shopify order details, including line items and custom properties, to the corresponding fields in Acumatica.

## Key Features

- **Data Synchronization:** Synchronizes Shopify sales orders with Acumatica sales orders.
- **Line Item Mapping:** Maps Shopify line items to Acumatica sales orders, including handling custom properties.
- **Error Handling:** Provides basic error handling to ensure data integrity during the synchronization process.

## Components

### `SPSalesOrderProcessor_Extension`

The main component of this project is the `SPSalesOrderProcessor_Extension` class, which extends the base `SPSalesOrderProcessor` class from the Acumatica Commerce interface. This class overrides the `MapBucketImport` method to include additional logic for processing Shopify orders.

#### Key Methods

- **`MapBucketImport`**: This method handles the synchronization of Shopify orders to Acumatica. It processes each line item, maps Shopify properties to Acumatica fields, and updates the Acumatica sales order.

### Data Models

- **`ShopifyOrderLineItem`**: Represents a line item from a Shopify order.
- **`ShopifyProperty`**: Represents a property associated with a Shopify line item.

## Installation

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/shopify-acumatica-integration.git
