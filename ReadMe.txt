The below NuGet must be exist:
- AutoMapper.Extensions.Microsoft.DependecyInjection (8.1.0)
- Microsoft.EntityFramweworkCore.Sqlite (5.0.5)
- Microsoft.EntityFramweworkCore.Tools (5.0.15)
- Microsoft.OpenApi (1.1.4)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (3.1.1)
- Swashbuckle.AspNetCore (5.2.0)
- System.Data.SqlClient (4.8.1)

ORM used:
- Entity Framework core

Database
- Sqlite (DerivcoRouletteGame.db)

Roulette Game API
- Place a Bet using the PlaceBet api : The bet is place by selecting any number between 1 - 100
- Make a spin using the DoSpin api : DoSpin result will generate a number between 1 - 100; if the generated number is equals to 
the number selected when placing the bet a payment is made otherwise 0.
- The result of the spin create a payout that get saved in the payout table.

Others
- Swagger UI is used to test the APIs
- Other APIs are available for testing purposes
- Validations is done at a minimal level (can be improve with business rules)