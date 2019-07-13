
public enum TileEnum
{
    colorTile = 1,

}

public enum TileColorEnum
{
    red = 1,
    blue = 2,
    green = 3,
    yellow = 4
    
}

//NTODO 这里还要考虑边缘,边缘与在tiles内部是不同的
public enum TileBgEnum
{
    top,
    left,
    right,
    down,

    top_left,
    top_right,
    top_down,
    left_right,
    left_down,
    right_down,

    top_left_right,
    top_left_down,
    top_right_down,
    left_right_down,


    top_left_right_down,

}