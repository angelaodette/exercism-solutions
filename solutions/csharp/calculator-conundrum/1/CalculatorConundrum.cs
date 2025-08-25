public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {   
        try
        {
            int calculatedValue = 0;
    
            if (operation == null)
            {
                throw new ArgumentNullException("The operation argument cannot be null.");
            }
            if (operation == "")
            {
                throw new ArgumentException("The operation argument cannot be an empty string.");
            }
            if (operation != "+" && operation != "*" && operation != "/")
            {
                throw new ArgumentOutOfRangeException($"The operation argument {operation} is not allowed.");
            }
            switch (operation)
            {
                case "+":
                    calculatedValue = operand1 + operand2;
                    break;
                case "*":
                    calculatedValue = operand1 * operand2;
                    break;
                case "/":
                    calculatedValue = operand1 / operand2;
                    break;
            }
            return $"{operand1} {operation} {operand2} = {calculatedValue}";
        } 
        catch (DivideByZeroException ex)
        {
            return "Division by zero is not allowed.";
        }
    }
}
