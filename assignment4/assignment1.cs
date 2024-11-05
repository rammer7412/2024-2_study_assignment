/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System;

class Calculator
{
    // Calculate 메서드 구현
    public double Calculate(double num1, string op, double num2)
    {
        double result = 0;

        switch (op)
        {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "*":
                result = num1 * num2;
                break;
            case "/":
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed");
                }
                result = num1 / num2;
                break;
            default:
                throw new ArgumentException("Invalid operator");
        }

        return result;
    }

    static void Main()
    {
        Calculator calculator = new Calculator();

        string input = Console.ReadLine();
        string[] parts = input.Split(' ');

        double num1 = double.Parse(parts[0]);
        string op = parts[1];
        double num2 = double.Parse(parts[2]);

        double result = calculator.Calculate(num1, op, num2);
        Console.WriteLine(result);
    }
}
