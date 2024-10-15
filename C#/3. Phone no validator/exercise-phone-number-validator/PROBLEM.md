# Problem Statement: Phone number validator using for loop #

Given a String find whether it is a valid ten digit phone number

This exercise contains a class named PhoneNumberValidator with the following methods :
    
    +GetInput() : String 
    - Should accept input for phone number 
---------------------------------------------------------------------
    +ValidatePhoneNumber(String) : int
    - Should validate the string using the following business rules:
        -  Should contain only numbers or dashes(-)
        -  Dashes may appear in any position.
        -  Should have exactly 10 digits 
        -  If the string is a valid phone number then 1 is returned
        -  If the input string is empty/null -1 is returned
        -  If the string is not a valid phone number then 0 is returned.
-------------------------------------------------------------------- 
    +DisplayResult() : void 
    - Should display the output as shown in the example 
-------------------------------------------------------------------------------       
      
**Sample Output**

    Sample Input:
    99-080-99989
    
    Expected Output:
    Valid
--------------------------------------------------------
    Sample Input:
    99-6u7-99999
    
    Expected Output:
    Invalid 
--------------------------------------------------------
    Sample Input:
    91-999-99
    
    Expected Output:
    Invalid 

**Instructions**

- Avoid printing unnecessary values other than expected output as given in sample
- Take care of whitespace/trailing whitespace
- Do not change the provided class/method names unless instructed
- Follow best practices while coding
