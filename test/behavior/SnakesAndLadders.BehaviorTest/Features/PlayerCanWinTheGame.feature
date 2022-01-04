Feature: Player Can Win the Game
As a player
I want to be able to win the game
So that I can gloat to everyone around

    Scenario: Move token to the ending square
        Given the token is on square 97
        When the token is moved 3 spaces
        Then the token is on square 100
        And the player has won the game

    Scenario: Cannot move token to the ending square because dice rolled bigger value than required
        Given the token is on square 97
        When the token is moved 4 spaces
        Then the token is on square 97
        And the player has not won the game