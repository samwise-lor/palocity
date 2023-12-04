# What is this?

A project seed for a C# dotnet API ("PaylocityBenefitsCalculator").  It is meant to get you started on the Paylocity BackEnd Coding Challenge by taking some initial setup decisions away.

The goal is to respect your time, avoid live coding, and get a sense for how you work.

# Coding Challenge

**Show us how you work.**

Each of our Paylocity product teams operates like a small startup, empowered to deliver business value in
whatever way they see fit. Because our teams are close knit and fast moving it is imperative that you are able
to work collaboratively with your fellow developers. 

This coding challenge is designed to allow you to demonstrate your abilities and discuss your approach to
design and implementation with your potential colleagues. You are free to use whatever technologies you
prefer but please be prepared to discuss the choices you’ve made. We encourage you to focus on creating a
logical and functional solution rather than one that is completely polished and ready for production.

The challenge can be used as a canvas to capture your strengths in addition to reflecting your overall coding
standards and approach. There’s no right or wrong answer.  It’s more about how you think through the
problem. We’re looking to see your skills in all three tiers so the solution can be used as a conversation piece
to show our teams your abilities across the board.

Requirements will be given separately.

# Assumptions

* Deductions are removed from the salary
* Configs are hardcoded as constants and will be moved to appsettings.json
* Split the services logic into EmployeeService and DependentService for separation of concern as well as extensibility in case of new Business logic

# Pattern
* Mediator is a behavioral design pattern that reduces coupling between objects, making them communicate indirectly and remove dependency using mediator object. 
* Command Query Responsibility Segregation (CQRS) patterns allows for splitting the responsibility of commands and queries into different models


# Working on
* Mapping of returns based on controller contracts
* Unit tests