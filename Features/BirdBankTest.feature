Feature: BirdBankTest

    @BirdBanks
    Scenario Bird Bank Cases
        Given Enter the BirdBank URL
        And Enter the valid Bird Bank credentials to login
        When Navigate to Purchase tab
        And Select Purchase your digital gold
        And Add "10" grams of gold to the cart
        And Add "50" grams of gold to the cart
        Then Verify the TotalGold