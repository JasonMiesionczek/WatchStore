Watch Store
---

### Setup
1. CLI: From the repo root, cd into WatchStore and run `dotnet run`
Or
1. Open solution in Visual Studio and run default project.
 
### Approach
I first started with the basic data model for the products, discounts and cart.
I then built the simple repository to retrieve the products. From there I started 
building the service layer and wiring it up to the controller function.

Once I had the controller up and running I began testing the basic functionality. 
I went through a few iterations of applying the discounts (initially overthinking things a bit)
and further simplfying things down to find the most basic approach that satisfied all the requirements.

With the process in place, I wrote a few simple unit tests to ensure any future changes would continue to work as expected.

