Feature: BirdBanks

    
    @BirdBanks 
    Scenario Bird Bank Cases - Purchase
        Given Enter the BirdBank URL
        And Enter the valid Bird Bank credentials to login
        When Navigate to Purchase tab
        And Select Purchase your digital gold
        And Add "<10>" grams of gold to the cart
        And Add "<50>" grams of gold to the cart
        Then Verify the TotalGold "<60>"
        
    @BirdBanks
    Scenario Bird Bank Cases - PayBill
        Given Enter the BirdBank URL
        And Enter the valid Bird Bank credentials to login
        When Navigate to Pay Bill tab
        And Select "<Yes Mutual Fund>" from the Bill Payment Table
        And Enter Payment Information
        Then Verify the Confirm Payment Banner    
        
    @BirdBanks
    Scenario Multi Windows Testing
        Given Enter the Practice URL
        