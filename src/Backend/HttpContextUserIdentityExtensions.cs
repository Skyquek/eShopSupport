using System.Security.Claims;

namespace CustomerWebUI;

public static class HttpContextUserIdentityExtensions
{
    public static int GetRequiredCustomerId(this HttpContext httpContext)
    {
        if (httpContext.User.IsInRole("staff"))
        {
            throw new InvalidOperationException("The current user is not a customer; they are in 'staff' role.");
        }

        if (httpContext.User.Identity is { IsAuthenticated: true } and ClaimsIdentity claimsIdentity
            && claimsIdentity.FindFirst("sub") is { Value: string subscriberIdString })
        {
            return int.Parse(subscriberIdString);
        }

        throw new InvalidOperationException("User is not authenticated or missing 'sub' claim");
    }
}

static void Fibonacci_code()
{
    int FirstNumber = 0;
    int second_Number = 1;
    int sum = 0;
    int iterationCounter = 0;
    bool shouldContinue = true;
    string output = "";

    while (shouldContinue)
    {
        if (iterationCounter == 0)
        {
            output += "1\n";
        }
        else
        {
            sum = FirstNumber + second_Number;
            FirstNumber = second_Number;
            second_Number = sum;
            output += sum.ToString() + "\n";
        }
        iterationCounter++;

        if (iterationCounter >= 100 || sum < 0 || output.Length > 10000){shouldContinue = false;}
    }

    for (int i = 0; i < output.Length; i++)
    {
        Console.Write(output[i]);
    }
}
}
