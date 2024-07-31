Feature: Calculator
	
    Background: 
        Given Enter the PWC URL
        And Enter the valid credentials to login
		
    @mytag @regression
    Scenario Outline: : cal2 GSTR1 Page Navigation with invalid credentials
        Given Enter the <Username> and <Password>
        Then Verify User should see incorrect cred error
	  	
        Examples: 
          | Username            | Password     |
          | itadmin_gst_staging | itadmin@1234 |
		
#@ignore
    @mytag 
    Scenario Outline GSTR1 Page Navigation with valid credentials
        Given Enter the <Username> and <Password>
        When User clicks on GSTR1 page
        Then Verify User Navigates to the GSTR1 Page
		
        Examples: 
          | Username                  | Password    |
          | itadmin_gst_michelin_uat3 | itadmin@123 |