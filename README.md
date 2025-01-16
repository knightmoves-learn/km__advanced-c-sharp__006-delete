# 006 Delete

## Lecture

[![006 Delete (Part 1)](https://img.youtube.com/vi/TjI_fPge9fo/0.jpg)](https://www.youtube.com/watch?v=TjI_fPge9fo)
[![006 Delete (Part 2)](https://img.youtube.com/vi/TJuVWZXdKtY/0.jpg)](https://www.youtube.com/watch?v=TJuVWZXdKtY)

## Instructions

In this assignment you will continue working on our HomeEnergyApi's Controller. Similarly to the lecture, you will add a DELETE request.

In `HomeEnergyApi/Controllers/HomesController.cs`...

- Create a new HTTP DELETE method
  - This method should take one route parameter, off of the initial route `/Homes`.
  - This method should delete a specific `Home` from the list `homesList`.
  - The Home being deleted, should be the `Home` in `homesList` whose `id` property is the same as the route parameter being passed in to your new PUT method.
    - Hint: Unlike the code examples in the lecture, you cannot assume homesList is sorted by `id`. The `Home` with an `id` of 2, may not necessarily be the `Home` at `homesList[2]`
- Verify HomeEnergyApi can...
  - Get homes existing in the static list `homesList` from its GET method.
  - Get a specific home existing in the static list `homesList` from its GET `FindById()` method.
  - Add homes to the static list `homesList` from its POST method.
  - Update homes in the static list `homesList` from its PUT method.
  - Delete homes in the static list `homesList` from its DELETE method.
  - Have any and all changes made to homes in `homes` reflected as long as server is running. 
- Any existing methods or properties on `HomesController.cs` should NOT be changed.
- All methods should use the base route `/Homes`.

Additional Information:

- You'll notice the GET and PUT routes in `HomeEnergyApi/Controllers/HomesControllers.cs` have been modified from how you were instructed to create them in previous assignments. They now support finding/updating homes based on `id` rather than `ownerLastName`.
- You should ONLY make code changes in `HomeEnergyApi/Controllers/HomesController.cs` to complete this assignment.

## Building toward CSTA Standards:

- Create artifacts by using procedures within a program, combinations of data and procedures, or independent but interrelated programs (3A-AP-18) https://www.csteachers.org/page/standards
- Create computational models that represent the relationships among different elements of data collected from a phenomenon or process (3A-DA-12) https://www.csteachers.org/page/standards
- Explain how abstractions hide the underlying implementation details of computing systems embedded in everyday objects (3A-CS-01) https://www.csteachers.org/page/standards
- Demonstrate code reuse by creating programming solutions using libraries and APIs (3B-AP-16) https://www.csteachers.org/page/standards

## Resources

- https://en.wikipedia.org/wiki/REST
- https://en.wikipedia.org/wiki/HTTP
- https://en.wikipedia.org/wiki/HTTP#Request_methods

Copyright &copy; 2025 Knight Moves. All Rights Reserved.
