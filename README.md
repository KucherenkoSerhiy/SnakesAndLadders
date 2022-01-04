# Snakes and Ladders

Note: check out the **diagrams** folder to view the class diagram.

## Structural and conceptual decisions

- Used the **Clean Architecture principles** to structure the code so it stays independent from framework;
- Added **Unit Tests** and **Integration Tests**. Friendly advice: if you try running them and integration tests do not appear, try unloading unit test projects and then run all tests of the solution again;
- The **Domain** project represents business rules (the idea comes from **Domain-Driven Design (DDD)**), while **Infrastructure** hides untestable framework-bound code. Removed Application and API layers as this makes little sense being a web service (though it is easy to add).
- The game is actually playable between 1 and 4 persons;

## Scope decisions
**I Noted** that the requirements did not specify such features as number of players, or presence of snakes and ladders on the board.
**I would** consult the stakeholders if these features should be done in current scope, and until receiving a positive response, not implement them.
**But**, for this test I could not arrange a short talk due to the New Year's holidays. So, I assumed that these features should be, as they look important :)


## NuGet packages used

**Microsoft.Extensions.DependencyInjection** to compose the code
**Microsoft.Extensions.Logging** for logging via console purposes.
**CsConsoleFormat** for good-looking table view

-- test-related --
**SpecFlow** for integration tests;
**Moq**: for mocking dependencies in tests
**FluentAssertions**: for asserting objects and lists in tests
