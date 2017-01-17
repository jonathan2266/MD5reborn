namespace MD5reborn.terminal
{
    public abstract class Terminal : ITerminal
    {
        public abstract string Read();

        public abstract void Write();
    }
}
