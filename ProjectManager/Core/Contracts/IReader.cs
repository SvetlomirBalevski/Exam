namespace ProjectManager.Core.Contracts
{
    public interface IReader
    {
        /// <summary>
        /// Reads data from a specific source.
        /// </summary>
        /// <returns>Returns the read data as string.</returns>
        string ReadLine();
    }
}
