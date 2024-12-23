using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private int x;
    private int y;
    private Direction direction;

    public RobotSimulator(Direction direction, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.direction = direction;
    }

    public Direction Direction
    {
        get
        {
            return direction;
        }
    }

    public int X
    {
        get
        {
            return x;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
    }

    private Direction NewDirection(char letter)
    {
        if (letter == 'R')
        {
            int newDir = ((int)direction + 1) % 4;
            return (Direction)Enum.GetValues(typeof(Direction)).GetValue(newDir);
        }
        else
        {
            int newDir = ((int)direction - 1) % 4;
            if (newDir < 0)
                newDir = 3;

            return (Direction)Enum.GetValues(typeof(Direction)).GetValue(newDir);
        }
    }

    public void Move(string instructions)
    {
        foreach (var letter in instructions)
        {
            switch (letter)
            {
                case 'R':
                    direction = NewDirection(letter);
                    break;
                case 'L':
                    direction = NewDirection(letter);
                    break;
                case 'A':
                    switch (direction)
                    {
                        case Direction.North:
                            y = y + 1;
                            break;
                        case Direction.East:
                            x = x + 1;
                            break;
                        case Direction.South:
                            y = y - 1;
                            break;
                        case Direction.West:
                            x = x - 1;
                            break;
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;

                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}