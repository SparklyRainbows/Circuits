using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelInformation
{
    public static Cable[,] GetLevel(int level) {
        if (level == 1)
            return LevelOne();
        if (level == 2)
            return LevelTwo();
        if (level == 3)
            return LevelThree();
        if (level == 4)
            return LevelFour();
        if (level == 5)
            return LevelFive();
        if (level == 6)
            return LevelSix();
        if (level == 7)
            return LevelSeven();
        if (level == 8)
            return LevelEight();
        if (level == 9)
            return LevelNine();
        if (level == 10)
            return LevelTen();
        Debug.LogWarning($"Level {level} not found");
        return null;
    }

    private static Cable[,] LevelOne() {
        Cable[,] grid = {
            {new Cable(CableType.GENERATOR), new Cable(CableType.CORNER) },
            {new Cable(CableType.STRAIGHT), new Cable(CableType.TARGET) },
        };

        return grid;
    }

    private static Cable[,] LevelTwo()
    {
        Cable[,] grid = {
            {new Cable(CableType.GENERATOR), new Cable(CableType.CORNER), new Cable(CableType.EMPTY) },
            {new Cable(CableType.EMPTY), new Cable(CableType.STRAIGHT,1), new Cable(CableType.EMPTY) },
            {new Cable(CableType.EMPTY), new Cable(CableType.CORNER,3), new Cable(CableType.TARGET) },
        };

        return grid;
    }

    private static Cable[,] LevelThree()
    {
        Cable[,] grid =
        {
            {new Cable(CableType.GENERATOR), new Cable(CableType.CORNER), new Cable(CableType.EMPTY) },
            {new Cable(CableType.CORNER,4), new Cable(CableType.CORNER), new Cable(CableType.TARGET) },
            {new Cable(CableType.CORNER,3), new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER,2) }
        };

        return grid;
    }

    private static Cable[,] LevelFour()
    {
        Cable[,] grid =
        {
            {new Cable(CableType.GENERATOR), new Cable(CableType.STRAIGHT,1), new Cable(CableType.STRAIGHT),new Cable(CableType.CORNER,3),},
            {new Cable(CableType.CORNER,1), new Cable(CableType.STRAIGHT), new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER,1), },
            {new Cable(CableType.CORNER,3), new Cable(CableType.STRAIGHT), new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER), },
            { new Cable(CableType.EMPTY), new Cable(CableType.EMPTY), new Cable(CableType.EMPTY), new Cable(CableType.TARGET), }
        };

        return grid;
    }

    public static Cable[,] LevelFive()
    {
        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.CORNER,3), new Cable(CableType.CORNER,2),new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER)},
            {new Cable(CableType.EMPTY), new Cable(CableType.CORNER,3), new Cable(CableType.CORNER),new Cable(CableType.EMPTY), new Cable(CableType.STRAIGHT,1)},
            {new Cable(CableType.CORNER,3), new Cable(CableType.CORNER,2), new Cable(CableType.EMPTY),new Cable(CableType.CORNER,1),new Cable(CableType.CORNER)},
            { new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER), new Cable(CableType.STRAIGHT,1), new Cable(CableType.CORNER,1), new Cable(CableType.EMPTY)},
            { new Cable(CableType.CORNER,2), new Cable(CableType.STRAIGHT), new Cable(CableType.STRAIGHT), new Cable(CableType.STRAIGHT),new Cable(CableType.TARGET) }
        };

        return grid;
    }

    public static Cable[,] LevelSix()
    {

        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.STRAIGHT,1), new Cable(CableType.T),new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER),new Cable(CableType.EMPTY)},
            { new Cable(CableType.EMPTY), new Cable(CableType.CORNER,1), new Cable(CableType.CORNER,2),new Cable(CableType.EMPTY), new Cable(CableType.TARGET),new Cable(CableType.EMPTY)},
            {new Cable(CableType.EMPTY), new Cable(CableType.T,1), new Cable(CableType.T,3),new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER,1),new Cable(CableType.EMPTY)},
            { new Cable(CableType.EMPTY), new Cable(CableType.TARGET), new Cable(CableType.EMPTY), new Cable(CableType.CORNER,3), new Cable(CableType.STRAIGHT),new Cable(CableType.CORNER,2)},
            { new Cable(CableType.EMPTY), new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER,1), new Cable(CableType.CORNER,1),new Cable(CableType.CORNER,1) ,new Cable(CableType.CORNER)},
            { new Cable(CableType.EMPTY), new Cable(CableType.CORNER,2), new Cable(CableType.CORNER,1), new Cable(CableType.EMPTY),new Cable(CableType.CORNER,2), new Cable(CableType.TARGET)},
        };

        return grid;
    }

    public static Cable[,] LevelSeven()
    {
        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER),new Cable(CableType.CORNER,1),new Cable(CableType.STRAIGHT),new Cable(CableType.TARGET)},
            { new Cable(CableType.EMPTY), new Cable(CableType.T,3), new Cable(CableType.CORNER,2),new Cable(CableType.T), new Cable(CableType.EMPTY),new Cable(CableType.STRAIGHT,1)},
            {new Cable(CableType.CORNER,1), new Cable(CableType.STRAIGHT), new Cable(CableType.TARGET),new Cable(CableType.STRAIGHT,1),new Cable(CableType.T,1),new Cable(CableType.T,2)},
            { new Cable(CableType.TARGET), new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER), new Cable(CableType.EMPTY), new Cable(CableType.STRAIGHT,1),new Cable(CableType.STRAIGHT)},
            { new Cable(CableType.EMPTY), new Cable(CableType.CORNER,3), new Cable(CableType.T,3), new Cable(CableType.TARGET),new Cable(CableType.T) ,new Cable(CableType.CORNER,1)},
            { new Cable(CableType.STRAIGHT), new Cable(CableType.TARGET), new Cable(CableType.STRAIGHT,1), new Cable(CableType.STRAIGHT),new Cable(CableType.STRAIGHT,1), new Cable(CableType.TARGET)},
        };

        return grid;
    }

    public static Cable[,]LevelEight()
    {
        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.CORNER), new Cable(CableType.CORNER),new Cable(CableType.CORNER,2),new Cable(CableType.CORNER,1),new Cable(CableType.TARGET)},
            { new Cable(CableType.CORNER,1), new Cable(CableType.CROSS), new Cable(CableType.CORNER,2),new Cable(CableType.CORNER), new Cable(CableType.CORNER,1),new Cable(CableType.STRAIGHT,1)},
            {new Cable(CableType.TARGET), new Cable(CableType.STRAIGHT), new Cable(CableType.CORNER,1),new Cable(CableType.STRAIGHT),new Cable(CableType.STRAIGHT,1),new Cable(CableType.TARGET)},
            { new Cable(CableType.CORNER,2), new Cable(CableType.TARGET), new Cable(CableType.CORNER,1), new Cable(CableType.CORNER,1), new Cable(CableType.BOMB),new Cable(CableType.CORNER,3)},
            { new Cable(CableType.STRAIGHT,1), new Cable(CableType.EMPTY), new Cable(CableType.STRAIGHT,1), new Cable(CableType.CORNER),new Cable(CableType.STRAIGHT) ,new Cable(CableType.CORNER,2)},
            { new Cable(CableType.CORNER,2), new Cable(CableType.TARGET), new Cable(CableType.T,3), new Cable(CableType.STRAIGHT),new Cable(CableType.STRAIGHT,1), new Cable(CableType.TARGET)},
        };

        return grid;
    }

    public static Cable[,] LevelNine()
    {
        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.T,1), new Cable(CableType.CORNER),new Cable(CableType.TARGET),new Cable(CableType.T,1),new Cable(CableType.CORNER),new Cable(CableType.TARGET)},
            { new Cable(CableType.CORNER,1), new Cable(CableType.CORNER,2),new Cable(CableType.CORNER,3), new Cable(CableType.STRAIGHT),new Cable(CableType.CROSS), new Cable(CableType.T,2),new Cable(CableType.CORNER)},
            {new Cable(CableType.STRAIGHT,1), new Cable(CableType.CORNER,1), new Cable(CableType.STRAIGHT,1),new Cable(CableType.STRAIGHT),new Cable(CableType.BOMB),new Cable(CableType.STRAIGHT),new Cable(CableType.STRAIGHT)},
            { new Cable(CableType.CORNER), new Cable(CableType.TARGET), new Cable(CableType.EMPTY), new Cable(CableType.CORNER), new Cable(CableType.TARGET),new Cable(CableType.CORNER,3),new Cable(CableType.STRAIGHT,1)},
            { new Cable(CableType.CORNER,2), new Cable(CableType.CORNER), new Cable(CableType.T), new Cable(CableType.TARGET),new Cable(CableType.T,1) ,new Cable(CableType.T,1),new Cable(CableType.TARGET)},
            { new Cable(CableType.TARGET), new Cable(CableType.CORNER), new Cable(CableType.STRAIGHT,1), new Cable(CableType.STRAIGHT,1),new Cable(CableType.T), new Cable(CableType.CORNER,1),new Cable(CableType.BOMB)},
            { new Cable(CableType.CORNER,2), new Cable(CableType.T), new Cable(CableType.TARGET), new Cable(CableType.EMPTY),new Cable(CableType.TARGET), new Cable(CableType.T),new Cable(CableType.STRAIGHT)}
        };

        return grid;
    }

    public static Cable[,] LevelTen()
    {
        Cable[,] grid =
               {
            {new Cable(CableType.GENERATOR), new Cable(CableType.STRAIGHT ), new Cable(CableType.CORNER),new Cable(CableType.T,2),new Cable(CableType.CORNER),new Cable(CableType.TARGET),new Cable(CableType.STRAIGHT,1),new Cable(CableType.CORNER)},
            { new Cable(CableType.CORNER,3), new Cable(CableType.STRAIGHT ),new Cable(CableType.CORNER,3), new Cable(CableType.TARGET),new Cable(CableType.CORNER,1), new Cable(CableType.T),new Cable(CableType.T),new Cable(CableType.T)},
            {new Cable(CableType.T), new Cable(CableType.TARGET), new Cable(CableType.EMPTY),new Cable(CableType.EMPTY),new Cable(CableType.T),new Cable(CableType.T,3),new Cable(CableType.BOMB),new Cable(CableType.STRAIGHT )},
            { new Cable(CableType.STRAIGHT ), new Cable(CableType.STRAIGHT,1), new Cable(CableType.CORNER,1), new Cable(CableType.TARGET), new Cable(CableType.CORNER,3),new Cable(CableType.BOMB),new Cable(CableType.CORNER,1),new Cable(CableType.CORNER,1)},
            { new Cable(CableType.TARGET), new Cable(CableType.CROSS), new Cable(CableType.T,2), new Cable(CableType.EMPTY),new Cable(CableType.TARGET) ,new Cable(CableType.STRAIGHT,1),new Cable(CableType.T,1),new Cable(CableType.CORNER,1)},
            { new Cable(CableType.CORNER ), new Cable(CableType.CORNER,2), new Cable(CableType.TARGET), new Cable(CableType.T,3),new Cable(CableType.CORNER), new Cable(CableType.CORNER),new Cable(CableType.CORNER,3),new Cable(CableType.STRAIGHT,1)},
            { new Cable(CableType.CORNER), new Cable(CableType.BOMB), new Cable(CableType.T,2), new Cable(CableType.STRAIGHT ),new Cable(CableType.CORNER), new Cable(CableType.CORNER,2),new Cable(CableType.CORNER),new Cable(CableType.TARGET)},
            { new Cable(CableType.STRAIGHT), new Cable(CableType.STRAIGHT ), new Cable(CableType.TARGET), new Cable(CableType.CORNER,3),new Cable(CableType.T), new Cable(CableType.CORNER,3),new Cable(CableType.CROSS),new Cable(CableType.CORNER,1)}
        };

        return grid;
    }

}
