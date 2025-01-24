# Checkout Kata

This repository contains a class library solution to the Checkout Kata problem, implemented in ASP.NET Core 8.0 using C#. The solution is developed in a test-driven manner, adhering to clean code principles.

## Problem Description
In a supermarket, items are identified by Stock Keeping Units (SKUs), represented by individual letters (e.g., A, B, C). Each item has a unit price, and some items have special pricing offers:

| SKU | Unit Price | Special Price |
|-----|------------|---------------|
| A   | 50         | 3 for 130     |
| B   | 30         | 2 for 45      |
| C   | 20         |               |
| D   | 15         |               |

The checkout system should:
1. Accept items in any order.
2. Apply special prices where applicable.
3. Calculate the total price for scanned items.
4. Allow dynamic pricing rules to be passed in.