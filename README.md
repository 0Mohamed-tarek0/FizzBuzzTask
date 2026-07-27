\# FizzBuzz Task



A C# implementation of the FizzBuzz Word Detector task.



\## Overview



This project processes an input string and replaces words according to the following rules:



\- Every 3rd word is replaced with \*\*Fizz\*\*

\- Every 5th word is replaced with \*\*Buzz\*\*

\- Every 15th word is replaced with \*\*FizzBuzz\*\*



The project also counts the number of:

\- Fizz replacements

\- Buzz replacements

\- FizzBuzz replacements



The solution includes a complete xUnit test project to verify the implementation.



\---



\## Project Structure



```

FizzBuzzTask

│

├── Models

│   └── FizzBuzzResult.cs

│

├── Services

│   ├── IFizzBuzzDetector.cs

│   └── FizzBuzzDetector.cs

│

├── Program.cs

│

└── FizzBuzzTask.csproj



FizzBuzzTask.Tests

│

└── FizzBuzzWordDetectorTests.cs

```



\---



\## Technologies



\- C#

\- .NET 10

\- xUnit



\---



\## Running the Project



Open the solution using Visual Studio and run the application.



\---



\## Running the Tests



Open \*\*Test Explorer\*\* and click \*\*Run All Tests\*\*.



All tests should pass successfully.



\---



\## Test Coverage



The test project covers:



\- Task example

\- Null input

\- Empty input

\- Less than three words

\- Fifteen-word replacement

\- Symbol-only tokens

\- Punctuation handling

\- Multiple whitespaces and new lines



\---



\## Author



Mohamed Tarek

