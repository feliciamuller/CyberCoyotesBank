# CyberCoyotesBank Console Application

## Description
CyberCoyotesBank is a console-based banking application written in C#. Users can log in,
perform various banking operations, and administrators have additional functionalities.

## Features
### User Login
* Users are prompted to enter their username and password.
* After three unsuccessful attempts, the application exits. 

### Main Menu for Users
* Users can view their bank accounts, create new accounts, transfer money, apply for a loan and view transaction history. 
### Creating Bank Accounts
* Users can create checking or savings accounts. 
* Saving accounts have different interest rates based on the account balance. 
### Transferring Money
* Users can transfer money between their own accounts or to other customers accounts. 
### Applying for a Loan
* Users can apply for a loan, and the application calculates the loan amount based on user input.
### Viewing Transaction History
* Users can view the transaction history for each of their accounts. 
### Admin View
* Administrators have additional features, including creating new users or admins, updating exchange rates and 
viewving lists of users and admins. 

## Usage
1. Run the application.
2. Log in with your username and password.
3. Follow the on-screen propmts to perform various banking operations.

## Additional Notes
* The application includes a timer for delayed transactions (`Transaction15min`) and an exchange 
rate manager (`ExchangeRate`).
* Users and admins are managed through the `UserManager´ class.
* Exchange rates can be updated by administrators through the main menu.

## UML-diagram
https://lucid.app/lucidchart/3ef72aa1-93f9-4363-b45e-5e64555be5fc/edit?viewport_loc=-1446%2C207%2C2857%2C1725%2C0_0&invitationId=inv_9353416f-993e-41e4-955d-7d81dbfb412f

## Contributors
Felicia Müller, Fredrik Nellbeck, Tobias Söderqvist and Jonna Gustafsson

Thank you for using our console application!
