
namespace Schifferl;

public class Schifferl {

    public record State(bool Water, bool Ship, bool Hit);
    public record Coordinate(int X, int Y);

    public static Boolean IsShipSunk(Schifferl.State[,] sea, int x, int y){
        Coordinate[] ship = GetShipCoordinates(sea, [], x, y);
        if(ship.Length==0) {
            throw new InvalidDataException("No ship there");
        }
        return ship.All((Coordinate c) => sea[c.X, c.Y].Hit);
    }

    public static Coordinate[] GetShipCoordinates(Schifferl.State[,] f, Coordinate[] c, int x, int y) {
        if(!f[x,y].Ship) {
            return c;
        }
        Coordinate newCoordinate = new(x,y);
        if(c.Contains(newCoordinate)) {
            return c;
        }
        Coordinate[] newC = [.. c, newCoordinate];
        Coordinate[] next = [new(x+1,y), new(x-1, y), new(x,y+1), new(x,y-1)];
        foreach(Coordinate nc in next) {
            newC = GetShipCoordinates(f, newC, nc.X, nc.Y);
        }
        return newC;
    }
}