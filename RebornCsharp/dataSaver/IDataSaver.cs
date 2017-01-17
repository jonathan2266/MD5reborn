namespace MD5reborn.dataSaver
{
    public interface IDataSaver
    {
        void PushData(string text, string hash);
        void Finish();
    }
}
