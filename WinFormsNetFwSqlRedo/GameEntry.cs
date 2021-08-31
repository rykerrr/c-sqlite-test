namespace WinFormsNetFwSqlRedo
{
    public class GameEntry
    {
        private int id = default;
        private string name = default;
        private string publisher = default;
        private string productionStudio = default;
        private string releaseDate = default;
        private decimal averageCost = default;
        
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Publisher
        {
            get => publisher;
            set => publisher = value;
        }
        public string ProductionStudio
        {
            get => productionStudio;
            set => productionStudio = value;
        }
        public string ReleaseDate
        {
            get => releaseDate;
            set => releaseDate = value;
        }
        public decimal AverageCost
        {
            get => averageCost;
            set => averageCost = value;
        }
        
        public GameEntry() { }

        public GameEntry(int id, string name, string publisher, string productionStudio, string releaseDate,
            decimal averageCost)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.productionStudio = productionStudio;
            this.releaseDate = releaseDate;
            this.averageCost = averageCost;
        }

        public override string ToString()
        {
            return
                $"Id: {Id} | Name: {Name} | Publisher: {Publisher} | Studio: {ProductionStudio} |" +
                $" Release Date: {ReleaseDate} | Cost: {AverageCost}";
        }
    }
}