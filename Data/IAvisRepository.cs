namespace Data
{
    public interface IAvisRepository
    {
        void SaveAvis(string commentaire, string nom, string idFormation, string note);

    }
}