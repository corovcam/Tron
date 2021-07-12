using UnityEngine;

public static class GameOptions
{
    private static int numberOfPlayers = 2;
    private static string initialSpeed = "Normal", background = "Black";
    private static string winner;
    private static GameObject[] players;

    public static int NumberOfPlayers
    {
        get
        {
            return numberOfPlayers;
        }
        set
        {
            numberOfPlayers = value;
        }
    }

    public static string InitialSpeed
    {
        get
        {
            return initialSpeed;
        }
        set
        {
            initialSpeed = value;
        }
    }

    public static string Background
    {
        get
        {
            return background;
        }
        set
        {
            background = value;
        }
    }

    public static string Winner
    {
        get
        {
            return winner;
        }
        set
        {
            winner = value;
        }
    }

    public static GameObject[] Players
    {
        get
        {
            return players;
        }
        set
        {
            players = value;
        }
    }
}