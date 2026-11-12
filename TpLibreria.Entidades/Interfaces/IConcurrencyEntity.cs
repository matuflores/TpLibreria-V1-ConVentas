namespace TpLibreria.Entidades.Interfaces
{
    public interface IConcurrencyEntity
    {
        public byte[] RowVersion { get; set; }
    }
}
