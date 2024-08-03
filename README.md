# Shopify Connector Enhancement for Acumatica

## Overview

This project extends the built-in Retail Shopify Connector for Acumatica to handle multiple line items per Shopify order. The default connector only processes the first item in the line item array. This enhancement ensures that all line items are properly mapped and imported into Acumatica.

## Key Changes

- **Extended Functionality**: Enhanced the `SPSalesOrderProcessor` to process multiple line items from Shopify orders.
- **Improved Data Mapping**: Overridden the `MapBucketImport` method to iterate through each line item and import all items into Acumatica.
- **Enhanced Logging**: Added logging with `PXTrace` to monitor the flow of data and identify any issues during the import process.

## How It Works

The updated implementation processes each line item from a Shopify order by:
1. **Retrieving Shopify Order Data**: Extracts the order details from Shopify, including all line items.
2. **Mapping to Acumatica**: Finds the corresponding line item in the Acumatica Sales Order.
3. **Updating Notes**: Adds relevant Shopify property values to the Acumatica line item notes.
4. **Logging Information**: Tracks the processing steps and any discrepancies using `PXTrace`.

## Usage

This enhancement is designed for integration with the Acumatica ERP system. It ensures that multiple line items from Shopify orders are handled correctly. Integrate this extension into your Acumatica environment and perform thorough testing before deploying it to production.

## Contribution

If you have suggestions or improvements, please feel free to contribute to this repository or open an issue.


