namespace OOP;

static class IdGenerator
{
    private static int _current = 999;
    
    public static int GenerateNewId()
    {
        _current++;
        return _current;
    }
}



