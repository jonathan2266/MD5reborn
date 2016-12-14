namespace MD5reborn.format
{
    public interface IFormat
    {
        string ParseToFormat(string text, string hash);
        string GetHash(string fileLine);
        string GetWord(string fileLine);
    }
}
