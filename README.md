# Issue 1
Not consistent. Spent most time on OrdersController. Should have made other classes cleaner and implemented errors. Most of the projects is going through happy paths. Very prone to errors and crashes.

# Issue 2
Couldn't implement the Unit Tests, spent too much time between thinking how to implement the case's version and thinking about using ms test, and then implementing neither. Should ask about how to implement case requirement version.




# Kronotrop
/*--------Kronotrop Order API---------
 * A famous coffee shop in Istanbul needs an automation system for its employee 
 * to get orders and preperation of receipt for the customers. 
 * 
 * This coffee shop has the following list of beverages in standard season
 *      -Black Coffee
 *      -Latte
 *      -Mocha
 *      -Tea
 * However, note that this list is very upto change according to addition of 
 * some special drinks during special times or events... 
 * 
 * For beverages, customers may have make following additions .This list is also open to 
 * extend in future.  
 *
 *      -Milk
 *      -Chocalate sauce
 *      -Hazelnut Syrup
 * 
 * Here are some examples for customer requests
 *      -Black Coffe with milk
 *      -Mocha with double(2x) milk
 *      -Latte with milk and Hazelnut Syrup
 *      
 * Task Definiton
 * Your task is design and implement back end of such a system with its API. 
 * Using this API, Frontend developers should easily adopt their UI and use the system as intended.
 * It is totatlly up to your desing and decisions what services you should be supplying to such a system.     
 *Also you are required to defiene and implement unit test cases for your ipmpelemtation.
 */
using System;

class MainClass {
  public static void Main (string[] args) 
  {
    // Example Run
    int expectedVal = 5; 
    int myCalculatedVal = 5; 

    EvaluateTestResult(1,expectedVal == myCalculatedVal  );

  }

  private static void EvaluateTestResult(int testCaseNumber, bool compareResult)
  {
        string result = compareResult ? "SUCCESS" : "FAIL";
        Console.WriteLine("TestCase" + testCaseNumber + ": " + result);
  }
}
