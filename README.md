# Work In Progress Kata
This is a Coding Kata exercise to demonstrate Work in Progress options: push vs pull. It's based off of a manual exercise I experienced recently in which an assembly line of 4 people are presented with a stack of cards to process by putting sticker dots on the card and then passing along to the next person in line. Each person is assigned an id (e.g., a Greek alphabet letter) and a sticker colour; each card has one or more spots for each id. For example, a card might have 9 spots consisting of 2 Alpha, 1 Beta, 2 Gamma, and 4 Delta. The cards are deliberately configured to create a bottleneck for one of the participants (e.g., for Delta) by giving that participant more dots to cover than any other participant. The total processing time and the cycle time for the last card are measured.

## Push
* An initial stack of cards is presented, and a timer is started.
* First person in line pulls a card from the initial stack.
* First person covers their dots on the card and then passes it to the next in line.
* Each person downstream covers their dots on the cards passed to them as quickly as possible, and then passes to the next in line.
* When all cards have been processed by everyone in line, the timer is stopped.

## Pull
* An initial stack of cards is presented, and a timer is started.
* First person in line pulls a card from the initial stack.
* First person covers their dots on the card and then raises their hand to indicate their card is ready. They cannot start a new card until their current card has been pulled by the next in line.
* Each person downstream waits until the previous person has raised their hand, then pulls the card, covers their dots, and raises their hand.
* When all cards have been processed by everyone in line, the timer is stopped.

## Other Notes
* Executes the code using a .NET Core Console application
* Unit tests all methods using these testing and utility libraries:
  * **Xbehave** and **xUnit**
  * **Moq**, **Moq.AutoMock**, and **Moq.Sequences**
  * **Shouldly**
  * **Bogus**
* Follows the [Ardalis Clean Architecture pattern](https://github.com/ardalis/CleanArchitecture) and [avoids referencing Infrastructure](https://ardalis.com/avoid-referencing-infrastructure-in-visual-studio-solutions)
  * [How to have a Project Reference without referencing the actual binary](https://blogs.msdn.microsoft.com/kirillosenkov/2015/04/04/how-to-have-a-project-reference-without-referencing-the-actual-binary/)
  * [Loading unreferenced assemblies at runtime for IoC with ASP.NET Core](https://joergweissbecker.wordpress.com/2017/12/06/loading-unreferenced-assemblies-at-runtime-for-ioc-with-asp-net-core/)
