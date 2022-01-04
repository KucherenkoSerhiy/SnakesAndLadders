Feature: Token Can Move Across The Board
As a player
I want to be able to move my token
So that I can get closer to the goal

    Scenario: Place token on the start square
        Given the game is started
        When the token is placed on the board
        Then the token is on square 1

    Scenario: Move token
        Given the token is on square 1
        When the token is moved 3 spaces
        Then the token is on square 4

    Scenario: Move token 2 times
        Given the token is on square 1
        When the token is moved 3 spaces
        And then it is moved 5 spaces
        Then the token is on square 9

    Scenario: Hit a Ladder
        Given the token is on square 1
        When the token is moved 3 spaces
        And then it is moved 4 spaces
        Then the token is on square 31
        Scenario Outline: A ladder is located on tile 8 and moves player to tile 31
        