namespace Buildings;

public class Structure
{
    private readonly int _Id;
    private readonly int _EntrancesCount;

    public int Id => _Id;
    public int EntrancesCount => _EntrancesCount;


    public Structure(int Id, int EntrancesCount)
    {
        _Id = Id;
        _EntrancesCount = EntrancesCount;
    }
}
