
namespace DataModelsLib
{
    public class Visitor
    {
        public string ID { get; set; }
         public string Name { get; set; }
        public string Date { get; set; }
        public string Appartment { get; set; }
        public string Phone { get; set; }
        public string InTime { get; set; }

        public Visitor(string ID, string Name, string Date, string Appartment, string Phone, string Intime)
        {
            this.ID = ID;
            this.Name = Name;
            this.Date = Date;
            this.Appartment = Appartment;
            this.Phone = Phone;
            this.InTime = Intime;
        }
    }

}
