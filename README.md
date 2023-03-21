# YAFC

Yet Another Financial Calculator | A Financial Calculator Application with TVM, Amortization Scheduling, and more!

---
<h2>Purpose For Project</h2>
I've wanted to take on a project in a lower-level language than Python and JavaScript (in which all of my past projects have been in), and I've approached C# as I have some prior interaction with it from some 6 months of producing <a href="https://twitter.com/NoHolidayMMS" target="_blank">animated short-films</a> in Unity. I was doing some schoolwork (graduating with my Bachelor's in Finance this May 2023) and needed my financial calculator. I searched online and found <a href="https://www.calculator.net/finance-calculator.html" target="_blank">this one</a>, and <a href="https://www.bankrate.com/calculators/" target="_blank">this page</a>, and also <a href="https://www.gigacalculator.com/calculators/time-value-of-money-calculator.php" target="_blank">this one</a>... But none even come close to my trusty BAII Plus by Texas Instruments. The Windows Calculator, on the other hand, has great Scientific and Graphing Calculator Layouts, but no Time Value of Money for bond pricing and cash flow discounting or Amortization Scheduling for loans, etc. Well, why don't I take this opportunity to get more accustomed to C# and make a Windows Financial Calculator Application?

---
<h2>How To Use</h2>
<p><strong>General Concept:</strong> As a general purpose calculator, PEMDAS is followed. The user can build out mathematical expressions and return an output. After which, hitting another operator command will begin building a new expression off of the current output. To continue building on the previous expression, tap Clear once to Clear the current output. Tap Clear twice to Clear All. Almost all buttons are mapped to Keyboard Keys as intuition will follow. 'Delete' is mapped to Clear and 'End' or 'Esc' will both close the application.</p>

<p>The Time Value of Money and Cash Flow Sections of the calculator act independently of the general purpose components. The sections follow standard practice will all physical-use financial calculators. Further explanation for each component can be found below.</p>

---