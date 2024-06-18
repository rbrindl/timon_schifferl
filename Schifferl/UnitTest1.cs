namespace Schifferl;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void FoundShip()
    {
        Schifferl.State[,] f = NewSea();
        f[3,2] = new Schifferl.State(false, true, true);
        f[3,3] = new Schifferl.State(false, true, true);
        f[3,4] = new Schifferl.State(false, true, true); 
        Schifferl.Coordinate[] r = Schifferl.GetShipCoordinates(f, [], 3,3);
        Schifferl.Coordinate[] expected = [new(3,2), new(3,3), new(3,4)];
        Assert.That(r, Is.EquivalentTo(expected));
    }

    [Test]
    public void DidntFindShip()
    {
        Schifferl.State[,] f = NewSea();
        f[3,2] = new Schifferl.State(false, true, true);
        f[3,3] = new Schifferl.State(false, true, true);
        f[3,4] = new Schifferl.State(false, true, true); 
        Schifferl.Coordinate[] r = Schifferl.GetShipCoordinates(f, [], 4,3);
        Schifferl.Coordinate[] expected = [];
        Assert.That(r, Is.EquivalentTo(expected));
    }

    [Test]
    public void EmptySea()
    {
        Schifferl.State[,] f = NewSea();
        Schifferl.Coordinate[] r = Schifferl.GetShipCoordinates(f, [], 3,3);
        Schifferl.Coordinate[] expected = [];
        Assert.That(r, Is.EquivalentTo(expected));
    }

    [Test]
    public void ShipSunk() {
        Schifferl.State[,] f = NewSea();
        f[3,2] = new Schifferl.State(false, true, true);
        f[3,3] = new Schifferl.State(false, true, true);
        f[3,4] = new Schifferl.State(false, true, true); 
        bool r = Schifferl.IsShipSunk(f, 3,3);
        Assert.That(r, Is.True);
    }

    [Test]
    public void ShipAlive() {
        Schifferl.State[,] f = NewSea();
        f[3,2] = new Schifferl.State(false, true, true);
        f[3,3] = new Schifferl.State(false, true, false);
        f[3,4] = new Schifferl.State(false, true, true); 
        bool r = Schifferl.IsShipSunk(f, 3,3);
        Assert.That(r, Is.False);
    }

    private static Schifferl.State[,] NewSea() {
        Schifferl.State[,] f = new Schifferl.State[8, 8];
        for(int i = 0; i<8; i++) {
            for(int j=0; j<8; j++) {
                f[i,j] = new Schifferl.State(true,false,false);
            }
        }
        return f;
    }
}