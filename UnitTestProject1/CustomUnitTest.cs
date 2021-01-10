using System;

class MainClass
{
    public static void Main(string[] args)
    {
        //Example Run
        int expectedVal = 5;
        int myCalculatedVal = 5; //How am I going to take this? By consuming the API?

        EvaluateTestResult(1, expectedVal == myCalculatedVal);
    }

    private static void EvaluateTestResult(int testCaseNumber, bool compareResult)
    {
        string result = compareResult ? "SUCCESS" : "FAIL";
        Console.WriteLine("TestCase" + testCaseNumber + " : " + result);
    }
}

